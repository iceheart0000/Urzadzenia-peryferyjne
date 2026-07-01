using SharpDX;
using SharpDX.DirectSound;
using SharpDX.IO;
using SharpDX.Multimedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KartaMuzyczna
{
    public partial class Form1 : Form
    {
        private string currentFile = "";
        private DirectSound directSound = null;
        private SecondarySoundBuffer dsBuffer = null;

        private byte[] originalRawData = null;
        private int wavSampleRate = 44100;
        private short wavChannels = 2;
        private short wavBitsPerSample = 16;

        private const float MIN_FREQ = 60f;
        private const float MAX_FREQ = 4000f;
        private const float LFO_SPEED = 0.2f;

        private IntPtr hWaveOut = IntPtr.Zero;
        private GCHandle waveHandle;

        private IntPtr hWaveIn = IntPtr.Zero;
        private List<IntPtr> headerPtrs = new List<IntPtr>();
        private MemoryStream recordedStream = new MemoryStream();
        private bool isRecording = false;

        public Form1()
        {
            InitializeComponent();
            InitializeDirectSound();
        }

        [DllImport("winmm.dll", EntryPoint = "PlaySound")]
        private static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);
        private const uint SND_ASYNC = 0x0001;
        private const uint SND_FILENAME = 0x00020000;
        private const uint SND_PURGE = 0x0040;

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        [DllImport("winmm.dll")] private static extern int waveOutOpen(out IntPtr hWaveOut, int uDeviceID, ref WAVEFORMATEX lpFormat, IntPtr dwCallback, IntPtr dwInstance, int dwFlags);
        [DllImport("winmm.dll")] private static extern int waveOutPrepareHeader(IntPtr hWaveOut, ref WAVEHDR lpWaveOutHdr, int uSize);
        [DllImport("winmm.dll")] private static extern int waveOutWrite(IntPtr hWaveOut, ref WAVEHDR lpWaveOutHdr, int uSize);
        [DllImport("winmm.dll")] private static extern int waveOutReset(IntPtr hWaveOut);
        [DllImport("winmm.dll")] private static extern int waveOutClose(IntPtr hWaveOut);
        [DllImport("winmm.dll")] private static extern int waveOutPause(IntPtr hWaveOut);
        [DllImport("winmm.dll")] private static extern int waveOutRestart(IntPtr hWaveOut);

        [DllImport("winmm.dll")] private static extern int waveInOpen(out IntPtr hWaveIn, int uDeviceID, ref WAVEFORMATEX lpFormat, IntPtr dwCallback, IntPtr dwInstance, int dwFlags);
        [DllImport("winmm.dll")] private static extern int waveInPrepareHeader(IntPtr hWaveIn, IntPtr lpWaveInHdr, int uSize);
        [DllImport("winmm.dll")] private static extern int waveInAddBuffer(IntPtr hWaveIn, IntPtr lpWaveInHdr, int uSize);
        [DllImport("winmm.dll")] private static extern int waveInUnprepareHeader(IntPtr hWaveIn, IntPtr lpWaveInHdr, int uSize);
        [DllImport("winmm.dll")] private static extern int waveInStart(IntPtr hWaveIn);
        [DllImport("winmm.dll")] private static extern int waveInStop(IntPtr hWaveIn);
        [DllImport("winmm.dll")] private static extern int waveInReset(IntPtr hWaveIn);
        [DllImport("winmm.dll")] private static extern int waveInClose(IntPtr hWaveIn);

        private const int CALLBACK_WINDOW = 0x00010000;
        private const int MM_WIM_DATA = 0x3C0;

        [StructLayout(LayoutKind.Sequential)]
        public struct WAVEFORMATEX
        {
            public short wFormatTag;
            public short nChannels;
            public int nSamplesPerSec;
            public int nAvgBytesPerSec;
            public short nBlockAlign;
            public short wBitsPerSample;
            public short cbSize;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WAVEHDR
        {
            public IntPtr lpData;
            public int dwBufferLength;
            public int dwBytesRecorded;
            public IntPtr dwUser;
            public int dwFlags;
            public int dwLoops;
            public IntPtr lpNext;
            public IntPtr reserved;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Pliki WAV (*.wav)|*.wav";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFile = openFileDialog1.FileName;
                txtFilePath.Text = currentFile;
                axWindowsMediaPlayer1.URL = currentFile;
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
        }

        private void btnStartPlaySound_Click(object sender, EventArgs e) { if (!string.IsNullOrEmpty(currentFile)) PlaySound(currentFile, IntPtr.Zero, SND_FILENAME | SND_ASYNC); }
        private void btnStopPlaySound_Click(object sender, EventArgs e) { PlaySound(null, IntPtr.Zero, SND_PURGE); }

        private void btnStartWMP_Click(object sender, EventArgs e) { if (!string.IsNullOrEmpty(currentFile)) { if (axWindowsMediaPlayer1.URL != currentFile) axWindowsMediaPlayer1.URL = currentFile; axWindowsMediaPlayer1.Ctlcontrols.play(); } }
        private void btnStopWMP_Click(object sender, EventArgs e) { axWindowsMediaPlayer1.Ctlcontrols.stop(); }

        private void btnStartMCI_Click(object sender, EventArgs e) { if (string.IsNullOrEmpty(currentFile)) return; mciSendString("close myDevice", null, 0, IntPtr.Zero); mciSendString("open \"" + currentFile + "\" type waveaudio alias myDevice", null, 0, IntPtr.Zero); mciSendString("play myDevice", null, 0, IntPtr.Zero); }
        private void btnStopMCI_Click(object sender, EventArgs e) { mciSendString("stop myDevice", null, 0, IntPtr.Zero); mciSendString("close myDevice", null, 0, IntPtr.Zero); }
        private bool mciPaused = false;
        private void btnPauseMCI_Click(object sender, EventArgs e) { if (!mciPaused) { mciSendString("pause myDevice", null, 0, IntPtr.Zero); mciPaused = true; } else { mciSendString("resume myDevice", null, 0, IntPtr.Zero); mciPaused = false; } }

        private void btnStartWave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFile)) return;
            byte[] wavData = File.ReadAllBytes(currentFile);
            short channels = BitConverter.ToInt16(wavData, 22);
            int sampleRate = BitConverter.ToInt32(wavData, 24);
            short bitsPerSample = BitConverter.ToInt16(wavData, 34);

            WAVEFORMATEX format = new WAVEFORMATEX();
            format.wFormatTag = 1; format.nChannels = channels; format.nSamplesPerSec = sampleRate; format.wBitsPerSample = bitsPerSample;
            format.nBlockAlign = (short)(channels * (bitsPerSample / 8)); format.nAvgBytesPerSec = sampleRate * format.nBlockAlign; format.cbSize = 0;

            waveOutOpen(out hWaveOut, -1, ref format, IntPtr.Zero, IntPtr.Zero, 0);
            WAVEHDR header = new WAVEHDR();
            int headerSize = 44; int dataLength = wavData.Length - headerSize;
            byte[] audioData = new byte[dataLength]; Array.Copy(wavData, headerSize, audioData, 0, dataLength);

            waveHandle = GCHandle.Alloc(audioData, GCHandleType.Pinned);
            header.lpData = waveHandle.AddrOfPinnedObject();
            header.dwBufferLength = dataLength;

            waveOutPrepareHeader(hWaveOut, ref header, Marshal.SizeOf(header));
            waveOutWrite(hWaveOut, ref header, Marshal.SizeOf(header));
        }

        private void btnStopWave_Click(object sender, EventArgs e) { if (hWaveOut != IntPtr.Zero) { waveOutReset(hWaveOut); waveOutClose(hWaveOut); hWaveOut = IntPtr.Zero; if (waveHandle.IsAllocated) waveHandle.Free(); } }
        private bool wavePaused = false;
        private void btnPauseWave_Click(object sender, EventArgs e) { if (hWaveOut != IntPtr.Zero) { if (!wavePaused) { waveOutPause(hWaveOut); wavePaused = true; } else { waveOutRestart(hWaveOut); wavePaused = false; } } }

        private void InitializeDirectSound()
        {
            try
            {
                directSound = new DirectSound();
                directSound.SetCooperativeLevel(this.Handle, CooperativeLevel.Priority);
            }
            catch { }
        }

        private void btnStartDS_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFile) || directSound == null) return;
            try
            {
                btnStopDS_Click(null, null);

                using (var fileStream = new FileStream(currentFile, FileMode.Open, FileAccess.Read))
                {
                    var waveStream = new SoundStream(fileStream);

                    wavSampleRate = waveStream.Format.SampleRate;
                    wavChannels = (short)waveStream.Format.Channels;
                    wavBitsPerSample = (short)waveStream.Format.BitsPerSample;

                    originalRawData = new byte[waveStream.Length];
                    waveStream.Read(originalRawData, 0, (int)waveStream.Length);

                    waveStream.Close();
                }

                if (wavChannels != 2)
                {
                    MessageBox.Show("Wymagany plik Stereo (2 kanały)!");
                    return;
                }

                PlayWithPerfectX();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void PlayWithPerfectX()
        {
            if (originalRawData == null || directSound == null) return;

            if (dsBuffer != null)
            {
                dsBuffer.Stop();
                dsBuffer.Dispose();
                dsBuffer = null;
            }

            var statusLabel = this.Controls.Find("lblStatusDSP", true);
            if (statusLabel.Length > 0)
                statusLabel[0].Text = "Tryb: Idealna separacja kanałów (X)";

            byte[] filteredData = ApplySeparateLFO(originalRawData);

            var waveFormat = new WaveFormat(wavSampleRate, wavBitsPerSample, wavChannels);
            var bufferDesc = new SoundBufferDescription();
            bufferDesc.Format = waveFormat;
            bufferDesc.BufferBytes = filteredData.Length;
            bufferDesc.Flags = BufferFlags.GlobalFocus | BufferFlags.ControlVolume | BufferFlags.ControlPan;

            dsBuffer = new SecondarySoundBuffer(directSound, bufferDesc);
            dsBuffer.Write(filteredData, 0, LockFlags.None);
            dsBuffer.Play(0, PlayFlags.Looping);
        }

        private byte[] ApplySeparateLFO(byte[] input)
        {
            if (wavBitsPerSample != 16) return input;

            int byteCount = input.Length;
            byte[] output = new byte[byteCount];

            int sampleCount = byteCount / 2;
            short[] samples = new short[sampleCount];
            Buffer.BlockCopy(input, 0, samples, 0, byteCount);

            double dt = 1.0 / wavSampleRate;
            double prevL = 0, prevR = 0;
            double logRange = MAX_FREQ / MIN_FREQ;

            for (int i = 0; i < sampleCount; i += 2)
            {
                double time = (double)(i / 2) / wavSampleRate;

                double angleL = (2.0 * Math.PI * LFO_SPEED * time) - (Math.PI / 2.0);
                double normL = (Math.Sin(angleL) + 1.0) / 2.0;

                double angleR = angleL + Math.PI;
                double normR = (Math.Sin(angleR) + 1.0) / 2.0;

                float currentFreqL = (float)(MIN_FREQ * Math.Pow(logRange, normL));
                float currentFreqR = (float)(MIN_FREQ * Math.Pow(logRange, normR));

                double alphaL = dt / ( (1.0 / (2.0 * Math.PI * currentFreqL)) + dt);
                double alphaR = dt / ( (1.0 / (2.0 * Math.PI * currentFreqR)) + dt);

                double outL = prevL + alphaL * (samples[i] - prevL);
                prevL = outL;
                samples[i] = (short)outL;

                if (i + 1 < sampleCount)
                {
                    double outR = prevR + alphaR * (samples[i + 1] - prevR);
                    prevR = outR;
                    samples[i + 1] = (short)outR;
                }
            }

            Buffer.BlockCopy(samples, 0, output, 0, byteCount);
            return output;
        }

        private void btnStopDS_Click(object sender, EventArgs e)
        {
            if (dsBuffer != null)
            {
                dsBuffer.Stop();
                dsBuffer.Dispose();
                dsBuffer = null;
            }
            var statusLabel = this.Controls.Find("lblStatusDSP", true);
            if (statusLabel.Length > 0)
                statusLabel[0].Text = "Zatrzymano.";
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == MM_WIM_DATA)
            {
                if (isRecording)
                {
                    IntPtr pWaveHdr = m.LParam;
                    WAVEHDR hdr = (WAVEHDR)Marshal.PtrToStructure(pWaveHdr, typeof(WAVEHDR));

                    if (hdr.dwBytesRecorded > 0)
                    {
                        byte[] buffer = new byte[hdr.dwBytesRecorded];
                        Marshal.Copy(hdr.lpData, buffer, 0, hdr.dwBytesRecorded);
                        recordedStream.Write(buffer, 0, buffer.Length);

                        Control[] labels = this.Controls.Find("lblRecStatus", true);
                        if (labels.Length > 0) labels[0].Text = "Nagrano: " + (recordedStream.Length / 1024) + " KB";
                    }
                    waveInAddBuffer(hWaveIn, pWaveHdr, Marshal.SizeOf(typeof(WAVEHDR)));
                }
            }
            base.WndProc(ref m);
        }

        private void btnStartRec_Click(object sender, EventArgs e)
        {
            try
            {
                if (isRecording) return;
                recordedStream = new MemoryStream();
                WAVEFORMATEX format = new WAVEFORMATEX();
                format.wFormatTag = 1; format.nChannels = 1; format.nSamplesPerSec = 44100; format.wBitsPerSample = 16;
                format.nBlockAlign = (short)(format.nChannels * (format.wBitsPerSample / 8));
                format.nAvgBytesPerSec = format.nSamplesPerSec * format.nBlockAlign; format.cbSize = 0;

                int res = waveInOpen(out hWaveIn, -1, ref format, this.Handle, IntPtr.Zero, CALLBACK_WINDOW);
                if (res != 0) throw new Exception("Błąd mikrofonu: " + res);

                for (int i = 0; i < 3; i++) AddBufferToWaveIn();

                waveInStart(hWaveIn);
                isRecording = true;

                lblRecStatus.Text = "Nagrywanie (WaveIn)...";
                lblRecStatus.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AddBufferToWaveIn()
        {
            WAVEHDR hdr = new WAVEHDR();
            int bufferSize = 8820;
            hdr.lpData = Marshal.AllocHGlobal(bufferSize);
            hdr.dwBufferLength = bufferSize;
            hdr.dwBytesRecorded = 0;
            hdr.dwFlags = 0;

            IntPtr pHdr = Marshal.AllocHGlobal(Marshal.SizeOf(hdr));
            Marshal.StructureToPtr(hdr, pHdr, false);
            headerPtrs.Add(pHdr);

            waveInPrepareHeader(hWaveIn, pHdr, Marshal.SizeOf(hdr));
            waveInAddBuffer(hWaveIn, pHdr, Marshal.SizeOf(hdr));
        }

        private void btnStopRec_Click(object sender, EventArgs e)
        {
            if (!isRecording) return;
            isRecording = false;

            waveInStop(hWaveIn);
            waveInReset(hWaveIn);

            foreach (var pHdr in headerPtrs)
            {
                WAVEHDR hdr = (WAVEHDR)Marshal.PtrToStructure(pHdr, typeof(WAVEHDR));
                waveInUnprepareHeader(hWaveIn, pHdr, Marshal.SizeOf(typeof(WAVEHDR)));
                Marshal.FreeHGlobal(hdr.lpData);
                Marshal.FreeHGlobal(pHdr);
            }
            headerPtrs.Clear();

            waveInClose(hWaveIn);
            hWaveIn = IntPtr.Zero;

            lblRecStatus.Text = "Zatrzymano. Rozmiar: " + (recordedStream.Length / 1024) + " KB";
            lblRecStatus.ForeColor = System.Drawing.Color.Black;
        }

        private void btnSaveRec_Click(object sender, EventArgs e)
        {
            if (recordedStream.Length == 0) { MessageBox.Show("Brak danych!"); return; }
            saveFileDialog1.FileName = "Nagranie_WaveIn.wav";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = recordedStream.ToArray();
                    bw.Write(Encoding.ASCII.GetBytes("RIFF")); bw.Write(36 + data.Length); bw.Write(Encoding.ASCII.GetBytes("WAVE"));
                    bw.Write(Encoding.ASCII.GetBytes("fmt ")); bw.Write(16); bw.Write((short)1); bw.Write((short)1); bw.Write(44100); bw.Write(88200); bw.Write((short)2); bw.Write((short)16);
                    bw.Write(Encoding.ASCII.GetBytes("data")); bw.Write(data.Length); bw.Write(data);
                }
                lblRecStatus.Text = "Zapisano.";
            }
        }
    }
}
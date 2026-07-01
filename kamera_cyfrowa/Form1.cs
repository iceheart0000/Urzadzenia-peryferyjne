using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Accord.Video.FFMPEG;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private VideoFileWriter videoWriter;
        private bool isRecording = false;
        private int brightnessValue = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeCamera();
        }

        private void InitializeCamera()
        {
            try
            {
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    MessageBox.Show("Nie znaleziono kamer!");
                    return;
                }

                videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd inicjalizacji kamery: " + ex.Message);
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            ApplyBrightness(frame, brightnessValue);

            if (pictureBox1.InvokeRequired)
            {
                pictureBox1.Invoke(new Action(() =>
                {
                    var old = pictureBox1.Image;
                    pictureBox1.Image = frame;
                    if (old != null) old.Dispose();
                }));
            }
            else
            {
                var old = pictureBox1.Image;
                pictureBox1.Image = frame;
                if (old != null) old.Dispose();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (videoSource != null && !videoSource.IsRunning)
            {
                videoSource.Start();
                startRecording();
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopCamera();
            stopRecording();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void StopCamera()
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
        }

        private void screensh()
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Brak obrazu do zapisania.");
                return;
            }

            using (Bitmap snapshot = new Bitmap(pictureBox1.Image))
            {
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string fileName = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";
                string fullPath = Path.Combine(folder, fileName);
                snapshot.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show($"Zapisano zdjęcie: {fullPath}", "Screenshot", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void startRecording()
        {
            if (videoSource == null || !videoSource.IsRunning)
            {
                MessageBox.Show("Kamera nie jest uruchomiona!");
                return;
            }

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            string fileName = $"nagranie_{DateTime.Now:yyyyMMdd_HHmmss}.avi";
            string fullPath = Path.Combine(folder, fileName);
            videoWriter = new VideoFileWriter();
            videoWriter.Open(fullPath, pictureBox1.Width, pictureBox1.Height, 25, VideoCodec.MPEG4);
            isRecording = true;
            MessageBox.Show("Rozpoczęto nagrywanie wideo.", "Nagrywanie");
        }

        private void stopRecording()
        {
            if (isRecording)
            {
                isRecording = false;
                videoWriter?.Close();
                videoWriter?.Dispose();
                videoWriter = null;
                MessageBox.Show("Nagrywanie zakończone.");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCamera();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }

        private void screenshot_Click(object sender, EventArgs e)
        {
            screensh();
        }

        private void brightnessBar_Scroll(object sender, EventArgs e)
        {
            brightnessValue = brightnessBar.Value;
            labelBrightness.Text = $"Jasność: {brightnessValue}%";
        }

        private void ApplyBrightness(Bitmap image, int brightness)
        {
            if (brightness == 0) return;

            brightness = Math.Max(-100, Math.Min(100, brightness));

            float bFactor = brightness / 100f;

            using (Graphics g = Graphics.FromImage(image))
            {
                float[][] ptsArray =
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {bFactor, bFactor, bFactor, 0, 1}
                };

                var imageAttributes = new System.Drawing.Imaging.ImageAttributes();
                imageAttributes.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(ptsArray));

                g.DrawImage
                (
                    image,
                    new Rectangle(0, 0, image.Width, image.Height),
                    0, 0, image.Width, image.Height,
                    GraphicsUnit.Pixel,
                    imageAttributes
                );
            }
        }



    }
}

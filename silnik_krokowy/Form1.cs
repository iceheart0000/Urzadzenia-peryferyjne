using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using FTD2XX_NET;

namespace SilnikKrokowy
{
   
    public partial class Form1 : Form
    {
        
        private readonly FTDI ftdiDevice = new FTDI();
        private FT_DEVICE_INFO_NODE[] deviceList;

        private int currentStepIndex = 0;
        private volatile bool isMoving = false; 

        private readonly byte[] seqWave = { 0x01, 0x04, 0x02, 0x08 };
        private readonly byte[] seqFullStep = { 0x05, 0x06, 0x0A, 0x09 };
        private readonly byte[] seqHalfStep = { 0x01, 0x05, 0x04, 0x06, 0x02, 0x0A, 0x08, 0x09 };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDeviceList();
        }

        private void RefreshDeviceList()
        {
            comboDevices.Items.Clear();
            UInt32 numDevices = 0;

            try
            {
                FT_STATUS status = ftdiDevice.GetNumberOfDevices(ref numDevices);
                if (status != FT_STATUS.FT_OK)
                {
                    SetStatus("Błąd odczytu liczby urządzeń: " + status.ToString());
                    return;
                }

                if (numDevices == 0)
                {
                    SetStatus("Nie znaleziono urządzeń FTDI.");
                    btnConnect.Enabled = false;
                    return;
                }

                btnConnect.Enabled = true;
                deviceList = new FT_DEVICE_INFO_NODE[numDevices];
                status = ftdiDevice.GetDeviceList(deviceList);

                if (status == FT_STATUS.FT_OK)
                {
                    for (UInt32 i = 0; i < numDevices; i++)
                    {
                        string displayText = $"({i}) {deviceList[i].Description} [SN: {deviceList[i].SerialNumber}]";
                        comboDevices.Items.Add(displayText);
                    }
                    if (numDevices > 0)
                        comboDevices.SelectedIndex = 0;
                    SetStatus($"Znaleziono {numDevices} urządzeń. Wybierz urządzenie i połącz.");
                }
            }
            catch (Exception ex)
            {
                SetStatus("Błąd skanowania urządzeń: " + ex.Message);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (isMoving) return;

            try
            {
                if (ftdiDevice.IsOpen)
                {
                    WriteStep(0x00);
                    ftdiDevice.SetBitMode(FTDI.FT_BITMODE_RESET, 0);
                    ftdiDevice.Close();
                    SetUIState(false);
                    SetStatus("Rozłączono.");
                }
                else
                {
                    if (comboDevices.SelectedIndex == -1)
                    {
                        SetStatus("Wybierz urządzenie z listy.");
                        return;
                    }

                    UInt32 selectedIndex = (UInt32)comboDevices.SelectedIndex;
                    FT_STATUS status = ftdiDevice.OpenByIndex(selectedIndex);

                    if (status != FT_STATUS.FT_OK)
                    {
                        SetStatus("Błąd otwarcia urządzenia: " + status.ToString());
                        return;
                    }

                    status = ftdiDevice.SetBitMode(0xFF, FTDI.FT_BITMODE_ASYNC_BITBANG);
                    if (status != FT_STATUS.FT_OK)
                    {
                        SetStatus("Błąd ustawienia trybu BitMode: " + status.ToString());
                        ftdiDevice.Close();
                        return;
                    }

                    WriteStep(0x00); 
                    SetUIState(true);
                    SetStatus($"Połączono z: {comboDevices.Text}");
                }
            }
            catch (Exception ex)
            {
                SetStatus("Błąd połączenia: " + ex.Message);
            }
        }

        private void btnStepLeft_Click(object sender, EventArgs e)
        {
            PerformSteps(false);
        }

        private void btnStepRight_Click(object sender, EventArgs e)
        {
            PerformSteps(true);
        }

        private void PerformSteps(bool moveRight)
        {
            if (isMoving) return;
            isMoving = true;

            if (!ftdiDevice.IsOpen)
            {
                isMoving = false;
                return;
            }

            int stepsToMove = (int)numSteps.Value;
            int stepTimeMs = (int)numStepTime.Value;

            byte[] sequence;
            if (radioWave.Checked)
                sequence = seqWave;
            else if (radioFullStep.Checked)
                sequence = seqFullStep;
            else
                sequence = seqHalfStep;

            SetMovementUI(false);
            SetStatus($"Wykonywanie {stepsToMove} kroków...");

            Task.Run(() =>
            {
                try
                {
                    for (int i = 0; i < stepsToMove; i++)
                    {
                        if (!ftdiDevice.IsOpen) break;

                        if (moveRight)
                        {
                            currentStepIndex = (currentStepIndex + 1) % sequence.Length;
                        }
                        else
                        {
                            currentStepIndex--;
                            if (currentStepIndex < 0)
                                currentStepIndex = sequence.Length - 1;
                        }

                        WriteStep(sequence[currentStepIndex]);
                        Thread.Sleep(stepTimeMs);
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(new Action(() => SetStatus($"Błąd podczas ruchu: {ex.Message}")));
                }
                finally
                {
                    isMoving = false;
                    this.Invoke(new Action(() =>
                    {
                        SetMovementUI(true);
                        SetStatus("Ruch zakończony. Gotowy.");
                    }));
                }
            });
        }

        private void WriteStep(byte value)
        {
            if (!ftdiDevice.IsOpen) return;
            try
            {
                UInt32 bytesWritten = 0;
                byte[] buffer = { value };
                ftdiDevice.Write(buffer, 1, ref bytesWritten);
            }
            catch (Exception ex)
            {
                if (this.IsHandleCreated)
                {
                    this.Invoke(new Action(() => SetStatus($"Błąd zapisu kroku: {ex.Message}")));
                }
            }
        }


        private void btnReadEEPROM_Click(object sender, EventArgs e)
        {
            if (!ftdiDevice.IsOpen)
            {
                SetStatus("Urządzenie nie jest połączone.");
                return;
            }

            try
            {
                FT_STATUS status = ftdiDevice.ReadEEPROM(out string serial, out string desc, out UInt16 vid, out UInt16 pid);

                if (status == FT_STATUS.FT_OK)
                {
                    txtSerial.Text = serial;
                    txtProductDesc.Text = desc;
                    txtVID.Text = $"0x{vid:X4}";
                    txtPID.Text = $"0x{pid:X4}"; 
                    SetStatus("Odczytano EEPROM.");
                }
                else
                {
                    SetStatus("Błąd odczytu EEPROM: " + status.ToString());
                }
            }
            catch (Exception ex)
            {
                SetStatus("Błąd odczytu EEPROM: " + ex.Message);
            }
        }

        private void btnWriteEEPROM_Click(object sender, EventArgs e)
        {
            if (!ftdiDevice.IsOpen)
            {
                SetStatus("Urządzenie nie jest połączone.");
                return;
            }

            if (MessageBox.Show("Czy na pewno chcesz nadpisać EEPROM?\nMoże to wymagać ponownego podłączenia urządzenia.",
                                "Potwierdzenie zapisu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            try
            {
                string newSerial = txtSerial.Text;
                string newDesc = txtProductDesc.Text;

                FT_STATUS status = ftdiDevice.WriteEEPROM(newSerial, newDesc);

                if (status == FT_STATUS.FT_OK)
                {
                    SetStatus("Zapisano EEPROM. Podłącz urządzenie ponownie, aby zobaczyć zmiany.");
                }
                else
                {
                    SetStatus("Błąd zapisu EEPROM: " + status.ToString());
                }
            }
            catch (Exception ex)
            {
                SetStatus("Błąd zapisu EEPROM: " + ex.Message);
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isMoving)
            {
                e.Cancel = true;
                SetStatus("Zatrzymaj ruch przed zamknięciem!");
                return;
            }

            if (ftdiDevice.IsOpen)
            {
                try
                {
                    WriteStep(0x00);
                    ftdiDevice.SetBitMode(FTDI.FT_BITMODE_RESET, 0);
                    ftdiDevice.Close();
                }
                catch (Exception)
                {

                }
            }
        }

        private void SetStatus(string message)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(new Action(() => lblStatus.Text = "Status: " + message));
            }
            else
            {
                lblStatus.Text = "Status: " + message;
            }
        }

        private void SetUIState(bool isConnected)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetUIState(isConnected)));
                return;
            }
            groupBoxSterowanie.Enabled = isConnected;
            groupBoxEEPROM.Enabled = isConnected;
            comboDevices.Enabled = !isConnected;
            btnRefresh.Enabled = !isConnected;
            btnConnect.Text = isConnected ? "Rozłącz" : "Połącz";

            if (!isConnected)
            {
                txtSerial.Clear();
                txtProductDesc.Clear();
                txtVID.Clear();
                txtPID.Clear();
            }
        }

        private void SetMovementUI(bool enable)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SetMovementUI(enable)));
                return;
            }
            groupBoxTryb.Enabled = enable;
            btnStepLeft.Enabled = enable;
            btnStepRight.Enabled = enable;
            numSteps.Enabled = enable;
            numStepTime.Enabled = enable;
            groupBoxPolaczenie.Enabled = enable;
            groupBoxEEPROM.Enabled = enable;
        }
    }
}
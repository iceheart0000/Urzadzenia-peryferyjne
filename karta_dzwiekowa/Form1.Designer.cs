namespace KartaMuzyczna
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.grpPlaySound = new System.Windows.Forms.GroupBox();
            this.btnStopPlaySound = new System.Windows.Forms.Button();
            this.btnStartPlaySound = new System.Windows.Forms.Button();
            this.grpWMP = new System.Windows.Forms.GroupBox();
            this.btnStopWMP = new System.Windows.Forms.Button();
            this.btnStartWMP = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.grpMCI = new System.Windows.Forms.GroupBox();
            this.btnPauseMCI = new System.Windows.Forms.Button();
            this.btnStopMCI = new System.Windows.Forms.Button();
            this.btnStartMCI = new System.Windows.Forms.Button();
            this.grpWaveOut = new System.Windows.Forms.GroupBox();
            this.btnPauseWave = new System.Windows.Forms.Button();
            this.btnStopWave = new System.Windows.Forms.Button();
            this.btnStartWave = new System.Windows.Forms.Button();
            this.grpDirectSound = new System.Windows.Forms.GroupBox();
            this.lblStatusDSP = new System.Windows.Forms.Label();
            this.btnStopDS = new System.Windows.Forms.Button();
            this.btnStartDS = new System.Windows.Forms.Button();
            this.grpRecording = new System.Windows.Forms.GroupBox();
            this.lblRecStatus = new System.Windows.Forms.Label();
            this.btnSaveRec = new System.Windows.Forms.Button();
            this.btnStopRec = new System.Windows.Forms.Button();
            this.btnStartRec = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grpPlaySound.SuspendLayout();
            this.grpWMP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.grpMCI.SuspendLayout();
            this.grpWaveOut.SuspendLayout();
            this.grpDirectSound.SuspendLayout();
            this.grpRecording.SuspendLayout();
            this.SuspendLayout();

            this.btnLoad.Location = new System.Drawing.Point(16, 15);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 28);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Wybierz plik";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            this.txtFilePath.Location = new System.Drawing.Point(124, 17);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(619, 22);
            this.txtFilePath.TabIndex = 1;

            this.grpPlaySound.Controls.Add(this.btnStopPlaySound);
            this.grpPlaySound.Controls.Add(this.btnStartPlaySound);
            this.grpPlaySound.Location = new System.Drawing.Point(16, 62);
            this.grpPlaySound.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPlaySound.Name = "grpPlaySound";
            this.grpPlaySound.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpPlaySound.Size = new System.Drawing.Size(267, 74);
            this.grpPlaySound.TabIndex = 2;
            this.grpPlaySound.TabStop = false;
            this.grpPlaySound.Text = "1. PlaySound";

            this.btnStopPlaySound.Location = new System.Drawing.Point(117, 25);
            this.btnStopPlaySound.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStopPlaySound.Name = "btnStopPlaySound";
            this.btnStopPlaySound.Size = new System.Drawing.Size(100, 28);
            this.btnStopPlaySound.TabIndex = 1;
            this.btnStopPlaySound.Text = "STOP";
            this.btnStopPlaySound.UseVisualStyleBackColor = true;
            this.btnStopPlaySound.Click += new System.EventHandler(this.btnStopPlaySound_Click);

            this.btnStartPlaySound.Location = new System.Drawing.Point(9, 25);
            this.btnStartPlaySound.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartPlaySound.Name = "btnStartPlaySound";
            this.btnStartPlaySound.Size = new System.Drawing.Size(100, 28);
            this.btnStartPlaySound.TabIndex = 0;
            this.btnStartPlaySound.Text = "START";
            this.btnStartPlaySound.UseVisualStyleBackColor = true;
            this.btnStartPlaySound.Click += new System.EventHandler(this.btnStartPlaySound_Click);

            this.grpWMP.Controls.Add(this.btnStopWMP);
            this.grpWMP.Controls.Add(this.btnStartWMP);
            this.grpWMP.Controls.Add(this.axWindowsMediaPlayer1);
            this.grpWMP.Location = new System.Drawing.Point(307, 62);
            this.grpWMP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpWMP.Name = "grpWMP";
            this.grpWMP.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpWMP.Size = new System.Drawing.Size(437, 246);
            this.grpWMP.TabIndex = 3;
            this.grpWMP.TabStop = false;
            this.grpWMP.Text = "2. Windows Media Player";

            this.btnStopWMP.Location = new System.Drawing.Point(116, 23);
            this.btnStopWMP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStopWMP.Name = "btnStopWMP";
            this.btnStopWMP.Size = new System.Drawing.Size(100, 28);
            this.btnStopWMP.TabIndex = 2;
            this.btnStopWMP.Text = "STOP";
            this.btnStopWMP.UseVisualStyleBackColor = true;
            this.btnStopWMP.Click += new System.EventHandler(this.btnStopWMP_Click);

            this.btnStartWMP.Location = new System.Drawing.Point(8, 23);
            this.btnStartWMP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartWMP.Name = "btnStartWMP";
            this.btnStartWMP.Size = new System.Drawing.Size(100, 28);
            this.btnStartWMP.TabIndex = 1;
            this.btnStartWMP.Text = "START";
            this.btnStartWMP.UseVisualStyleBackColor = true;
            this.btnStartWMP.Click += new System.EventHandler(this.btnStartWMP_Click);

            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(6, 48);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(316, 146);
            this.axWindowsMediaPlayer1.TabIndex = 0;

            this.grpMCI.Controls.Add(this.btnPauseMCI);
            this.grpMCI.Controls.Add(this.btnStopMCI);
            this.grpMCI.Controls.Add(this.btnStartMCI);
            this.grpMCI.Location = new System.Drawing.Point(16, 143);
            this.grpMCI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMCI.Name = "grpMCI";
            this.grpMCI.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMCI.Size = new System.Drawing.Size(267, 98);
            this.grpMCI.TabIndex = 4;
            this.grpMCI.TabStop = false;
            this.grpMCI.Text = "3. MCI";

            this.btnPauseMCI.Location = new System.Drawing.Point(9, 60);
            this.btnPauseMCI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPauseMCI.Name = "btnPauseMCI";
            this.btnPauseMCI.Size = new System.Drawing.Size(208, 28);
            this.btnPauseMCI.TabIndex = 2;
            this.btnPauseMCI.Text = "PAUSE / RESUME";
            this.btnPauseMCI.UseVisualStyleBackColor = true;
            this.btnPauseMCI.Click += new System.EventHandler(this.btnPauseMCI_Click);

            this.btnStopMCI.Location = new System.Drawing.Point(117, 25);
            this.btnStopMCI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStopMCI.Name = "btnStopMCI";
            this.btnStopMCI.Size = new System.Drawing.Size(100, 28);
            this.btnStopMCI.TabIndex = 1;
            this.btnStopMCI.Text = "STOP";
            this.btnStopMCI.UseVisualStyleBackColor = true;
            this.btnStopMCI.Click += new System.EventHandler(this.btnStopMCI_Click);

            this.btnStartMCI.Location = new System.Drawing.Point(9, 25);
            this.btnStartMCI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartMCI.Name = "btnStartMCI";
            this.btnStartMCI.Size = new System.Drawing.Size(100, 28);
            this.btnStartMCI.TabIndex = 0;
            this.btnStartMCI.Text = "START";
            this.btnStartMCI.UseVisualStyleBackColor = true;
            this.btnStartMCI.Click += new System.EventHandler(this.btnStartMCI_Click);

            this.grpWaveOut.Controls.Add(this.btnPauseWave);
            this.grpWaveOut.Controls.Add(this.btnStopWave);
            this.grpWaveOut.Controls.Add(this.btnStartWave);
            this.grpWaveOut.Location = new System.Drawing.Point(16, 249);
            this.grpWaveOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpWaveOut.Name = "grpWaveOut";
            this.grpWaveOut.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpWaveOut.Size = new System.Drawing.Size(267, 98);
            this.grpWaveOut.TabIndex = 5;
            this.grpWaveOut.TabStop = false;
            this.grpWaveOut.Text = "4. WaveOut Write";

            this.btnPauseWave.Location = new System.Drawing.Point(9, 62);
            this.btnPauseWave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPauseWave.Name = "btnPauseWave";
            this.btnPauseWave.Size = new System.Drawing.Size(208, 28);
            this.btnPauseWave.TabIndex = 3;
            this.btnPauseWave.Text = "PAUSE / RESUME";
            this.btnPauseWave.UseVisualStyleBackColor = true;
            this.btnPauseWave.Click += new System.EventHandler(this.btnPauseWave_Click);

            this.btnStopWave.Location = new System.Drawing.Point(117, 25);
            this.btnStopWave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStopWave.Name = "btnStopWave";
            this.btnStopWave.Size = new System.Drawing.Size(100, 28);
            this.btnStopWave.TabIndex = 1;
            this.btnStopWave.Text = "STOP";
            this.btnStopWave.UseVisualStyleBackColor = true;
            this.btnStopWave.Click += new System.EventHandler(this.btnStopWave_Click);

            this.btnStartWave.Location = new System.Drawing.Point(9, 25);
            this.btnStartWave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartWave.Name = "btnStartWave";
            this.btnStartWave.Size = new System.Drawing.Size(100, 28);
            this.btnStartWave.TabIndex = 0;
            this.btnStartWave.Text = "START";
            this.btnStartWave.UseVisualStyleBackColor = true;
            this.btnStartWave.Click += new System.EventHandler(this.btnStartWave_Click);

            this.grpDirectSound.Controls.Add(this.lblStatusDSP);
            this.grpDirectSound.Controls.Add(this.btnStopDS);
            this.grpDirectSound.Controls.Add(this.btnStartDS);
            this.grpDirectSound.Location = new System.Drawing.Point(16, 354);
            this.grpDirectSound.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDirectSound.Name = "grpDirectSound";
            this.grpDirectSound.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDirectSound.Size = new System.Drawing.Size(267, 98);
            this.grpDirectSound.TabIndex = 6;
            this.grpDirectSound.TabStop = false;
            this.grpDirectSound.Text = "5. DirectSound + Dual Channel DSP";

            this.lblStatusDSP.AutoSize = true;
            this.lblStatusDSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblStatusDSP.ForeColor = System.Drawing.Color.Blue;
            this.lblStatusDSP.Location = new System.Drawing.Point(9, 62);
            this.lblStatusDSP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusDSP.Name = "lblStatusDSP";
            this.lblStatusDSP.Size = new System.Drawing.Size(160, 15);
            this.lblStatusDSP.TabIndex = 2;
            this.lblStatusDSP.Text = "L: 0,15kHz | R: 15kHz (Start)";

            this.btnStopDS.Location = new System.Drawing.Point(117, 25);
            this.btnStopDS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStopDS.Name = "btnStopDS";
            this.btnStopDS.Size = new System.Drawing.Size(100, 28);
            this.btnStopDS.TabIndex = 1;
            this.btnStopDS.Text = "STOP";
            this.btnStopDS.UseVisualStyleBackColor = true;
            this.btnStopDS.Click += new System.EventHandler(this.btnStopDS_Click);

            this.btnStartDS.Location = new System.Drawing.Point(9, 25);
            this.btnStartDS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartDS.Name = "btnStartDS";
            this.btnStartDS.Size = new System.Drawing.Size(100, 28);
            this.btnStartDS.TabIndex = 0;
            this.btnStartDS.Text = "START";
            this.btnStartDS.UseVisualStyleBackColor = true;
            this.btnStartDS.Click += new System.EventHandler(this.btnStartDS_Click);

            this.grpRecording.Controls.Add(this.lblRecStatus);
            this.grpRecording.Controls.Add(this.btnSaveRec);
            this.grpRecording.Controls.Add(this.btnStopRec);
            this.grpRecording.Controls.Add(this.btnStartRec);
            this.grpRecording.Location = new System.Drawing.Point(307, 327);
            this.grpRecording.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpRecording.Name = "grpRecording";
            this.grpRecording.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpRecording.Size = new System.Drawing.Size(437, 123);
            this.grpRecording.TabIndex = 7;
            this.grpRecording.TabStop = false;
            this.grpRecording.Text = "Nagrywanie (WaveIn)";

            this.lblRecStatus.AutoSize = true;
            this.lblRecStatus.ForeColor = System.Drawing.Color.Red;
            this.lblRecStatus.Location = new System.Drawing.Point(13, 91);
            this.lblRecStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRecStatus.Name = "lblRecStatus";
            this.lblRecStatus.Size = new System.Drawing.Size(55, 16);
            this.lblRecStatus.TabIndex = 3;
            this.lblRecStatus.Text = "Gotowy.";

            this.btnSaveRec.Location = new System.Drawing.Point(224, 23);
            this.btnSaveRec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveRec.Name = "btnSaveRec";
            this.btnSaveRec.Size = new System.Drawing.Size(100, 28);
            this.btnSaveRec.TabIndex = 2;
            this.btnSaveRec.Text = "ZAPISZ";
            this.btnSaveRec.UseVisualStyleBackColor = true;
            this.btnSaveRec.Click += new System.EventHandler(this.btnSaveRec_Click);

            this.btnStopRec.Location = new System.Drawing.Point(116, 23);
            this.btnStopRec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStopRec.Name = "btnStopRec";
            this.btnStopRec.Size = new System.Drawing.Size(100, 28);
            this.btnStopRec.TabIndex = 1;
            this.btnStopRec.Text = "STOP";
            this.btnStopRec.UseVisualStyleBackColor = true;
            this.btnStopRec.Click += new System.EventHandler(this.btnStopRec_Click);

            this.btnStartRec.Location = new System.Drawing.Point(8, 23);
            this.btnStartRec.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartRec.Name = "btnStartRec";
            this.btnStartRec.Size = new System.Drawing.Size(100, 28);
            this.btnStartRec.TabIndex = 0;
            this.btnStartRec.Text = "NAGRYWAJ";
            this.btnStartRec.UseVisualStyleBackColor = true;
            this.btnStartRec.Click += new System.EventHandler(this.btnStartRec_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 481);
            this.Controls.Add(this.grpRecording);
            this.Controls.Add(this.grpDirectSound);
            this.Controls.Add(this.grpWaveOut);
            this.Controls.Add(this.grpMCI);
            this.Controls.Add(this.grpWMP);
            this.Controls.Add(this.grpPlaySound);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnLoad);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Karta Muzyczna - Stereo DSP";
            this.grpPlaySound.ResumeLayout(false);
            this.grpWMP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.grpMCI.ResumeLayout(false);
            this.grpWaveOut.ResumeLayout(false);
            this.grpDirectSound.ResumeLayout(false);
            this.grpDirectSound.PerformLayout();
            this.grpRecording.ResumeLayout(false);
            this.grpRecording.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.GroupBox grpPlaySound;
        private System.Windows.Forms.Button btnStopPlaySound;
        private System.Windows.Forms.Button btnStartPlaySound;
        private System.Windows.Forms.GroupBox grpWMP;
        private System.Windows.Forms.Button btnStopWMP;
        private System.Windows.Forms.Button btnStartWMP;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.GroupBox grpMCI;
        private System.Windows.Forms.Button btnPauseMCI;
        private System.Windows.Forms.Button btnStopMCI;
        private System.Windows.Forms.Button btnStartMCI;
        private System.Windows.Forms.GroupBox grpWaveOut;
        private System.Windows.Forms.Button btnStopWave;
        private System.Windows.Forms.Button btnStartWave;
        private System.Windows.Forms.Button btnPauseWave;
        private System.Windows.Forms.GroupBox grpDirectSound;
        private System.Windows.Forms.Button btnStopDS;
        private System.Windows.Forms.Button btnStartDS;
        private System.Windows.Forms.Label lblStatusDSP;
        private System.Windows.Forms.GroupBox grpRecording;
        private System.Windows.Forms.Button btnSaveRec;
        private System.Windows.Forms.Button btnStopRec;
        private System.Windows.Forms.Button btnStartRec;
        private System.Windows.Forms.Label lblRecStatus;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
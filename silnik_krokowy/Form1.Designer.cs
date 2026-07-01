namespace SilnikKrokowy
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

        /// <param name="disposing"
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
            this.groupBoxPolaczenie = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.comboDevices = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBoxSterowanie = new System.Windows.Forms.GroupBox();
            this.lblKrokMs = new System.Windows.Forms.Label();
            this.lblLiczbaKrokow = new System.Windows.Forms.Label();
            this.numStepTime = new System.Windows.Forms.NumericUpDown();
            this.numSteps = new System.Windows.Forms.NumericUpDown();
            this.btnStepRight = new System.Windows.Forms.Button();
            this.btnStepLeft = new System.Windows.Forms.Button();
            this.groupBoxTryb = new System.Windows.Forms.GroupBox();
            this.radioHalfStep = new System.Windows.Forms.RadioButton();
            this.radioFullStep = new System.Windows.Forms.RadioButton();
            this.radioWave = new System.Windows.Forms.RadioButton();
            this.groupBoxEEPROM = new System.Windows.Forms.GroupBox();
            this.lblPID = new System.Windows.Forms.Label();
            this.txtPID = new System.Windows.Forms.TextBox();
            this.lblVID = new System.Windows.Forms.Label();
            this.txtVID = new System.Windows.Forms.TextBox();
            this.btnReadEEPROM = new System.Windows.Forms.Button();
            this.txtProductDesc = new System.Windows.Forms.TextBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.lblOpis = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.groupBoxPolaczenie.SuspendLayout();
            this.groupBoxSterowanie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStepTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSteps)).BeginInit();
            this.groupBoxTryb.SuspendLayout();
            this.groupBoxEEPROM.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPolaczenie
            // 
            this.groupBoxPolaczenie.Controls.Add(this.btnRefresh);
            this.groupBoxPolaczenie.Controls.Add(this.btnConnect);
            this.groupBoxPolaczenie.Controls.Add(this.comboDevices);
            this.groupBoxPolaczenie.Location = new System.Drawing.Point(16, 15);
            this.groupBoxPolaczenie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxPolaczenie.Name = "groupBoxPolaczenie";
            this.groupBoxPolaczenie.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxPolaczenie.Size = new System.Drawing.Size(613, 69);
            this.groupBoxPolaczenie.TabIndex = 0;
            this.groupBoxPolaczenie.TabStop = false;
            this.groupBoxPolaczenie.Text = "Połączenie (Zadanie 7)";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(356, 23);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Odśwież";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(464, 23);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(141, 28);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Połącz";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // comboDevices
            // 
            this.comboDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDevices.FormattingEnabled = true;
            this.comboDevices.Location = new System.Drawing.Point(8, 26);
            this.comboDevices.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboDevices.Name = "comboDevices";
            this.comboDevices.Size = new System.Drawing.Size(339, 24);
            this.comboDevices.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.Location = new System.Drawing.Point(16, 507);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(613, 28);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status: Nie połączono";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxSterowanie
            // 
            this.groupBoxSterowanie.Controls.Add(this.lblKrokMs);
            this.groupBoxSterowanie.Controls.Add(this.lblLiczbaKrokow);
            this.groupBoxSterowanie.Controls.Add(this.numStepTime);
            this.groupBoxSterowanie.Controls.Add(this.numSteps);
            this.groupBoxSterowanie.Controls.Add(this.btnStepRight);
            this.groupBoxSterowanie.Controls.Add(this.btnStepLeft);
            this.groupBoxSterowanie.Controls.Add(this.groupBoxTryb);
            this.groupBoxSterowanie.Enabled = false;
            this.groupBoxSterowanie.Location = new System.Drawing.Point(16, 91);
            this.groupBoxSterowanie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSterowanie.Name = "groupBoxSterowanie";
            this.groupBoxSterowanie.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxSterowanie.Size = new System.Drawing.Size(613, 185);
            this.groupBoxSterowanie.TabIndex = 2;
            this.groupBoxSterowanie.TabStop = false;
            this.groupBoxSterowanie.Text = "Sterowanie Silnikiem (Zadanie 5)";
            // 
            // lblKrokMs
            // 
            this.lblKrokMs.AutoSize = true;
            this.lblKrokMs.Location = new System.Drawing.Point(411, 63);
            this.lblKrokMs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKrokMs.Name = "lblKrokMs";
            this.lblKrokMs.Size = new System.Drawing.Size(102, 16);
            this.lblKrokMs.TabIndex = 6;
            this.lblKrokMs.Text = "Czas kroku [ms]";
            // 
            // lblLiczbaKrokow
            // 
            this.lblLiczbaKrokow.AutoSize = true;
            this.lblLiczbaKrokow.Location = new System.Drawing.Point(411, 31);
            this.lblLiczbaKrokow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLiczbaKrokow.Name = "lblLiczbaKrokow";
            this.lblLiczbaKrokow.Size = new System.Drawing.Size(110, 16);
            this.lblLiczbaKrokow.TabIndex = 5;
            this.lblLiczbaKrokow.Text = "Liczba kroków [n]";
            // 
            // numStepTime
            // 
            this.numStepTime.Location = new System.Drawing.Point(535, 60);
            this.numStepTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numStepTime.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numStepTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStepTime.Name = "numStepTime";
            this.numStepTime.Size = new System.Drawing.Size(71, 22);
            this.numStepTime.TabIndex = 4;
            this.numStepTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numSteps
            // 
            this.numSteps.Location = new System.Drawing.Point(535, 28);
            this.numSteps.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numSteps.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSteps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSteps.Name = "numSteps";
            this.numSteps.Size = new System.Drawing.Size(71, 22);
            this.numSteps.TabIndex = 3;
            this.numSteps.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnStepRight
            // 
            this.btnStepRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStepRight.Location = new System.Drawing.Point(411, 108);
            this.btnStepRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStepRight.Name = "btnStepRight";
            this.btnStepRight.Size = new System.Drawing.Size(195, 69);
            this.btnStepRight.TabIndex = 2;
            this.btnStepRight.Text = "N Kroków w Prawo >>";
            this.btnStepRight.UseVisualStyleBackColor = true;
            this.btnStepRight.Click += new System.EventHandler(this.btnStepRight_Click);
            // 
            // btnStepLeft
            // 
            this.btnStepLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStepLeft.Location = new System.Drawing.Point(208, 108);
            this.btnStepLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStepLeft.Name = "btnStepLeft";
            this.btnStepLeft.Size = new System.Drawing.Size(195, 69);
            this.btnStepLeft.TabIndex = 1;
            this.btnStepLeft.Text = "<< N Kroków w Lewo";
            this.btnStepLeft.UseVisualStyleBackColor = true;
            this.btnStepLeft.Click += new System.EventHandler(this.btnStepLeft_Click);
            // 
            // groupBoxTryb
            // 
            this.groupBoxTryb.Controls.Add(this.radioHalfStep);
            this.groupBoxTryb.Controls.Add(this.radioFullStep);
            this.groupBoxTryb.Controls.Add(this.radioWave);
            this.groupBoxTryb.Location = new System.Drawing.Point(8, 23);
            this.groupBoxTryb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTryb.Name = "groupBoxTryb";
            this.groupBoxTryb.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTryb.Size = new System.Drawing.Size(192, 154);
            this.groupBoxTryb.TabIndex = 0;
            this.groupBoxTryb.TabStop = false;
            this.groupBoxTryb.Text = "Tryb Sterowania";
            // 
            // radioHalfStep
            // 
            this.radioHalfStep.AutoSize = true;
            this.radioHalfStep.Location = new System.Drawing.Point(8, 108);
            this.radioHalfStep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioHalfStep.Name = "radioHalfStep";
            this.radioHalfStep.Size = new System.Drawing.Size(102, 20);
            this.radioHalfStep.TabIndex = 2;
            this.radioHalfStep.Text = "Półkrokowe";
            this.radioHalfStep.UseVisualStyleBackColor = true;
            // 
            // radioFullStep
            // 
            this.radioFullStep.AutoSize = true;
            this.radioFullStep.Checked = true;
            this.radioFullStep.Location = new System.Drawing.Point(8, 69);
            this.radioFullStep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioFullStep.Name = "radioFullStep";
            this.radioFullStep.Size = new System.Drawing.Size(117, 20);
            this.radioFullStep.TabIndex = 1;
            this.radioFullStep.TabStop = true;
            this.radioFullStep.Text = "Pełnokrokowe";
            this.radioFullStep.UseVisualStyleBackColor = true;
            // 
            // radioWave
            // 
            this.radioWave.AutoSize = true;
            this.radioWave.Location = new System.Drawing.Point(8, 30);
            this.radioWave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioWave.Name = "radioWave";
            this.radioWave.Size = new System.Drawing.Size(72, 20);
            this.radioWave.TabIndex = 0;
            this.radioWave.Text = "Falowe";
            this.radioWave.UseVisualStyleBackColor = true;
            // 
            // groupBoxEEPROM
            // 
            this.groupBoxEEPROM.Controls.Add(this.lblPID);
            this.groupBoxEEPROM.Controls.Add(this.txtPID);
            this.groupBoxEEPROM.Controls.Add(this.lblVID);
            this.groupBoxEEPROM.Controls.Add(this.txtVID);
            this.groupBoxEEPROM.Controls.Add(this.btnReadEEPROM);
            this.groupBoxEEPROM.Controls.Add(this.txtProductDesc);
            this.groupBoxEEPROM.Controls.Add(this.txtSerial);
            this.groupBoxEEPROM.Controls.Add(this.lblOpis);
            this.groupBoxEEPROM.Controls.Add(this.lblSerial);
            this.groupBoxEEPROM.Enabled = false;
            this.groupBoxEEPROM.Location = new System.Drawing.Point(16, 283);
            this.groupBoxEEPROM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxEEPROM.Name = "groupBoxEEPROM";
            this.groupBoxEEPROM.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxEEPROM.Size = new System.Drawing.Size(613, 209);
            this.groupBoxEEPROM.TabIndex = 3;
            this.groupBoxEEPROM.TabStop = false;
            this.groupBoxEEPROM.Text = "Pamięć EEPROM (Zadanie 6)";
            // 
            // lblPID
            // 
            this.lblPID.AutoSize = true;
            this.lblPID.Location = new System.Drawing.Point(311, 98);
            this.lblPID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPID.Name = "lblPID";
            this.lblPID.Size = new System.Drawing.Size(32, 16);
            this.lblPID.TabIndex = 8;
            this.lblPID.Text = "PID:";
            // 
            // txtPID
            // 
            this.txtPID.Location = new System.Drawing.Point(356, 95);
            this.txtPID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPID.Name = "txtPID";
            this.txtPID.ReadOnly = true;
            this.txtPID.Size = new System.Drawing.Size(248, 22);
            this.txtPID.TabIndex = 9;
            this.txtPID.TabStop = false;
            // 
            // lblVID
            // 
            this.lblVID.AutoSize = true;
            this.lblVID.Location = new System.Drawing.Point(8, 98);
            this.lblVID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVID.Name = "lblVID";
            this.lblVID.Size = new System.Drawing.Size(32, 16);
            this.lblVID.TabIndex = 6;
            this.lblVID.Text = "VID:";
            // 
            // txtVID
            // 
            this.txtVID.Location = new System.Drawing.Point(123, 95);
            this.txtVID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVID.Name = "txtVID";
            this.txtVID.ReadOnly = true;
            this.txtVID.Size = new System.Drawing.Size(179, 22);
            this.txtVID.TabIndex = 7;
            this.txtVID.TabStop = false;
            // 
            // btnReadEEPROM
            // 
            this.btnReadEEPROM.Location = new System.Drawing.Point(448, 158);
            this.btnReadEEPROM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReadEEPROM.Name = "btnReadEEPROM";
            this.btnReadEEPROM.Size = new System.Drawing.Size(141, 28);
            this.btnReadEEPROM.TabIndex = 4;
            this.btnReadEEPROM.Text = "Odczytaj EEPROM";
            this.btnReadEEPROM.UseVisualStyleBackColor = true;
            this.btnReadEEPROM.Click += new System.EventHandler(this.btnReadEEPROM_Click);
            // 
            // txtProductDesc
            // 
            this.txtProductDesc.Location = new System.Drawing.Point(123, 63);
            this.txtProductDesc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProductDesc.Name = "txtProductDesc";
            this.txtProductDesc.Size = new System.Drawing.Size(481, 22);
            this.txtProductDesc.TabIndex = 3;
            // 
            // txtSerial
            // 
            this.txtSerial.Location = new System.Drawing.Point(123, 31);
            this.txtSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(481, 22);
            this.txtSerial.TabIndex = 2;
            // 
            // lblOpis
            // 
            this.lblOpis.AutoSize = true;
            this.lblOpis.Location = new System.Drawing.Point(8, 66);
            this.lblOpis.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOpis.Name = "lblOpis";
            this.lblOpis.Size = new System.Drawing.Size(94, 16);
            this.lblOpis.TabIndex = 1;
            this.lblOpis.Text = "Opis Produktu:";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(8, 34);
            this.lblSerial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(98, 16);
            this.lblSerial.TabIndex = 0;
            this.lblSerial.Text = "Numer Seryjny:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 546);
            this.Controls.Add(this.groupBoxEEPROM);
            this.Controls.Add(this.groupBoxSterowanie);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBoxPolaczenie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sterownik Silnika Krokowego FT245BM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxPolaczenie.ResumeLayout(false);
            this.groupBoxSterowanie.ResumeLayout(false);
            this.groupBoxSterowanie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStepTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSteps)).EndInit();
            this.groupBoxTryb.ResumeLayout(false);
            this.groupBoxTryb.PerformLayout();
            this.groupBoxEEPROM.ResumeLayout(false);
            this.groupBoxEEPROM.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPolaczenie;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox comboDevices;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBoxSterowanie;
        private System.Windows.Forms.Button btnStepRight;
        private System.Windows.Forms.Button btnStepLeft;
        private System.Windows.Forms.GroupBox groupBoxTryb;
        private System.Windows.Forms.RadioButton radioHalfStep;
        private System.Windows.Forms.RadioButton radioFullStep;
        private System.Windows.Forms.RadioButton radioWave;
        private System.Windows.Forms.Label lblKrokMs;
        private System.Windows.Forms.Label lblLiczbaKrokow;
        private System.Windows.Forms.NumericUpDown numStepTime;
        private System.Windows.Forms.NumericUpDown numSteps;
        private System.Windows.Forms.GroupBox groupBoxEEPROM;
        private System.Windows.Forms.Button btnReadEEPROM;
        private System.Windows.Forms.TextBox txtProductDesc;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label lblOpis;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblVID;
        private System.Windows.Forms.TextBox txtVID;
        private System.Windows.Forms.Label lblPID;
        private System.Windows.Forms.TextBox txtPID;
    }
}
namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    partial class OptionI2of5Dialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlLength = new System.Windows.Forms.Panel();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.cbxLengthType = new System.Windows.Forms.ComboBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.cbxCheckDigitVerification = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkTransmitCheckDigit = new System.Windows.Forms.CheckBox();
            this.chkConvertI2of5ToEan13 = new System.Windows.Forms.CheckBox();
            this.chkReducedQuietZone = new System.Windows.Forms.CheckBox();
            this.pnlLength.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(236, 41);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Set Option";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlLength
            // 
            this.pnlLength.Controls.Add(this.numMax);
            this.pnlLength.Controls.Add(this.numMin);
            this.pnlLength.Controls.Add(this.cbxLengthType);
            this.pnlLength.Controls.Add(this.lblMax);
            this.pnlLength.Controls.Add(this.label2);
            this.pnlLength.Controls.Add(this.lblMin);
            this.pnlLength.Location = new System.Drawing.Point(5, 204);
            this.pnlLength.Name = "pnlLength";
            this.pnlLength.Size = new System.Drawing.Size(275, 106);
            this.pnlLength.TabIndex = 12;
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(196, 78);
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(70, 21);
            this.numMax.TabIndex = 8;
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(196, 52);
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(70, 21);
            this.numMin.TabIndex = 7;
            // 
            // cbxLengthType
            // 
            this.cbxLengthType.FormattingEnabled = true;
            this.cbxLengthType.Location = new System.Drawing.Point(6, 26);
            this.cbxLengthType.Name = "cbxLengthType";
            this.cbxLengthType.Size = new System.Drawing.Size(260, 20);
            this.cbxLengthType.TabIndex = 4;
            this.cbxLengthType.SelectedIndexChanged += new System.EventHandler(this.cbxLengthType_SelectedIndexChanged);
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(118, 82);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(72, 12);
            this.lblMax.TabIndex = 6;
            this.lblMax.Text = "Max Length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Set Length Type";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(122, 56);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(68, 12);
            this.lblMin.TabIndex = 5;
            this.lblMin.Text = "Min Length";
            // 
            // cbxCheckDigitVerification
            // 
            this.cbxCheckDigitVerification.FormattingEnabled = true;
            this.cbxCheckDigitVerification.Location = new System.Drawing.Point(12, 107);
            this.cbxCheckDigitVerification.Name = "cbxCheckDigitVerification";
            this.cbxCheckDigitVerification.Size = new System.Drawing.Size(260, 20);
            this.cbxCheckDigitVerification.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "I2of5 Check Digit Verification";
            // 
            // chkTransmitCheckDigit
            // 
            this.chkTransmitCheckDigit.AutoSize = true;
            this.chkTransmitCheckDigit.Location = new System.Drawing.Point(12, 12);
            this.chkTransmitCheckDigit.Name = "chkTransmitCheckDigit";
            this.chkTransmitCheckDigit.Size = new System.Drawing.Size(171, 16);
            this.chkTransmitCheckDigit.TabIndex = 9;
            this.chkTransmitCheckDigit.Text = "Transmit I2of5 Check Digit";
            this.chkTransmitCheckDigit.UseVisualStyleBackColor = true;
            // 
            // chkConvertI2of5ToEan13
            // 
            this.chkConvertI2of5ToEan13.AutoSize = true;
            this.chkConvertI2of5ToEan13.Location = new System.Drawing.Point(12, 34);
            this.chkConvertI2of5ToEan13.Name = "chkConvertI2of5ToEan13";
            this.chkConvertI2of5ToEan13.Size = new System.Drawing.Size(157, 16);
            this.chkConvertI2of5ToEan13.TabIndex = 14;
            this.chkConvertI2of5ToEan13.Text = "Convert I2of5 to EAN-13";
            this.chkConvertI2of5ToEan13.UseVisualStyleBackColor = true;
            // 
            // chkReducedQuietZone
            // 
            this.chkReducedQuietZone.AutoSize = true;
            this.chkReducedQuietZone.Location = new System.Drawing.Point(12, 56);
            this.chkReducedQuietZone.Name = "chkReducedQuietZone";
            this.chkReducedQuietZone.Size = new System.Drawing.Size(140, 16);
            this.chkReducedQuietZone.TabIndex = 15;
            this.chkReducedQuietZone.Text = "Reduced Quiet Zone";
            this.chkReducedQuietZone.UseVisualStyleBackColor = true;
            // 
            // OptionI2of5Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.chkReducedQuietZone);
            this.Controls.Add(this.chkConvertI2of5ToEan13);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlLength);
            this.Controls.Add(this.cbxCheckDigitVerification);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkTransmitCheckDigit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionI2of5Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OptionI2of5Dialog";
            this.Load += new System.EventHandler(this.OptionI2of5Dialog_Load);
            this.pnlLength.ResumeLayout(false);
            this.pnlLength.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlLength;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.ComboBox cbxLengthType;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.ComboBox cbxCheckDigitVerification;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkTransmitCheckDigit;
        private System.Windows.Forms.CheckBox chkConvertI2of5ToEan13;
        private System.Windows.Forms.CheckBox chkReducedQuietZone;
    }
}
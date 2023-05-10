namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    partial class OptionCode39Dialog
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
            this.chkTriopticCode39 = new System.Windows.Forms.CheckBox();
            this.chkConvert39To32 = new System.Windows.Forms.CheckBox();
            this.chkCode32Prefix = new System.Windows.Forms.CheckBox();
            this.chkCheckDigitVerification = new System.Windows.Forms.CheckBox();
            this.chkTransmitCheckDigit = new System.Windows.Forms.CheckBox();
            this.chkCode39FullAscii = new System.Windows.Forms.CheckBox();
            this.pnlLength = new System.Windows.Forms.Panel();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.cbxLengthType = new System.Windows.Forms.ComboBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkBufferCode39 = new System.Windows.Forms.CheckBox();
            this.chkReducedQuietZone = new System.Windows.Forms.CheckBox();
            this.pnlLength.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            this.SuspendLayout();
            // 
            // chkTriopticCode39
            // 
            this.chkTriopticCode39.AutoSize = true;
            this.chkTriopticCode39.Location = new System.Drawing.Point(12, 12);
            this.chkTriopticCode39.Name = "chkTriopticCode39";
            this.chkTriopticCode39.Size = new System.Drawing.Size(116, 16);
            this.chkTriopticCode39.TabIndex = 1;
            this.chkTriopticCode39.Text = "Trioptic Code 39";
            this.chkTriopticCode39.UseVisualStyleBackColor = true;
            // 
            // chkConvert39To32
            // 
            this.chkConvert39To32.AutoSize = true;
            this.chkConvert39To32.Location = new System.Drawing.Point(12, 34);
            this.chkConvert39To32.Name = "chkConvert39To32";
            this.chkConvert39To32.Size = new System.Drawing.Size(181, 16);
            this.chkConvert39To32.TabIndex = 2;
            this.chkConvert39To32.Text = "Convert Code 39 to Code 32";
            this.chkConvert39To32.UseVisualStyleBackColor = true;
            // 
            // chkCode32Prefix
            // 
            this.chkCode32Prefix.AutoSize = true;
            this.chkCode32Prefix.Location = new System.Drawing.Point(12, 56);
            this.chkCode32Prefix.Name = "chkCode32Prefix";
            this.chkCode32Prefix.Size = new System.Drawing.Size(106, 16);
            this.chkCode32Prefix.TabIndex = 3;
            this.chkCode32Prefix.Text = "Code 32 Prefix";
            this.chkCode32Prefix.UseVisualStyleBackColor = true;
            // 
            // chkCheckDigitVerification
            // 
            this.chkCheckDigitVerification.AutoSize = true;
            this.chkCheckDigitVerification.Location = new System.Drawing.Point(12, 78);
            this.chkCheckDigitVerification.Name = "chkCheckDigitVerification";
            this.chkCheckDigitVerification.Size = new System.Drawing.Size(204, 16);
            this.chkCheckDigitVerification.TabIndex = 4;
            this.chkCheckDigitVerification.Text = "Code 39 Check Digit Verification";
            this.chkCheckDigitVerification.UseVisualStyleBackColor = true;
            // 
            // chkTransmitCheckDigit
            // 
            this.chkTransmitCheckDigit.AutoSize = true;
            this.chkTransmitCheckDigit.Location = new System.Drawing.Point(12, 100);
            this.chkTransmitCheckDigit.Name = "chkTransmitCheckDigit";
            this.chkTransmitCheckDigit.Size = new System.Drawing.Size(192, 16);
            this.chkTransmitCheckDigit.TabIndex = 5;
            this.chkTransmitCheckDigit.Text = "Trasnmit Code 39 Check Digit";
            this.chkTransmitCheckDigit.UseVisualStyleBackColor = true;
            // 
            // chkCode39FullAscii
            // 
            this.chkCode39FullAscii.AutoSize = true;
            this.chkCode39FullAscii.Location = new System.Drawing.Point(12, 122);
            this.chkCode39FullAscii.Name = "chkCode39FullAscii";
            this.chkCode39FullAscii.Size = new System.Drawing.Size(129, 16);
            this.chkCode39FullAscii.TabIndex = 6;
            this.chkCode39FullAscii.Text = "Code 39 Full ASCII";
            this.chkCode39FullAscii.UseVisualStyleBackColor = true;
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
            this.pnlLength.TabIndex = 8;
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
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(236, 41);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Set Option";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkBufferCode39
            // 
            this.chkBufferCode39.AutoSize = true;
            this.chkBufferCode39.Location = new System.Drawing.Point(12, 144);
            this.chkBufferCode39.Name = "chkBufferCode39";
            this.chkBufferCode39.Size = new System.Drawing.Size(106, 16);
            this.chkBufferCode39.TabIndex = 10;
            this.chkBufferCode39.Text = "Buffer Code 39";
            this.chkBufferCode39.UseVisualStyleBackColor = true;
            // 
            // chkReducedQuietZone
            // 
            this.chkReducedQuietZone.AutoSize = true;
            this.chkReducedQuietZone.Location = new System.Drawing.Point(12, 166);
            this.chkReducedQuietZone.Name = "chkReducedQuietZone";
            this.chkReducedQuietZone.Size = new System.Drawing.Size(140, 16);
            this.chkReducedQuietZone.TabIndex = 11;
            this.chkReducedQuietZone.Text = "Reduced Quiet Zone";
            this.chkReducedQuietZone.UseVisualStyleBackColor = true;
            // 
            // OptionCode39Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.chkReducedQuietZone);
            this.Controls.Add(this.chkBufferCode39);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlLength);
            this.Controls.Add(this.chkCode39FullAscii);
            this.Controls.Add(this.chkTransmitCheckDigit);
            this.Controls.Add(this.chkCheckDigitVerification);
            this.Controls.Add(this.chkCode32Prefix);
            this.Controls.Add(this.chkConvert39To32);
            this.Controls.Add(this.chkTriopticCode39);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionCode39Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OptionCode39Dialog";
            this.Load += new System.EventHandler(this.OptionCode39Dialog_Load);
            this.pnlLength.ResumeLayout(false);
            this.pnlLength.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTriopticCode39;
        private System.Windows.Forms.CheckBox chkConvert39To32;
        private System.Windows.Forms.CheckBox chkCode32Prefix;
        private System.Windows.Forms.CheckBox chkCheckDigitVerification;
        private System.Windows.Forms.CheckBox chkTransmitCheckDigit;
        private System.Windows.Forms.CheckBox chkCode39FullAscii;
        private System.Windows.Forms.Panel pnlLength;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.ComboBox cbxLengthType;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkBufferCode39;
        private System.Windows.Forms.CheckBox chkReducedQuietZone;
    }
}
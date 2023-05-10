namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    partial class OptionM2of5Dialog
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
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.chkCheckDigit = new System.Windows.Forms.CheckBox();
            this.chkTransmitCheckDigit = new System.Windows.Forms.CheckBox();
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
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(12, 12);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(70, 16);
            this.chkEnable.TabIndex = 9;
            this.chkEnable.Text = "Enabled";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // chkCheckDigit
            // 
            this.chkCheckDigit.AutoSize = true;
            this.chkCheckDigit.Location = new System.Drawing.Point(12, 34);
            this.chkCheckDigit.Name = "chkCheckDigit";
            this.chkCheckDigit.Size = new System.Drawing.Size(88, 16);
            this.chkCheckDigit.TabIndex = 14;
            this.chkCheckDigit.Text = "Check Digit";
            this.chkCheckDigit.UseVisualStyleBackColor = true;
            // 
            // chkTransmitCheckDigit
            // 
            this.chkTransmitCheckDigit.AutoSize = true;
            this.chkTransmitCheckDigit.Location = new System.Drawing.Point(12, 56);
            this.chkTransmitCheckDigit.Name = "chkTransmitCheckDigit";
            this.chkTransmitCheckDigit.Size = new System.Drawing.Size(215, 16);
            this.chkTransmitCheckDigit.TabIndex = 15;
            this.chkTransmitCheckDigit.Text = "Transmit Matrix 2 of 5 Check Digit";
            this.chkTransmitCheckDigit.UseVisualStyleBackColor = true;
            // 
            // OptionM2of5Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.chkTransmitCheckDigit);
            this.Controls.Add(this.chkCheckDigit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlLength);
            this.Controls.Add(this.chkEnable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionM2of5Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OptionM2of5Dialog";
            this.Load += new System.EventHandler(this.OptionM2of5Dialog_Load);
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
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.CheckBox chkCheckDigit;
        private System.Windows.Forms.CheckBox chkTransmitCheckDigit;
    }
}
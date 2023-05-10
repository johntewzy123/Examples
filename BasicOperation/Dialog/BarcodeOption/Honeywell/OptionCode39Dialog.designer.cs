namespace BasicOperation.Dialog.BarcodeOption.Honeywell
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
            this.pnlLength = new System.Windows.Forms.Panel();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkStartStopChar = new System.Windows.Forms.CheckBox();
            this.cbxCheckChar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAppend = new System.Windows.Forms.CheckBox();
            this.chkCode32 = new System.Windows.Forms.CheckBox();
            this.chkFullAscii = new System.Windows.Forms.CheckBox();
            this.chkTrioptic = new System.Windows.Forms.CheckBox();
            this.pnlLength.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLength
            // 
            this.pnlLength.Controls.Add(this.numMax);
            this.pnlLength.Controls.Add(this.numMin);
            this.pnlLength.Controls.Add(this.lblMax);
            this.pnlLength.Controls.Add(this.lblMin);
            this.pnlLength.Location = new System.Drawing.Point(4, 253);
            this.pnlLength.Name = "pnlLength";
            this.pnlLength.Size = new System.Drawing.Size(275, 54);
            this.pnlLength.TabIndex = 17;
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(197, 29);
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(70, 21);
            this.numMax.TabIndex = 8;
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(197, 3);
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(70, 21);
            this.numMin.TabIndex = 7;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(119, 33);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(72, 12);
            this.lblMax.TabIndex = 6;
            this.lblMax.Text = "Max Length";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(123, 7);
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
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Set Option";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkStartStopChar
            // 
            this.chkStartStopChar.AutoSize = true;
            this.chkStartStopChar.Location = new System.Drawing.Point(12, 12);
            this.chkStartStopChar.Name = "chkStartStopChar";
            this.chkStartStopChar.Size = new System.Drawing.Size(115, 16);
            this.chkStartStopChar.TabIndex = 18;
            this.chkStartStopChar.Text = "Start/Stop Char.";
            this.chkStartStopChar.UseVisualStyleBackColor = true;
            // 
            // cbxCheckChar
            // 
            this.cbxCheckChar.FormattingEnabled = true;
            this.cbxCheckChar.Location = new System.Drawing.Point(11, 56);
            this.cbxCheckChar.Name = "cbxCheckChar";
            this.cbxCheckChar.Size = new System.Drawing.Size(260, 20);
            this.cbxCheckChar.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Check Char.";
            // 
            // chkAppend
            // 
            this.chkAppend.AutoSize = true;
            this.chkAppend.Location = new System.Drawing.Point(12, 87);
            this.chkAppend.Name = "chkAppend";
            this.chkAppend.Size = new System.Drawing.Size(67, 16);
            this.chkAppend.TabIndex = 21;
            this.chkAppend.Text = "Append";
            this.chkAppend.UseVisualStyleBackColor = true;
            // 
            // chkCode32
            // 
            this.chkCode32.AutoSize = true;
            this.chkCode32.Location = new System.Drawing.Point(11, 131);
            this.chkCode32.Name = "chkCode32";
            this.chkCode32.Size = new System.Drawing.Size(215, 16);
            this.chkCode32.TabIndex = 22;
            this.chkCode32.Text = "Code 32 Pharmaceutical (PARAF)";
            this.chkCode32.UseVisualStyleBackColor = true;
            // 
            // chkFullAscii
            // 
            this.chkFullAscii.AutoSize = true;
            this.chkFullAscii.Location = new System.Drawing.Point(12, 109);
            this.chkFullAscii.Name = "chkFullAscii";
            this.chkFullAscii.Size = new System.Drawing.Size(79, 16);
            this.chkFullAscii.TabIndex = 23;
            this.chkFullAscii.Text = "Full ASCII";
            this.chkFullAscii.UseVisualStyleBackColor = true;
            // 
            // chkTrioptic
            // 
            this.chkTrioptic.AutoSize = true;
            this.chkTrioptic.Location = new System.Drawing.Point(11, 153);
            this.chkTrioptic.Name = "chkTrioptic";
            this.chkTrioptic.Size = new System.Drawing.Size(100, 16);
            this.chkTrioptic.TabIndex = 24;
            this.chkTrioptic.Text = "Trioptic Code";
            this.chkTrioptic.UseVisualStyleBackColor = true;
            // 
            // OptionCode39Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.chkTrioptic);
            this.Controls.Add(this.chkFullAscii);
            this.Controls.Add(this.chkCode32);
            this.Controls.Add(this.chkAppend);
            this.Controls.Add(this.cbxCheckChar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkStartStopChar);
            this.Controls.Add(this.pnlLength);
            this.Controls.Add(this.btnSave);
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

        private System.Windows.Forms.Panel pnlLength;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkStartStopChar;
        private System.Windows.Forms.ComboBox cbxCheckChar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAppend;
        private System.Windows.Forms.CheckBox chkCode32;
        private System.Windows.Forms.CheckBox chkFullAscii;
        private System.Windows.Forms.CheckBox chkTrioptic;
    }
}
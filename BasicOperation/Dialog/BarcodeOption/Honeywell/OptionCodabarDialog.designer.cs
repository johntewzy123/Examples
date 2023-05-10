namespace BasicOperation.Dialog.BarcodeOption.Honeywell
{
    partial class OptionCodabarDialog
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
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.chkStartStopChar = new System.Windows.Forms.CheckBox();
            this.cbxCheckChar = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxConcatenation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Set Option";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.pnlLength.TabIndex = 15;
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
            // chkStartStopChar
            // 
            this.chkStartStopChar.AutoSize = true;
            this.chkStartStopChar.Location = new System.Drawing.Point(12, 12);
            this.chkStartStopChar.Name = "chkStartStopChar";
            this.chkStartStopChar.Size = new System.Drawing.Size(115, 16);
            this.chkStartStopChar.TabIndex = 16;
            this.chkStartStopChar.Text = "Start/Stop Char.";
            this.chkStartStopChar.UseVisualStyleBackColor = true;
            // 
            // cbxCheckChar
            // 
            this.cbxCheckChar.FormattingEnabled = true;
            this.cbxCheckChar.Location = new System.Drawing.Point(11, 60);
            this.cbxCheckChar.Name = "cbxCheckChar";
            this.cbxCheckChar.Size = new System.Drawing.Size(260, 20);
            this.cbxCheckChar.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "Check Char.";
            // 
            // cbxConcatenation
            // 
            this.cbxConcatenation.FormattingEnabled = true;
            this.cbxConcatenation.Location = new System.Drawing.Point(12, 113);
            this.cbxConcatenation.Name = "cbxConcatenation";
            this.cbxConcatenation.Size = new System.Drawing.Size(260, 20);
            this.cbxConcatenation.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Concatenation";
            // 
            // OptionCodabarDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.cbxConcatenation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCheckChar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkStartStopChar);
            this.Controls.Add(this.pnlLength);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionCodabarDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OptionCodabarDialog";
            this.Load += new System.EventHandler(this.OptionCodabarDialog_Load);
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
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.CheckBox chkStartStopChar;
        private System.Windows.Forms.ComboBox cbxCheckChar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxConcatenation;
        private System.Windows.Forms.Label label2;
    }
}
namespace BasicOperation.Dialog.BarcodeOption.Zebra
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
            this.cbxLengthType = new System.Windows.Forms.ComboBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.chkNOTIS = new System.Windows.Forms.CheckBox();
            this.chkCLSI = new System.Windows.Forms.CheckBox();
            this.cbxCharDetection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // chkNOTIS
            // 
            this.chkNOTIS.AutoSize = true;
            this.chkNOTIS.Location = new System.Drawing.Point(12, 34);
            this.chkNOTIS.Name = "chkNOTIS";
            this.chkNOTIS.Size = new System.Drawing.Size(103, 16);
            this.chkNOTIS.TabIndex = 11;
            this.chkNOTIS.Text = "NOTIS Editing";
            this.chkNOTIS.UseVisualStyleBackColor = true;
            // 
            // chkCLSI
            // 
            this.chkCLSI.AutoSize = true;
            this.chkCLSI.Location = new System.Drawing.Point(12, 12);
            this.chkCLSI.Name = "chkCLSI";
            this.chkCLSI.Size = new System.Drawing.Size(93, 16);
            this.chkCLSI.TabIndex = 10;
            this.chkCLSI.Text = "CLSI Editing";
            this.chkCLSI.UseVisualStyleBackColor = true;
            // 
            // cbxCharDetection
            // 
            this.cbxCharDetection.FormattingEnabled = true;
            this.cbxCharDetection.Location = new System.Drawing.Point(11, 94);
            this.cbxCharDetection.Name = "cbxCharDetection";
            this.cbxCharDetection.Size = new System.Drawing.Size(260, 20);
            this.cbxCharDetection.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 34);
            this.label1.TabIndex = 14;
            this.label1.Text = "Codabar Upper or Lower Case Start/Stop Characters Detection";
            // 
            // OptionCodabarDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.cbxCharDetection);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlLength);
            this.Controls.Add(this.chkNOTIS);
            this.Controls.Add(this.chkCLSI);
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
        private System.Windows.Forms.ComboBox cbxLengthType;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.CheckBox chkNOTIS;
        private System.Windows.Forms.CheckBox chkCLSI;
        private System.Windows.Forms.ComboBox cbxCharDetection;
        private System.Windows.Forms.Label label1;
    }
}
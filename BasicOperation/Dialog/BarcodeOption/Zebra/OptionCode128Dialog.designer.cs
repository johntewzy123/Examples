namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    partial class OptionCode128Dialog
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
            this.cbxRedundancy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkCheckIsbtTable = new System.Windows.Forms.CheckBox();
            this.chkConcatenation = new System.Windows.Forms.CheckBox();
            this.chkIsbt128 = new System.Windows.Forms.CheckBox();
            this.chkGS1128 = new System.Windows.Forms.CheckBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.pnlLength = new System.Windows.Forms.Panel();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.cbxLengthType = new System.Windows.Forms.ComboBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.chkReducedQuietZone = new System.Windows.Forms.CheckBox();
            this.chkIgnoreCode128FNC4 = new System.Windows.Forms.CheckBox();
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
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Set Option";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxRedundancy
            // 
            this.cbxRedundancy.FormattingEnabled = true;
            this.cbxRedundancy.Location = new System.Drawing.Point(12, 182);
            this.cbxRedundancy.Name = "cbxRedundancy";
            this.cbxRedundancy.Size = new System.Drawing.Size(260, 20);
            this.cbxRedundancy.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "ISBT Concatenation Redundancy";
            // 
            // chkCheckIsbtTable
            // 
            this.chkCheckIsbtTable.AutoSize = true;
            this.chkCheckIsbtTable.Location = new System.Drawing.Point(12, 100);
            this.chkCheckIsbtTable.Name = "chkCheckIsbtTable";
            this.chkCheckIsbtTable.Size = new System.Drawing.Size(127, 16);
            this.chkCheckIsbtTable.TabIndex = 19;
            this.chkCheckIsbtTable.Text = "Check ISBT Table";
            this.chkCheckIsbtTable.UseVisualStyleBackColor = true;
            // 
            // chkConcatenation
            // 
            this.chkConcatenation.AutoSize = true;
            this.chkConcatenation.Location = new System.Drawing.Point(12, 78);
            this.chkConcatenation.Name = "chkConcatenation";
            this.chkConcatenation.Size = new System.Drawing.Size(136, 16);
            this.chkConcatenation.TabIndex = 18;
            this.chkConcatenation.Text = "ISBT Concatenation";
            this.chkConcatenation.UseVisualStyleBackColor = true;
            // 
            // chkIsbt128
            // 
            this.chkIsbt128.AutoSize = true;
            this.chkIsbt128.Location = new System.Drawing.Point(12, 56);
            this.chkIsbt128.Name = "chkIsbt128";
            this.chkIsbt128.Size = new System.Drawing.Size(73, 16);
            this.chkIsbt128.TabIndex = 17;
            this.chkIsbt128.Text = "ISBT 128";
            this.chkIsbt128.UseVisualStyleBackColor = true;
            // 
            // chkGS1128
            // 
            this.chkGS1128.AutoSize = true;
            this.chkGS1128.Location = new System.Drawing.Point(12, 34);
            this.chkGS1128.Name = "chkGS1128";
            this.chkGS1128.Size = new System.Drawing.Size(216, 16);
            this.chkGS1128.TabIndex = 16;
            this.chkGS1128.Text = "GS1-128 (formerly UCC/EAN-128)";
            this.chkGS1128.UseVisualStyleBackColor = true;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(12, 12);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(70, 16);
            this.chkEnable.TabIndex = 15;
            this.chkEnable.Text = "Enabled";
            this.chkEnable.UseVisualStyleBackColor = true;
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
            this.pnlLength.TabIndex = 28;
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
            // chkReducedQuietZone
            // 
            this.chkReducedQuietZone.AutoSize = true;
            this.chkReducedQuietZone.Location = new System.Drawing.Point(12, 122);
            this.chkReducedQuietZone.Name = "chkReducedQuietZone";
            this.chkReducedQuietZone.Size = new System.Drawing.Size(140, 16);
            this.chkReducedQuietZone.TabIndex = 29;
            this.chkReducedQuietZone.Text = "Reduced Quiet Zone";
            this.chkReducedQuietZone.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreCode128FNC4
            // 
            this.chkIgnoreCode128FNC4.AutoSize = true;
            this.chkIgnoreCode128FNC4.Location = new System.Drawing.Point(11, 144);
            this.chkIgnoreCode128FNC4.Name = "chkIgnoreCode128FNC4";
            this.chkIgnoreCode128FNC4.Size = new System.Drawing.Size(166, 16);
            this.chkIgnoreCode128FNC4.TabIndex = 30;
            this.chkIgnoreCode128FNC4.Text = "Ignore Code 128 <FNC4>";
            this.chkIgnoreCode128FNC4.UseVisualStyleBackColor = true;
            // 
            // OptionCode128Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.chkIgnoreCode128FNC4);
            this.Controls.Add(this.chkReducedQuietZone);
            this.Controls.Add(this.pnlLength);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxRedundancy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkCheckIsbtTable);
            this.Controls.Add(this.chkConcatenation);
            this.Controls.Add(this.chkIsbt128);
            this.Controls.Add(this.chkGS1128);
            this.Controls.Add(this.chkEnable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionCode128Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OptionCode128Dialog";
            this.Load += new System.EventHandler(this.OptionCode128Dialog_Load);
            this.pnlLength.ResumeLayout(false);
            this.pnlLength.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxRedundancy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkCheckIsbtTable;
        private System.Windows.Forms.CheckBox chkConcatenation;
        private System.Windows.Forms.CheckBox chkIsbt128;
        private System.Windows.Forms.CheckBox chkGS1128;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.Panel pnlLength;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.ComboBox cbxLengthType;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.CheckBox chkReducedQuietZone;
        private System.Windows.Forms.CheckBox chkIgnoreCode128FNC4;
    }
}
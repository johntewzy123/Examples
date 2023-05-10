namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    partial class OptionGeneralDialog
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
            this.cbxRedundancyLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxSecurityLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxInverse1D = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxCharset = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxRedundancyLevel
            // 
            this.cbxRedundancyLevel.FormattingEnabled = true;
            this.cbxRedundancyLevel.Location = new System.Drawing.Point(13, 28);
            this.cbxRedundancyLevel.Name = "cbxRedundancyLevel";
            this.cbxRedundancyLevel.Size = new System.Drawing.Size(260, 20);
            this.cbxRedundancyLevel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Redundancy Level";
            // 
            // cbxSecurityLevel
            // 
            this.cbxSecurityLevel.FormattingEnabled = true;
            this.cbxSecurityLevel.Location = new System.Drawing.Point(12, 77);
            this.cbxSecurityLevel.Name = "cbxSecurityLevel";
            this.cbxSecurityLevel.Size = new System.Drawing.Size(260, 20);
            this.cbxSecurityLevel.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Security Level";
            // 
            // cbxInverse1D
            // 
            this.cbxInverse1D.FormattingEnabled = true;
            this.cbxInverse1D.Location = new System.Drawing.Point(12, 128);
            this.cbxInverse1D.Name = "cbxInverse1D";
            this.cbxInverse1D.Size = new System.Drawing.Size(260, 20);
            this.cbxInverse1D.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Inverse 1D";
            // 
            // cbxCharset
            // 
            this.cbxCharset.FormattingEnabled = true;
            this.cbxCharset.Location = new System.Drawing.Point(12, 180);
            this.cbxCharset.Name = "cbxCharset";
            this.cbxCharset.Size = new System.Drawing.Size(260, 20);
            this.cbxCharset.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "CharSet is used for decoding";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(236, 41);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Set Option";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OptionGeneralDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxCharset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxInverse1D);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxSecurityLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxRedundancyLevel);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionGeneralDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OptionGeneralDialog";
            this.Load += new System.EventHandler(this.OptionGeneralDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxRedundancyLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxSecurityLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxInverse1D;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxCharset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
    }
}
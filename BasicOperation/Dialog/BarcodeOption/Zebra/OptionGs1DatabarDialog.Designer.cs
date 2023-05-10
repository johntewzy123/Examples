namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    partial class OptionGs1DatabarDialog
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
            this.cbxSecurityLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkConvertRss14toUpcEan = new System.Windows.Forms.CheckBox();
            this.chkDatabarExpanded = new System.Windows.Forms.CheckBox();
            this.chkDatabarLimited = new System.Windows.Forms.CheckBox();
            this.chkDatabar = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(236, 41);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Set Option";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxSecurityLevel
            // 
            this.cbxSecurityLevel.FormattingEnabled = true;
            this.cbxSecurityLevel.Location = new System.Drawing.Point(12, 120);
            this.cbxSecurityLevel.Name = "cbxSecurityLevel";
            this.cbxSecurityLevel.Size = new System.Drawing.Size(260, 20);
            this.cbxSecurityLevel.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "RSS-Limited Security Level";
            // 
            // chkConvertRss14toUpcEan
            // 
            this.chkConvertRss14toUpcEan.AutoSize = true;
            this.chkConvertRss14toUpcEan.Location = new System.Drawing.Point(12, 78);
            this.chkConvertRss14toUpcEan.Name = "chkConvertRss14toUpcEan";
            this.chkConvertRss14toUpcEan.Size = new System.Drawing.Size(187, 16);
            this.chkConvertRss14toUpcEan.TabIndex = 32;
            this.chkConvertRss14toUpcEan.Text = "Convert RSS-14 to UPC/EAN";
            this.chkConvertRss14toUpcEan.UseVisualStyleBackColor = true;
            // 
            // chkDatabarExpanded
            // 
            this.chkDatabarExpanded.AutoSize = true;
            this.chkDatabarExpanded.Location = new System.Drawing.Point(12, 56);
            this.chkDatabarExpanded.Name = "chkDatabarExpanded";
            this.chkDatabarExpanded.Size = new System.Drawing.Size(256, 16);
            this.chkDatabarExpanded.TabIndex = 31;
            this.chkDatabarExpanded.Text = "RSS-Expanded (GS1 Databar Expanded)";
            this.chkDatabarExpanded.UseVisualStyleBackColor = true;
            // 
            // chkDatabarLimited
            // 
            this.chkDatabarLimited.AutoSize = true;
            this.chkDatabarLimited.Location = new System.Drawing.Point(12, 34);
            this.chkDatabarLimited.Name = "chkDatabarLimited";
            this.chkDatabarLimited.Size = new System.Drawing.Size(225, 16);
            this.chkDatabarLimited.TabIndex = 30;
            this.chkDatabarLimited.Text = "RSS-Limited (GS1 DataBar Limited)";
            this.chkDatabarLimited.UseVisualStyleBackColor = true;
            // 
            // chkDatabar
            // 
            this.chkDatabar.AutoSize = true;
            this.chkDatabar.Location = new System.Drawing.Point(12, 12);
            this.chkDatabar.Name = "chkDatabar";
            this.chkDatabar.Size = new System.Drawing.Size(151, 16);
            this.chkDatabar.TabIndex = 29;
            this.chkDatabar.Text = "RSS-14 (GS1 DataBar)";
            this.chkDatabar.UseVisualStyleBackColor = true;
            // 
            // OptionGs1DatabarDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxSecurityLevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkConvertRss14toUpcEan);
            this.Controls.Add(this.chkDatabarExpanded);
            this.Controls.Add(this.chkDatabarLimited);
            this.Controls.Add(this.chkDatabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionGs1DatabarDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OptionGs1DatabarDialog";
            this.Load += new System.EventHandler(this.OptionGs1DatabarDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxSecurityLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkConvertRss14toUpcEan;
        private System.Windows.Forms.CheckBox chkDatabarExpanded;
        private System.Windows.Forms.CheckBox chkDatabarLimited;
        private System.Windows.Forms.CheckBox chkDatabar;
    }
}
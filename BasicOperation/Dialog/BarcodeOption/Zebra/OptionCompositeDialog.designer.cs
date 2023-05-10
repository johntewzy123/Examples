namespace BasicOperation.Dialog.BarcodeOption.Zebra
{
    partial class OptionCompositeDialog
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
            this.cbxCompositeMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkEmulation = new System.Windows.Forms.CheckBox();
            this.chkCompositeTLC39 = new System.Windows.Forms.CheckBox();
            this.chkCompositeCCAB = new System.Windows.Forms.CheckBox();
            this.chkCompositeCCC = new System.Windows.Forms.CheckBox();
            this.cbxBeepMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(236, 41);
            this.btnSave.TabIndex = 37;
            this.btnSave.Text = "Set Option";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxCompositeMode
            // 
            this.cbxCompositeMode.FormattingEnabled = true;
            this.cbxCompositeMode.Location = new System.Drawing.Point(12, 130);
            this.cbxCompositeMode.Name = "cbxCompositeMode";
            this.cbxCompositeMode.Size = new System.Drawing.Size(260, 20);
            this.cbxCompositeMode.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "UPC Composite Mode";
            // 
            // chkEmulation
            // 
            this.chkEmulation.Location = new System.Drawing.Point(12, 77);
            this.chkEmulation.Name = "chkEmulation";
            this.chkEmulation.Size = new System.Drawing.Size(260, 29);
            this.chkEmulation.TabIndex = 41;
            this.chkEmulation.Text = "GS1-128 Emulation Mode for UCC/EAN Composite Codes";
            this.chkEmulation.UseVisualStyleBackColor = true;
            // 
            // chkCompositeTLC39
            // 
            this.chkCompositeTLC39.AutoSize = true;
            this.chkCompositeTLC39.Location = new System.Drawing.Point(12, 56);
            this.chkCompositeTLC39.Name = "chkCompositeTLC39";
            this.chkCompositeTLC39.Size = new System.Drawing.Size(131, 16);
            this.chkCompositeTLC39.TabIndex = 40;
            this.chkCompositeTLC39.Text = "Composite TLC-39";
            this.chkCompositeTLC39.UseVisualStyleBackColor = true;
            // 
            // chkCompositeCCAB
            // 
            this.chkCompositeCCAB.AutoSize = true;
            this.chkCompositeCCAB.Location = new System.Drawing.Point(12, 34);
            this.chkCompositeCCAB.Name = "chkCompositeCCAB";
            this.chkCompositeCCAB.Size = new System.Drawing.Size(129, 16);
            this.chkCompositeCCAB.TabIndex = 39;
            this.chkCompositeCCAB.Text = "Composite CC-AB";
            this.chkCompositeCCAB.UseVisualStyleBackColor = true;
            // 
            // chkCompositeCCC
            // 
            this.chkCompositeCCC.AutoSize = true;
            this.chkCompositeCCC.Location = new System.Drawing.Point(12, 12);
            this.chkCompositeCCC.Name = "chkCompositeCCC";
            this.chkCompositeCCC.Size = new System.Drawing.Size(122, 16);
            this.chkCompositeCCC.TabIndex = 38;
            this.chkCompositeCCC.Text = "Composite CC-C";
            this.chkCompositeCCC.UseVisualStyleBackColor = true;
            // 
            // cbxBeepMode
            // 
            this.cbxBeepMode.FormattingEnabled = true;
            this.cbxBeepMode.Location = new System.Drawing.Point(12, 176);
            this.cbxBeepMode.Name = "cbxBeepMode";
            this.cbxBeepMode.Size = new System.Drawing.Size(260, 20);
            this.cbxBeepMode.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "Composite Beep Mode";
            // 
            // OptionCompositeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.cbxBeepMode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCompositeMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkEmulation);
            this.Controls.Add(this.chkCompositeTLC39);
            this.Controls.Add(this.chkCompositeCCAB);
            this.Controls.Add(this.chkCompositeCCC);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionCompositeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OptionCompositeDialog";
            this.Load += new System.EventHandler(this.OptionCompositeDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxCompositeMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkEmulation;
        private System.Windows.Forms.CheckBox chkCompositeTLC39;
        private System.Windows.Forms.CheckBox chkCompositeCCAB;
        private System.Windows.Forms.CheckBox chkCompositeCCC;
        private System.Windows.Forms.ComboBox cbxBeepMode;
        private System.Windows.Forms.Label label2;
    }
}
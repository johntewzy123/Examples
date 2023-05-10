namespace BasicOperation.Dialog.BarcodeOption.Honeywell
{
    partial class OptionPostalCodeDialog
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
            this.cbxPostalCodes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxPlanetCodeCheckDigit = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxPostnetCheckDigit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxAusInterpretation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPostalCodes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbxPostalCodes
            // 
            this.cbxPostalCodes.FormattingEnabled = true;
            this.cbxPostalCodes.Location = new System.Drawing.Point(11, 56);
            this.cbxPostalCodes.Name = "cbxPostalCodes";
            this.cbxPostalCodes.Size = new System.Drawing.Size(260, 20);
            this.cbxPostalCodes.TabIndex = 26;
            this.cbxPostalCodes.SelectedIndexChanged += new System.EventHandler(this.cbxPostalCodes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "Postal Codes - 2D";
            // 
            // cbxPlanetCodeCheckDigit
            // 
            this.cbxPlanetCodeCheckDigit.FormattingEnabled = true;
            this.cbxPlanetCodeCheckDigit.Location = new System.Drawing.Point(13, 185);
            this.cbxPlanetCodeCheckDigit.Name = "cbxPlanetCodeCheckDigit";
            this.cbxPlanetCodeCheckDigit.Size = new System.Drawing.Size(260, 20);
            this.cbxPlanetCodeCheckDigit.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 14);
            this.label2.TabIndex = 27;
            this.label2.Text = "Planet Code Check Digit";
            // 
            // cbxPostnetCheckDigit
            // 
            this.cbxPostnetCheckDigit.FormattingEnabled = true;
            this.cbxPostnetCheckDigit.Location = new System.Drawing.Point(13, 235);
            this.cbxPostnetCheckDigit.Name = "cbxPostnetCheckDigit";
            this.cbxPostnetCheckDigit.Size = new System.Drawing.Size(260, 20);
            this.cbxPostnetCheckDigit.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(248, 14);
            this.label3.TabIndex = 29;
            this.label3.Text = "Postnet Check Digit";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 314);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(236, 41);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Set Option";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxAusInterpretation
            // 
            this.cbxAusInterpretation.FormattingEnabled = true;
            this.cbxAusInterpretation.Location = new System.Drawing.Point(13, 287);
            this.cbxAusInterpretation.Name = "cbxAusInterpretation";
            this.cbxAusInterpretation.Size = new System.Drawing.Size(260, 20);
            this.cbxAusInterpretation.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 14);
            this.label4.TabIndex = 32;
            this.label4.Text = "Australian Post Interpretation";
            // 
            // tbxPostalCodes
            // 
            this.tbxPostalCodes.Location = new System.Drawing.Point(12, 79);
            this.tbxPostalCodes.Multiline = true;
            this.tbxPostalCodes.Name = "tbxPostalCodes";
            this.tbxPostalCodes.ReadOnly = true;
            this.tbxPostalCodes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxPostalCodes.Size = new System.Drawing.Size(260, 80);
            this.tbxPostalCodes.TabIndex = 34;
            // 
            // OptionPostalCodeDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 362);
            this.Controls.Add(this.tbxPostalCodes);
            this.Controls.Add(this.cbxAusInterpretation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbxPostnetCheckDigit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxPlanetCodeCheckDigit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxPostalCodes);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionPostalCodeDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OptionPostalCodeDialog";
            this.Load += new System.EventHandler(this.OptionPostalCodeDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxPostalCodes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxPlanetCodeCheckDigit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxPostnetCheckDigit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxAusInterpretation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPostalCodes;
    }
}
namespace BasicOperation.Dialog
{
    partial class QValue
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbxAlgorithm = new System.Windows.Forms.ComboBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numMaxQ = new System.Windows.Forms.NumericUpDown();
            this.numMinQ = new System.Windows.Forms.NumericUpDown();
            this.numStartQ = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartQ)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(15, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 12);
            this.label5.TabIndex = 59;
            this.label5.Text = "When using the Dynamic Q";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(15, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(343, 15);
            this.label4.TabIndex = 58;
            this.label4.Text = "Max Q must be greater than or equal to Start Q and Min Q";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(15, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 15);
            this.label3.TabIndex = 57;
            this.label3.Text = "Min Q must be less than or equal to Start Q and Max Q";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(15, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(454, 15);
            this.label2.TabIndex = 56;
            this.label2.Text = "Start Q must be greater than or equal to Min Q and less than or equal to Max Q";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(15, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 12);
            this.label1.TabIndex = 55;
            this.label1.Text = "When using the Fixed Q use Start Q as a fixed value";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(271, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 32);
            this.btnCancel.TabIndex = 54;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(121, 220);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(92, 32);
            this.btnOK.TabIndex = 53;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(129, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 12);
            this.label9.TabIndex = 52;
            this.label9.Text = "Algorithm";
            // 
            // cbxAlgorithm
            // 
            this.cbxAlgorithm.FormattingEnabled = true;
            this.cbxAlgorithm.Location = new System.Drawing.Point(198, 10);
            this.cbxAlgorithm.Name = "cbxAlgorithm";
            this.cbxAlgorithm.Size = new System.Drawing.Size(124, 20);
            this.cbxAlgorithm.TabIndex = 51;
            this.cbxAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cbxAlgorithm_SelectedIndexChanged);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(306, 44);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(43, 12);
            this.label36.TabIndex = 50;
            this.label36.Text = "Max Q";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(197, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 12);
            this.label13.TabIndex = 49;
            this.label13.Text = "Min Q";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 12);
            this.label11.TabIndex = 48;
            this.label11.Text = "Start Q";
            // 
            // numMaxQ
            // 
            this.numMaxQ.Location = new System.Drawing.Point(355, 40);
            this.numMaxQ.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numMaxQ.Name = "numMaxQ";
            this.numMaxQ.Size = new System.Drawing.Size(51, 21);
            this.numMaxQ.TabIndex = 47;
            this.numMaxQ.ValueChanged += new System.EventHandler(this.numMaxQ_ValueChanged);
            // 
            // numMinQ
            // 
            this.numMinQ.Location = new System.Drawing.Point(242, 40);
            this.numMinQ.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numMinQ.Name = "numMinQ";
            this.numMinQ.Size = new System.Drawing.Size(51, 21);
            this.numMinQ.TabIndex = 46;
            this.numMinQ.ValueChanged += new System.EventHandler(this.numMinQ_ValueChanged);
            // 
            // numStartQ
            // 
            this.numStartQ.Location = new System.Drawing.Point(117, 40);
            this.numStartQ.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numStartQ.Name = "numStartQ";
            this.numStartQ.Size = new System.Drawing.Size(51, 21);
            this.numStartQ.TabIndex = 45;
            this.numStartQ.ValueChanged += new System.EventHandler(this.numStartQ_ValueChanged);
            // 
            // QValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbxAlgorithm);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numMaxQ);
            this.Controls.Add(this.numMinQ);
            this.Controls.Add(this.numStartQ);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QValue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QValue";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QValue_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartQ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxAlgorithm;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numMaxQ;
        private System.Windows.Forms.NumericUpDown numMinQ;
        private System.Windows.Forms.NumericUpDown numStartQ;
    }
}
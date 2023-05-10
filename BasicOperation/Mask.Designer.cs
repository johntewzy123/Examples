namespace BasicOperation
{
    partial class Mask
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
            this.grpSelect = new System.Windows.Forms.GroupBox();
            this.lstSelectMask = new System.Windows.Forms.ListView();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.btnEditSelectMask = new System.Windows.Forms.Button();
            this.btnSelectMaskParamSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSelect
            // 
            this.grpSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpSelect.Controls.Add(this.lstSelectMask);
            this.grpSelect.Location = new System.Drawing.Point(4, 8);
            this.grpSelect.Name = "grpSelect";
            this.grpSelect.Size = new System.Drawing.Size(794, 288);
            this.grpSelect.TabIndex = 17;
            this.grpSelect.TabStop = false;
            this.grpSelect.Text = "Select Mask Parameters";
            // 
            // lstSelectMask
            // 
            this.lstSelectMask.CheckBoxes = true;
            this.lstSelectMask.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21});
            this.lstSelectMask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstSelectMask.FullRowSelect = true;
            this.lstSelectMask.GridLines = true;
            this.lstSelectMask.Location = new System.Drawing.Point(3, 17);
            this.lstSelectMask.MultiSelect = false;
            this.lstSelectMask.Name = "lstSelectMask";
            this.lstSelectMask.Size = new System.Drawing.Size(788, 268);
            this.lstSelectMask.TabIndex = 12;
            this.lstSelectMask.UseCompatibleStateImageBehavior = false;
            this.lstSelectMask.View = System.Windows.Forms.View.Details;
            this.lstSelectMask.DoubleClick += new System.EventHandler(this.lstSelectMask_DoubleClick);
            this.lstSelectMask.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstSelectMask_ItemCheck);
            this.lstSelectMask.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstSelectMask_MouseDown);
            this.lstSelectMask.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSelectMask_KeyDown);
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Use";
            this.columnHeader22.Width = 40;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Target";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Action";
            this.columnHeader12.Width = 346;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Bank";
            this.columnHeader18.Width = 70;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Offset";
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Pattern";
            this.columnHeader20.Width = 97;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Length";
            // 
            // btnEditSelectMask
            // 
            this.btnEditSelectMask.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditSelectMask.Location = new System.Drawing.Point(539, 303);
            this.btnEditSelectMask.Name = "btnEditSelectMask";
            this.btnEditSelectMask.Size = new System.Drawing.Size(112, 29);
            this.btnEditSelectMask.TabIndex = 19;
            this.btnEditSelectMask.Text = "Edit";
            this.btnEditSelectMask.UseVisualStyleBackColor = true;
            this.btnEditSelectMask.Click += new System.EventHandler(this.btnEditSelectMask_Click);
            // 
            // btnSelectMaskParamSave
            // 
            this.btnSelectMaskParamSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSelectMaskParamSave.Location = new System.Drawing.Point(675, 303);
            this.btnSelectMaskParamSave.Name = "btnSelectMaskParamSave";
            this.btnSelectMaskParamSave.Size = new System.Drawing.Size(112, 29);
            this.btnSelectMaskParamSave.TabIndex = 18;
            this.btnSelectMaskParamSave.Text = "Save";
            this.btnSelectMaskParamSave.UseVisualStyleBackColor = true;
            this.btnSelectMaskParamSave.Click += new System.EventHandler(this.btnSelectMaskParamSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatus.Location = new System.Drawing.Point(346, 305);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(61, 19);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.Text = "... 0/8";
            // 
            // Mask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 344);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnEditSelectMask);
            this.Controls.Add(this.btnSelectMaskParamSave);
            this.Controls.Add(this.grpSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mask";
            this.Load += new System.EventHandler(this.Mask_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mask_FormClosing);
            this.grpSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSelect;
        private System.Windows.Forms.ListView lstSelectMask;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.Button btnEditSelectMask;
        private System.Windows.Forms.Button btnSelectMaskParamSave;
        private System.Windows.Forms.Label lblStatus;
    }
}
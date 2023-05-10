namespace BasicOperation.Dialog
{
    partial class SymbolState
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
            this.lstSymbolList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstSymbolList
            // 
            this.lstSymbolList.CheckBoxes = true;
            this.lstSymbolList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstSymbolList.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstSymbolList.FullRowSelect = true;
            this.lstSymbolList.Location = new System.Drawing.Point(0, 0);
            this.lstSymbolList.MultiSelect = false;
            this.lstSymbolList.Name = "lstSymbolList";
            this.lstSymbolList.Size = new System.Drawing.Size(274, 306);
            this.lstSymbolList.TabIndex = 47;
            this.lstSymbolList.UseCompatibleStateImageBehavior = false;
            this.lstSymbolList.View = System.Windows.Forms.View.Details;
            this.lstSymbolList.DoubleClick += new System.EventHandler(this.lstSymbolList_DoubleClick);
            this.lstSymbolList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstSymbolList_ItemCheck);
            this.lstSymbolList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstSymbolList_MouseDown);
            this.lstSymbolList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstSymbolList_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 278;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(151, 311);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 32);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(41, 311);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(92, 32);
            this.btnOK.TabIndex = 45;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // SymbolState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 346);
            this.Controls.Add(this.lstSymbolList);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SymbolState";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SymbolState";
            this.Load += new System.EventHandler(this.SymbolState_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SymbolState_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstSymbolList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}
namespace BasicOperation
{
    partial class StoredData
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
            this.lstStoredData = new System.Windows.Forms.ListView();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.btnLoadStoredData = new System.Windows.Forms.Button();
            this.btnStoredDataClear = new System.Windows.Forms.Button();
            this.btnStoredDataRemove = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblConutsToRead = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblStoredDataCount = new System.Windows.Forms.Label();
            this.lblStoredDataTotalCount = new System.Windows.Forms.Label();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstStoredData
            // 
            this.lstStoredData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.lstStoredData.GridLines = true;
            this.lstStoredData.Location = new System.Drawing.Point(6, 4);
            this.lstStoredData.Name = "lstStoredData";
            this.lstStoredData.Size = new System.Drawing.Size(615, 266);
            this.lstStoredData.TabIndex = 27;
            this.lstStoredData.UseCompatibleStateImageBehavior = false;
            this.lstStoredData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "No.";
            this.columnHeader13.Width = 36;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Type";
            this.columnHeader14.Width = 66;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Value";
            this.columnHeader15.Width = 266;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "#";
            this.columnHeader16.Width = 85;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Barcode Type";
            this.columnHeader17.Width = 120;
            // 
            // btnLoadStoredData
            // 
            this.btnLoadStoredData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadStoredData.Location = new System.Drawing.Point(503, 278);
            this.btnLoadStoredData.Name = "btnLoadStoredData";
            this.btnLoadStoredData.Size = new System.Drawing.Size(112, 29);
            this.btnLoadStoredData.TabIndex = 30;
            this.btnLoadStoredData.Text = "Load";
            this.btnLoadStoredData.UseVisualStyleBackColor = true;
            this.btnLoadStoredData.Click += new System.EventHandler(this.btnLoadStoredData_Click);
            // 
            // btnStoredDataClear
            // 
            this.btnStoredDataClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStoredDataClear.Location = new System.Drawing.Point(503, 312);
            this.btnStoredDataClear.Name = "btnStoredDataClear";
            this.btnStoredDataClear.Size = new System.Drawing.Size(112, 29);
            this.btnStoredDataClear.TabIndex = 31;
            this.btnStoredDataClear.Text = "Clear";
            this.btnStoredDataClear.UseVisualStyleBackColor = true;
            this.btnStoredDataClear.Click += new System.EventHandler(this.btnStoredDataClear_Click);
            // 
            // btnStoredDataRemove
            // 
            this.btnStoredDataRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStoredDataRemove.Location = new System.Drawing.Point(385, 278);
            this.btnStoredDataRemove.Name = "btnStoredDataRemove";
            this.btnStoredDataRemove.Size = new System.Drawing.Size(112, 29);
            this.btnStoredDataRemove.TabIndex = 32;
            this.btnStoredDataRemove.Text = "Remove";
            this.btnStoredDataRemove.UseVisualStyleBackColor = true;
            this.btnStoredDataRemove.Click += new System.EventHandler(this.btnStoredDataRemove_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblConutsToRead);
            this.groupBox8.Location = new System.Drawing.Point(6, 278);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(174, 55);
            this.groupBox8.TabIndex = 33;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Stored Count";
            // 
            // lblConutsToRead
            // 
            this.lblConutsToRead.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblConutsToRead.ForeColor = System.Drawing.Color.Green;
            this.lblConutsToRead.Location = new System.Drawing.Point(6, 18);
            this.lblConutsToRead.Name = "lblConutsToRead";
            this.lblConutsToRead.Size = new System.Drawing.Size(153, 21);
            this.lblConutsToRead.TabIndex = 26;
            this.lblConutsToRead.Text = "0";
            this.lblConutsToRead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblStoredDataCount);
            this.groupBox7.Controls.Add(this.lblStoredDataTotalCount);
            this.groupBox7.Location = new System.Drawing.Point(186, 278);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(174, 55);
            this.groupBox7.TabIndex = 34;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Count";
            // 
            // lblStoredDataCount
            // 
            this.lblStoredDataCount.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoredDataCount.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStoredDataCount.Location = new System.Drawing.Point(6, 18);
            this.lblStoredDataCount.Name = "lblStoredDataCount";
            this.lblStoredDataCount.Size = new System.Drawing.Size(153, 21);
            this.lblStoredDataCount.TabIndex = 5;
            this.lblStoredDataCount.Text = "0";
            this.lblStoredDataCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStoredDataTotalCount
            // 
            this.lblStoredDataTotalCount.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoredDataTotalCount.ForeColor = System.Drawing.Color.CadetBlue;
            this.lblStoredDataTotalCount.Location = new System.Drawing.Point(7, 39);
            this.lblStoredDataTotalCount.Name = "lblStoredDataTotalCount";
            this.lblStoredDataTotalCount.Size = new System.Drawing.Size(161, 12);
            this.lblStoredDataTotalCount.TabIndex = 6;
            this.lblStoredDataTotalCount.Text = "0";
            this.lblStoredDataTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StoredData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 345);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.btnLoadStoredData);
            this.Controls.Add(this.btnStoredDataClear);
            this.Controls.Add(this.btnStoredDataRemove);
            this.Controls.Add(this.lstStoredData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StoredData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StoredData";
            this.Load += new System.EventHandler(this.StoredData_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StoredData_FormClosing);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstStoredData;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.Button btnLoadStoredData;
        private System.Windows.Forms.Button btnStoredDataClear;
        private System.Windows.Forms.Button btnStoredDataRemove;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lblConutsToRead;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblStoredDataCount;
        private System.Windows.Forms.Label lblStoredDataTotalCount;
    }
}
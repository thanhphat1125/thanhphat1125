namespace OrderDrink
{
    partial class fShowCategory
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
            this.flbCategory = new System.Windows.Forms.FlowLayoutPanel();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddFood = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nmUDfoodCount = new System.Windows.Forms.NumericUpDown();
            this.txbTotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbPrice = new System.Windows.Forms.TextBox();
            this.lvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmUDfoodCount)).BeginInit();
            this.SuspendLayout();
            // 
            // flbCategory
            // 
            this.flbCategory.AutoScroll = true;
            this.flbCategory.Location = new System.Drawing.Point(2, 44);
            this.flbCategory.Name = "flbCategory";
            this.flbCategory.Size = new System.Drawing.Size(391, 235);
            this.flbCategory.TabIndex = 0;
            // 
            // cbFood
            // 
            this.cbFood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(209)))), ((int)(((byte)(211)))));
            this.cbFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(3, 8);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(149, 21);
            this.cbFood.TabIndex = 0;
            this.cbFood.SelectedIndexChanged += new System.EventHandler(this.cbFood_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(392, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 270);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(2, 278);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(662, 1);
            this.panel2.TabIndex = 2;
            // 
            // btnAddFood
            // 
            this.btnAddFood.Location = new System.Drawing.Point(230, 4);
            this.btnAddFood.Name = "btnAddFood";
            this.btnAddFood.Size = new System.Drawing.Size(86, 29);
            this.btnAddFood.TabIndex = 1;
            this.btnAddFood.Text = "Thêm Món";
            this.btnAddFood.UseVisualStyleBackColor = true;
            this.btnAddFood.Click += new System.EventHandler(this.btnAddFood_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nmUDfoodCount);
            this.panel3.Controls.Add(this.cbFood);
            this.panel3.Controls.Add(this.btnAddFood);
            this.panel3.Location = new System.Drawing.Point(396, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(326, 36);
            this.panel3.TabIndex = 5;
            // 
            // nmUDfoodCount
            // 
            this.nmUDfoodCount.Location = new System.Drawing.Point(159, 9);
            this.nmUDfoodCount.Name = "nmUDfoodCount";
            this.nmUDfoodCount.Size = new System.Drawing.Size(66, 20);
            this.nmUDfoodCount.TabIndex = 8;
            this.nmUDfoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmUDfoodCount.ValueChanged += new System.EventHandler(this.nmUDfoodCount_ValueChanged);
            // 
            // txbTotalPrice
            // 
            this.txbTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbTotalPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalPrice.Location = new System.Drawing.Point(518, 288);
            this.txbTotalPrice.Multiline = true;
            this.txbTotalPrice.Name = "txbTotalPrice";
            this.txbTotalPrice.ReadOnly = true;
            this.txbTotalPrice.Size = new System.Drawing.Size(155, 26);
            this.txbTotalPrice.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(405, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 27);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tổng tiền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(93, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Bàn số :";
            // 
            // cbTable
            // 
            this.cbTable.FormattingEnabled = true;
            this.cbTable.Location = new System.Drawing.Point(166, 14);
            this.cbTable.Name = "cbTable";
            this.cbTable.Size = new System.Drawing.Size(121, 21);
            this.cbTable.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(456, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 27);
            this.label3.TabIndex = 13;
            this.label3.Text = "Giá :";
            // 
            // txbPrice
            // 
            this.txbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPrice.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPrice.Location = new System.Drawing.Point(535, 50);
            this.txbPrice.Multiline = true;
            this.txbPrice.Name = "txbPrice";
            this.txbPrice.ReadOnly = true;
            this.txbPrice.Size = new System.Drawing.Size(155, 26);
            this.txbPrice.TabIndex = 14;
            // 
            // lvBill
            // 
            this.lvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvBill.GridLines = true;
            this.lvBill.HideSelection = false;
            this.lvBill.Location = new System.Drawing.Point(392, 75);
            this.lvBill.Name = "lvBill";
            this.lvBill.Size = new System.Drawing.Size(330, 204);
            this.lvBill.TabIndex = 15;
            this.lvBill.UseCompatibleStateImageBehavior = false;
            this.lvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 54;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 70;
            // 
            // fShowCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(724, 338);
            this.Controls.Add(this.lvBill);
            this.Controls.Add(this.txbPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbTotalPrice);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flbCategory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fShowCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oder";
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmUDfoodCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flbCategory;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAddFood;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbTotalPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmUDfoodCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbPrice;
        private System.Windows.Forms.ListView lvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}


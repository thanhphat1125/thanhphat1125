namespace QuanLyQuanCafe
{
    partial class fSearchFood
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSearchFood));
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.butSearchDate = new System.Windows.Forms.Button();
            this.butSearchMonth = new System.Windows.Forms.Button();
            this.butSearchYear = new System.Windows.Forms.Button();
            this.labelFood = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(183, 19);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(298, 29);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.Value = new System.DateTime(2019, 5, 15, 0, 0, 0, 0);
            // 
            // butSearchDate
            // 
            this.butSearchDate.Location = new System.Drawing.Point(94, 103);
            this.butSearchDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butSearchDate.Name = "butSearchDate";
            this.butSearchDate.Size = new System.Drawing.Size(117, 63);
            this.butSearchDate.TabIndex = 2;
            this.butSearchDate.Text = "Ngày";
            this.butSearchDate.UseVisualStyleBackColor = true;
            this.butSearchDate.Click += new System.EventHandler(this.butSearchDate_Click);
            // 
            // butSearchMonth
            // 
            this.butSearchMonth.Location = new System.Drawing.Point(276, 103);
            this.butSearchMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butSearchMonth.Name = "butSearchMonth";
            this.butSearchMonth.Size = new System.Drawing.Size(122, 63);
            this.butSearchMonth.TabIndex = 3;
            this.butSearchMonth.Text = "Tháng";
            this.butSearchMonth.UseVisualStyleBackColor = true;
            this.butSearchMonth.Click += new System.EventHandler(this.butSearchMonth_Click);
            // 
            // butSearchYear
            // 
            this.butSearchYear.Location = new System.Drawing.Point(459, 103);
            this.butSearchYear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butSearchYear.Name = "butSearchYear";
            this.butSearchYear.Size = new System.Drawing.Size(120, 63);
            this.butSearchYear.TabIndex = 4;
            this.butSearchYear.Text = "Năm";
            this.butSearchYear.UseVisualStyleBackColor = true;
            this.butSearchYear.Click += new System.EventHandler(this.butSearchYear_Click);
            // 
            // labelFood
            // 
            this.labelFood.AutoSize = true;
            this.labelFood.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFood.Location = new System.Drawing.Point(60, 233);
            this.labelFood.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFood.Name = "labelFood";
            this.labelFood.Size = new System.Drawing.Size(122, 21);
            this.labelFood.TabIndex = 5;
            this.labelFood.Text = "Món bán chạy:";
            // 
            // fSearchFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 317);
            this.Controls.Add(this.labelFood);
            this.Controls.Add(this.butSearchYear);
            this.Controls.Add(this.butSearchMonth);
            this.Controls.Add(this.butSearchDate);
            this.Controls.Add(this.dateTimePicker1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "fSearchFood";
            this.Text = "fSearchFood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button butSearchDate;
        private System.Windows.Forms.Button butSearchMonth;
        private System.Windows.Forms.Button butSearchYear;
        private System.Windows.Forms.Label labelFood;
    }
}
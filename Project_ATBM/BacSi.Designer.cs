namespace Project_ATBM
{
    partial class BacSi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BacSi));
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BS_dataGridView = new System.Windows.Forms.DataGridView();
            this.Header = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BS_dataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(114, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Xem dữ liệu ";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "h";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Bệnh nhân",
            "Hồ sơ bệnh án",
            "Dịch vụ"});
            this.comboBox1.Location = new System.Drawing.Point(276, 110);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 28);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "Chọn bảng";
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.BS_dataGridView);
            this.panel1.Location = new System.Drawing.Point(93, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 446);
            this.panel1.TabIndex = 8;
            // 
            // BS_dataGridView
            // 
            this.BS_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.BS_dataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.BS_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BS_dataGridView.Location = new System.Drawing.Point(53, 42);
            this.BS_dataGridView.Name = "BS_dataGridView";
            this.BS_dataGridView.RowHeadersWidth = 62;
            this.BS_dataGridView.RowTemplate.Height = 28;
            this.BS_dataGridView.Size = new System.Drawing.Size(790, 375);
            this.BS_dataGridView.TabIndex = 3;
            this.BS_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BS_dataGridView_CellContentClick);
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.Red;
            this.Header.Location = new System.Drawing.Point(375, 30);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(204, 29);
            this.Header.TabIndex = 7;
            this.Header.Text = "Welcome Bác Sĩ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.searchBox);
            this.panel2.Location = new System.Drawing.Point(631, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 28);
            this.panel2.TabIndex = 11;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(12, 1);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(281, 26);
            this.searchBox.TabIndex = 0;
            this.searchBox.Text = "Nhập mã bệnh nhân hoặc CMND";
            this.searchBox.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Project_ATBM.Properties.Resources._1024px_Search_Icon_svg;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(312, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 27);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // BacSi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 683);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Header);
            this.Name = "BacSi";
            this.Text = "BacSi";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BS_dataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView BS_dataGridView;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox searchBox;
    }
}
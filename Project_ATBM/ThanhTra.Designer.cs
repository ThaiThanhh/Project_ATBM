namespace Project_ATBM
{
    partial class ThanhTra
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
            this.Header = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ThanhTra_dataGridView = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThanhTra_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.Red;
            this.Header.Location = new System.Drawing.Point(349, 39);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(249, 29);
            this.Header.TabIndex = 0;
            this.Header.Text = "Welcome Thanh Tra";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.ThanhTra_dataGridView);
            this.panel1.Location = new System.Drawing.Point(67, 190);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 446);
            this.panel1.TabIndex = 3;
            // 
            // ThanhTra_dataGridView
            // 
            this.ThanhTra_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ThanhTra_dataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.ThanhTra_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ThanhTra_dataGridView.Location = new System.Drawing.Point(53, 42);
            this.ThanhTra_dataGridView.Name = "ThanhTra_dataGridView";
            this.ThanhTra_dataGridView.RowHeadersWidth = 62;
            this.ThanhTra_dataGridView.RowTemplate.Height = 28;
            this.ThanhTra_dataGridView.Size = new System.Drawing.Size(790, 375);
            this.ThanhTra_dataGridView.TabIndex = 3;
            this.ThanhTra_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ThanhTra_dataGridView_CellContentClick);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "h";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Bệnh nhân",
            "Nhân viên",
            "Cơ sở y tế",
            "Hồ sơ bệnh án",
            "Dịch vụ"});
            this.comboBox1.Location = new System.Drawing.Point(250, 119);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(313, 28);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "Chọn bảng";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Xem dữ liệu ";
            // 
            // ThanhTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 689);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Header);
            this.Name = "ThanhTra";
            this.Text = "ThanhTra";
            this.Load += new System.EventHandler(this.ThanhTra_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ThanhTra_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ThanhTra_dataGridView;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Header;
    }
}
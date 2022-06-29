namespace Project_ATBM
{
    partial class AdminSOYTEX
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ThanhTra_dataGridView = new System.Windows.Forms.DataGridView();
            this.Header = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThanhTra_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 52);
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
            "Nhân viên",
            "Cơ sở y tế",
            "Hồ sơ bệnh án",
            "Dịch vụ"});
            this.comboBox1.Location = new System.Drawing.Point(176, 53);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(313, 28);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.Text = "Chọn bảng";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.ThanhTra_dataGridView);
            this.panel1.Location = new System.Drawing.Point(45, 130);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(896, 470);
            this.panel1.TabIndex = 8;
            // 
            // ThanhTra_dataGridView
            // 
            this.ThanhTra_dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.ThanhTra_dataGridView.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.ThanhTra_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ThanhTra_dataGridView.Location = new System.Drawing.Point(63, 55);
            this.ThanhTra_dataGridView.Name = "ThanhTra_dataGridView";
            this.ThanhTra_dataGridView.RowHeadersWidth = 62;
            this.ThanhTra_dataGridView.RowTemplate.Height = 28;
            this.ThanhTra_dataGridView.Size = new System.Drawing.Size(790, 375);
            this.ThanhTra_dataGridView.TabIndex = 3;
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.ForeColor = System.Drawing.Color.Red;
            this.Header.Location = new System.Drawing.Point(311, -28);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(249, 29);
            this.Header.TabIndex = 7;
            this.Header.Text = "Welcome Thanh Tra";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(629, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 43);
            this.button1.TabIndex = 11;
            this.button1.Text = "Thêm nhân viên";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(807, 45);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 43);
            this.button2.TabIndex = 12;
            this.button2.Text = "Thêm CSYT";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AdminSOYTEX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 651);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Header);
            this.Name = "AdminSOYTEX";
            this.Text = "AdminSOYTEX";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ThanhTra_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView ThanhTra_dataGridView;
        private System.Windows.Forms.Label Header;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
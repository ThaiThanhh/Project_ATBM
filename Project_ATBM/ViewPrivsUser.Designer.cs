namespace Project_ATBM
{
    partial class ViewPrivsUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewPrivs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrivs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(288, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách quyền của User";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(105, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(218, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "Xem danh sách quyền";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(392, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(226, 53);
            this.button2.TabIndex = 3;
            this.button2.Text = "Xem danh sách quyền";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPrivs
            // 
            this.dataGridViewPrivs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPrivs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPrivs.Location = new System.Drawing.Point(819, 144);
            this.dataGridViewPrivs.Name = "dataGridViewPrivs";
            this.dataGridViewPrivs.RowHeadersWidth = 62;
            this.dataGridViewPrivs.RowTemplate.Height = 28;
            this.dataGridViewPrivs.Size = new System.Drawing.Size(708, 540);
            this.dataGridViewPrivs.TabIndex = 1;
            // 
            // ViewPrivsUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1574, 795);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridViewPrivs);
            this.Controls.Add(this.label1);
            this.Name = "ViewPrivsUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewPrivsUser";
            this.Load += new System.EventHandler(this.ViewPrivsUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrivs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewPrivs;
    }
}
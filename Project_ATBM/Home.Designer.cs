﻿namespace Project_ATBM
{
    partial class Home
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
            this.btn_phanhe1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_phanhe1
            // 
            this.btn_phanhe1.BackColor = System.Drawing.Color.DarkRed;
            this.btn_phanhe1.Font = new System.Drawing.Font("MS Reference Sans Serif", 20.25F, System.Drawing.FontStyle.Bold);
            this.btn_phanhe1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_phanhe1.Location = new System.Drawing.Point(198, 202);
            this.btn_phanhe1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_phanhe1.Name = "btn_phanhe1";
            this.btn_phanhe1.Size = new System.Drawing.Size(345, 385);
            this.btn_phanhe1.TabIndex = 0;
            this.btn_phanhe1.Text = "Dành cho người quản trị ";
            this.btn_phanhe1.UseVisualStyleBackColor = false;
            this.btn_phanhe1.Click += new System.EventHandler(this.btn_phanhe1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1156, 80);
            this.label1.TabIndex = 2;
            this.label1.Text = "ĐỒ ÁN MÔN HỌC\r\nAN TOÀN VÀ BẢO MẬT DỮ LIỆU TRONG HỆ THỐNG THÔNG TIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1478, 844);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_phanhe1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_phanhe1;
        private System.Windows.Forms.Label label1;
    }
}
namespace Project_ATBM
{
    partial class EditRole
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtidentitymode = new System.Windows.Forms.TextBox();
            this.txt_rolename = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Role name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nhập identity mới";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtidentitymode
            // 
            this.txtidentitymode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidentitymode.Location = new System.Drawing.Point(293, 178);
            this.txtidentitymode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtidentitymode.Name = "txtidentitymode";
            this.txtidentitymode.Size = new System.Drawing.Size(275, 35);
            this.txtidentitymode.TabIndex = 8;
            this.txtidentitymode.TextChanged += new System.EventHandler(this.txtidentitymode_TextChanged);
            // 
            // txt_rolename
            // 
            this.txt_rolename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rolename.Location = new System.Drawing.Point(293, 97);
            this.txt_rolename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_rolename.Name = "txt_rolename";
            this.txt_rolename.Size = new System.Drawing.Size(275, 35);
            this.txt_rolename.TabIndex = 14;
            this.txt_rolename.TextChanged += new System.EventHandler(this.txt_rolename_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(278, 285);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 55);
            this.button1.TabIndex = 12;
            this.button1.Text = "Trở về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 285);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 55);
            this.button2.TabIndex = 13;
            this.button2.Text = "Chỉnh sửa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EditRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 424);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_rolename);
            this.Controls.Add(this.txtidentitymode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EditRole";
            this.Text = "EditRole";
            this.Load += new System.EventHandler(this.EditRole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtidentitymode;
        private System.Windows.Forms.TextBox txt_rolename;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
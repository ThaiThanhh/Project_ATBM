namespace Project_ATBM
{
    partial class GrantPrivs
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
            this.label3 = new System.Windows.Forms.Label();
            this.txt_rolename = new System.Windows.Forms.TextBox();
            this.txt_privsname = new System.Windows.Forms.TextBox();
            this.txt_obj = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Role name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Quyền";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đối tượng";
            // 
            // txt_rolename
            // 
            this.txt_rolename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rolename.Location = new System.Drawing.Point(341, 87);
            this.txt_rolename.Name = "txt_rolename";
            this.txt_rolename.Size = new System.Drawing.Size(245, 30);
            this.txt_rolename.TabIndex = 3;
            // 
            // txt_privsname
            // 
            this.txt_privsname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_privsname.Location = new System.Drawing.Point(341, 138);
            this.txt_privsname.Name = "txt_privsname";
            this.txt_privsname.Size = new System.Drawing.Size(245, 30);
            this.txt_privsname.TabIndex = 4;
            // 
            // txt_obj
            // 
            this.txt_obj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_obj.Location = new System.Drawing.Point(341, 197);
            this.txt_obj.Name = "txt_obj";
            this.txt_obj.Size = new System.Drawing.Size(245, 30);
            this.txt_obj.TabIndex = 5;
            this.txt_obj.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 266);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Trở về";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(440, 266);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 50);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cấp quyền";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // GrantPrivs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_obj);
            this.Controls.Add(this.txt_privsname);
            this.Controls.Add(this.txt_rolename);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Name = "GrantPrivs";
            this.Text = "GrantPrivs";
            this.Load += new System.EventHandler(this.GrantPrivs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_rolename;
        private System.Windows.Forms.TextBox txt_privsname;
        private System.Windows.Forms.TextBox txt_obj;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
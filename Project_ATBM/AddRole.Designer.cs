namespace Project_ATBM
{
    partial class AddRole
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
            this.txtrolename = new System.Windows.Forms.TextBox();
            this.txtidentitymode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_add_role = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtrolename
            // 
            this.txtrolename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrolename.Location = new System.Drawing.Point(371, 63);
            this.txtrolename.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtrolename.Name = "txtrolename";
            this.txtrolename.Size = new System.Drawing.Size(236, 35);
            this.txtrolename.TabIndex = 1;
            this.txtrolename.TextChanged += new System.EventHandler(this.txtrolename_TextChanged);
            // 
            // txtidentitymode
            // 
            this.txtidentitymode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtidentitymode.Location = new System.Drawing.Point(371, 191);
            this.txtidentitymode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtidentitymode.Name = "txtidentitymode";
            this.txtidentitymode.Size = new System.Drawing.Size(236, 35);
            this.txtidentitymode.TabIndex = 2;
            this.txtidentitymode.TextChanged += new System.EventHandler(this.txtidentitymode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nhập tên Role";
            this.label1.Click += label1_Click;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nhập chế độ xác thực";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button_add_role
            // 
            this.button_add_role.Location = new System.Drawing.Point(389, 324);
            this.button_add_role.Name = "button_add_role";
            this.button_add_role.Size = new System.Drawing.Size(189, 55);
            this.button_add_role.TabIndex = 5;
            this.button_add_role.Text = "Thêm role";
            this.button_add_role.UseVisualStyleBackColor = true;
            this.button_add_role.Click += new System.EventHandler(this.addRoleBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 55);
            this.button1.TabIndex = 6;
            this.button1.Text = "Trở về";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_add_role);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtidentitymode);
            this.Controls.Add(this.txtrolename);
            this.Name = "AddRole";
            this.Text = "AddRole";
            this.Load += new System.EventHandler(this.AddRole_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtrolename;
        private System.Windows.Forms.TextBox txtidentitymode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_add_role;
        private System.Windows.Forms.Button button1;
    }
}
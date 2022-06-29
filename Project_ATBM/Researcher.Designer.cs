namespace Project_ATBM
{
    partial class Researcher
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
            this.listMedicalRecord = new System.Windows.Forms.DataGridView();
            this.buttonViewHSBA = new System.Windows.Forms.Button();
            this.buttonViewHSBADV = new System.Windows.Forms.Button();
            this.buttonShowProfile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listMedicalRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(378, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 33);
            this.label1.TabIndex = 40;
            this.label1.Text = "Hồ sơ";
            // 
            // listMedicalRecord
            // 
            this.listMedicalRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listMedicalRecord.BackgroundColor = System.Drawing.SystemColors.Control;
            this.listMedicalRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listMedicalRecord.Location = new System.Drawing.Point(29, 58);
            this.listMedicalRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listMedicalRecord.Name = "listMedicalRecord";
            this.listMedicalRecord.ReadOnly = true;
            this.listMedicalRecord.RowHeadersWidth = 62;
            this.listMedicalRecord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listMedicalRecord.Size = new System.Drawing.Size(796, 387);
            this.listMedicalRecord.TabIndex = 38;
            // 
            // buttonViewHSBA
            // 
            this.buttonViewHSBA.AutoSize = true;
            this.buttonViewHSBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewHSBA.Location = new System.Drawing.Point(188, 470);
            this.buttonViewHSBA.Name = "buttonViewHSBA";
            this.buttonViewHSBA.Size = new System.Drawing.Size(209, 40);
            this.buttonViewHSBA.TabIndex = 37;
            this.buttonViewHSBA.Text = "Xem hồ sơ bệnh án";
            this.buttonViewHSBA.UseVisualStyleBackColor = true;
            this.buttonViewHSBA.Click += new System.EventHandler(this.buttonViewHSBA_Click);
            // 
            // buttonViewHSBADV
            // 
            this.buttonViewHSBADV.AutoSize = true;
            this.buttonViewHSBADV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewHSBADV.Location = new System.Drawing.Point(414, 470);
            this.buttonViewHSBADV.Name = "buttonViewHSBADV";
            this.buttonViewHSBADV.Size = new System.Drawing.Size(284, 40);
            this.buttonViewHSBADV.TabIndex = 32;
            this.buttonViewHSBADV.Text = "Xem hồ sơ bệnh án dịch vụ";
            this.buttonViewHSBADV.UseVisualStyleBackColor = true;
            this.buttonViewHSBADV.Click += new System.EventHandler(this.buttonViewHSBADV_Click);
            // 
            // buttonShowProfile
            // 
            this.buttonShowProfile.AutoSize = true;
            this.buttonShowProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowProfile.Location = new System.Drawing.Point(307, 519);
            this.buttonShowProfile.Name = "buttonShowProfile";
            this.buttonShowProfile.Size = new System.Drawing.Size(238, 35);
            this.buttonShowProfile.TabIndex = 41;
            this.buttonShowProfile.Text = "Xem thông tin cá nhân";
            this.buttonShowProfile.UseVisualStyleBackColor = true;
            this.buttonShowProfile.Click += new System.EventHandler(this.buttonShowProfile_Click);
            // 
            // Researcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 566);
            this.Controls.Add(this.buttonShowProfile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listMedicalRecord);
            this.Controls.Add(this.buttonViewHSBA);
            this.Controls.Add(this.buttonViewHSBADV);
            this.Name = "Researcher";
            this.Text = "Researcher";
            ((System.ComponentModel.ISupportInitialize)(this.listMedicalRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView listMedicalRecord;
        private System.Windows.Forms.Button buttonViewHSBA;
        private System.Windows.Forms.Button buttonViewHSBADV;
        private System.Windows.Forms.Button buttonShowProfile;
    }
}
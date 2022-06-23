namespace Project_ATBM
{
    partial class MedicalRecord
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
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonViewHSBADV = new System.Windows.Forms.Button();
            this.label_Header = new System.Windows.Forms.Label();
            this.labelPatient = new System.Windows.Forms.Label();
            this.labelDiagnose = new System.Windows.Forms.Label();
            this.labelDoctor = new System.Windows.Forms.Label();
            this.labelMajor = new System.Windows.Forms.Label();
            this.comboBoxMajor = new System.Windows.Forms.ComboBox();
            this.comboBoxDoctor = new System.Windows.Forms.ComboBox();
            this.comboBoxPatient = new System.Windows.Forms.ComboBox();
            this.textBoxDiagnose = new System.Windows.Forms.TextBox();
            this.buttonViewHSBA = new System.Windows.Forms.Button();
            this.listMedicalRecord = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label_patient = new System.Windows.Forms.Label();
            this.textBoxMaHSBA = new System.Windows.Forms.TextBox();
            this.labelMaHSBA = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelCSYT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listMedicalRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.AutoSize = true;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.buttonAdd.Location = new System.Drawing.Point(645, 283);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(130, 40);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Thêm";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.buttonDelete.Location = new System.Drawing.Point(801, 283);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(130, 40);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Xóa";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonViewHSBADV
            // 
            this.buttonViewHSBADV.AutoSize = true;
            this.buttonViewHSBADV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.buttonViewHSBADV.Location = new System.Drawing.Point(645, 338);
            this.buttonViewHSBADV.Name = "buttonViewHSBADV";
            this.buttonViewHSBADV.Size = new System.Drawing.Size(286, 40);
            this.buttonViewHSBADV.TabIndex = 2;
            this.buttonViewHSBADV.Text = "Xem hồ sơ bệnh án dịch vụ";
            this.buttonViewHSBADV.UseVisualStyleBackColor = true;
            this.buttonViewHSBADV.Click += new System.EventHandler(this.buttonViewHSBADV_Click);
            // 
            // label_Header
            // 
            this.label_Header.Location = new System.Drawing.Point(0, 0);
            this.label_Header.Name = "label_Header";
            this.label_Header.Size = new System.Drawing.Size(100, 23);
            this.label_Header.TabIndex = 16;
            // 
            // labelPatient
            // 
            this.labelPatient.Location = new System.Drawing.Point(0, 0);
            this.labelPatient.Name = "labelPatient";
            this.labelPatient.Size = new System.Drawing.Size(100, 23);
            this.labelPatient.TabIndex = 15;
            // 
            // labelDiagnose
            // 
            this.labelDiagnose.AutoSize = true;
            this.labelDiagnose.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDiagnose.Location = new System.Drawing.Point(655, 206);
            this.labelDiagnose.Name = "labelDiagnose";
            this.labelDiagnose.Size = new System.Drawing.Size(69, 16);
            this.labelDiagnose.TabIndex = 6;
            this.labelDiagnose.Text = "Chẩn đoán";
            // 
            // labelDoctor
            // 
            this.labelDoctor.AutoSize = true;
            this.labelDoctor.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDoctor.Location = new System.Drawing.Point(655, 128);
            this.labelDoctor.Name = "labelDoctor";
            this.labelDoctor.Size = new System.Drawing.Size(44, 16);
            this.labelDoctor.TabIndex = 7;
            this.labelDoctor.Text = "Bác sĩ";
            // 
            // labelMajor
            // 
            this.labelMajor.AutoSize = true;
            this.labelMajor.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMajor.Location = new System.Drawing.Point(655, 89);
            this.labelMajor.Name = "labelMajor";
            this.labelMajor.Size = new System.Drawing.Size(37, 16);
            this.labelMajor.TabIndex = 8;
            this.labelMajor.Text = "Khoa";
            // 
            // comboBoxMajor
            // 
            this.comboBoxMajor.FormattingEnabled = true;
            this.comboBoxMajor.Location = new System.Drawing.Point(770, 86);
            this.comboBoxMajor.Name = "comboBoxMajor";
            this.comboBoxMajor.Size = new System.Drawing.Size(141, 24);
            this.comboBoxMajor.TabIndex = 9;
            // 
            // comboBoxDoctor
            // 
            this.comboBoxDoctor.FormattingEnabled = true;
            this.comboBoxDoctor.Location = new System.Drawing.Point(770, 126);
            this.comboBoxDoctor.Name = "comboBoxDoctor";
            this.comboBoxDoctor.Size = new System.Drawing.Size(141, 24);
            this.comboBoxDoctor.TabIndex = 10;
            // 
            // comboBoxPatient
            // 
            this.comboBoxPatient.FormattingEnabled = true;
            this.comboBoxPatient.Location = new System.Drawing.Point(770, 166);
            this.comboBoxPatient.Name = "comboBoxPatient";
            this.comboBoxPatient.Size = new System.Drawing.Size(141, 24);
            this.comboBoxPatient.TabIndex = 11;
            // 
            // textBoxDiagnose
            // 
            this.textBoxDiagnose.Location = new System.Drawing.Point(770, 206);
            this.textBoxDiagnose.Name = "textBoxDiagnose";
            this.textBoxDiagnose.Size = new System.Drawing.Size(141, 22);
            this.textBoxDiagnose.TabIndex = 12;
            // 
            // buttonViewHSBA
            // 
            this.buttonViewHSBA.AutoSize = true;
            this.buttonViewHSBA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.buttonViewHSBA.Location = new System.Drawing.Point(645, 395);
            this.buttonViewHSBA.Name = "buttonViewHSBA";
            this.buttonViewHSBA.Size = new System.Drawing.Size(286, 40);
            this.buttonViewHSBA.TabIndex = 13;
            this.buttonViewHSBA.Text = "Xem hồ sơ bệnh án";
            this.buttonViewHSBA.UseVisualStyleBackColor = true;
            this.buttonViewHSBA.Click += new System.EventHandler(this.buttonViewHSBA_Click);
            // 
            // listMedicalRecord
            // 
            this.listMedicalRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listMedicalRecord.BackgroundColor = System.Drawing.SystemColors.Control;
            this.listMedicalRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listMedicalRecord.Location = new System.Drawing.Point(13, 47);
            this.listMedicalRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listMedicalRecord.Name = "listMedicalRecord";
            this.listMedicalRecord.ReadOnly = true;
            this.listMedicalRecord.RowHeadersWidth = 62;
            this.listMedicalRecord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.listMedicalRecord.Size = new System.Drawing.Size(615, 388);
            this.listMedicalRecord.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(451, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Mai Xinh";
            // 
            // label_patient
            // 
            this.label_patient.AutoSize = true;
            this.label_patient.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_patient.Location = new System.Drawing.Point(655, 167);
            this.label_patient.Name = "label_patient";
            this.label_patient.Size = new System.Drawing.Size(69, 16);
            this.label_patient.TabIndex = 18;
            this.label_patient.Text = "Bệnh nhân";
            // 
            // textBoxMaHSBA
            // 
            this.textBoxMaHSBA.Location = new System.Drawing.Point(770, 244);
            this.textBoxMaHSBA.Name = "textBoxMaHSBA";
            this.textBoxMaHSBA.Size = new System.Drawing.Size(141, 22);
            this.textBoxMaHSBA.TabIndex = 20;
            // 
            // labelMaHSBA
            // 
            this.labelMaHSBA.AutoSize = true;
            this.labelMaHSBA.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaHSBA.Location = new System.Drawing.Point(655, 245);
            this.labelMaHSBA.Name = "labelMaHSBA";
            this.labelMaHSBA.Size = new System.Drawing.Size(113, 16);
            this.labelMaHSBA.TabIndex = 19;
            this.labelMaHSBA.Text = "Mã hồ sơ bệnh án";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "CSYT001",
            "CSYT002"});
            this.comboBox1.Location = new System.Drawing.Point(770, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(141, 24);
            this.comboBox1.TabIndex = 22;
            // 
            // labelCSYT
            // 
            this.labelCSYT.AutoSize = true;
            this.labelCSYT.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCSYT.Location = new System.Drawing.Point(655, 50);
            this.labelCSYT.Name = "labelCSYT";
            this.labelCSYT.Size = new System.Drawing.Size(71, 16);
            this.labelCSYT.TabIndex = 21;
            this.labelCSYT.Text = "Cơ sở y tế";
            // 
            // MedicalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labelCSYT);
            this.Controls.Add(this.textBoxMaHSBA);
            this.Controls.Add(this.labelMaHSBA);
            this.Controls.Add(this.label_patient);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listMedicalRecord);
            this.Controls.Add(this.buttonViewHSBA);
            this.Controls.Add(this.textBoxDiagnose);
            this.Controls.Add(this.comboBoxPatient);
            this.Controls.Add(this.comboBoxDoctor);
            this.Controls.Add(this.comboBoxMajor);
            this.Controls.Add(this.labelMajor);
            this.Controls.Add(this.labelDoctor);
            this.Controls.Add(this.labelDiagnose);
            this.Controls.Add(this.labelPatient);
            this.Controls.Add(this.label_Header);
            this.Controls.Add(this.buttonViewHSBADV);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Name = "MedicalRecord";
            this.Text = "MedicalRecord";
            this.Load += new System.EventHandler(this.MedicalRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listMedicalRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonViewHSBADV;
        private System.Windows.Forms.Label label_Header;
        private System.Windows.Forms.Label labelPatient;
        private System.Windows.Forms.Label labelDiagnose;
        private System.Windows.Forms.Label labelDoctor;
        private System.Windows.Forms.Label labelMajor;
        private System.Windows.Forms.ComboBox comboBoxMajor;
        private System.Windows.Forms.ComboBox comboBoxDoctor;
        private System.Windows.Forms.ComboBox comboBoxPatient;
        private System.Windows.Forms.TextBox textBoxDiagnose;
        private System.Windows.Forms.Button buttonViewHSBA;
        private System.Windows.Forms.DataGridView listMedicalRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_patient;
        private System.Windows.Forms.TextBox textBoxMaHSBA;
        private System.Windows.Forms.Label labelMaHSBA;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelCSYT;
    }
}
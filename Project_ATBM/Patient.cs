using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Project_ATBM
{
    public partial class Patient : Form
    {
        string user_name = "";
        string pass = "";
        public Patient(string username, string name, string password)
        {
            InitializeComponent();
            Header.Text = Header.Text + " " + name;
            user_name = username;
            pass = password;

            string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            ); User Id = " + user_name + ";password=" + pass;

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand cmdInfo = new OracleCommand();
            cmdInfo.CommandText = $"SELECT MaBN, MaCSYT, TenBN, CMND, TO_CHAR(NgaySinh, 'DD-MM-YYYY'), SoNha, TenDuong, QuanHuyen, TinhTP, TienSuBenh, TienSuBenhGD, DiUngThuoc FROM SOYTEX.BenhNhan WHERE MaBN = :username";
            cmdInfo.CommandType = CommandType.Text;
            cmdInfo.Connection = con;

            cmdInfo.Parameters.Add("username", user_name);
            cmdInfo.CommandType = CommandType.Text;
            OracleDataReader patientInfo = cmdInfo.ExecuteReader();

            while (patientInfo.Read())
            {
                if (!patientInfo.HasRows)
                    break;

                textBoxMaBN.Text = patientInfo.GetValue(0).ToString();
                textBoxMaCSYT.Text = patientInfo.GetValue(1).ToString();
                textBoxName.Text = patientInfo.GetValue(2).ToString();
                textBoxID.Text = patientInfo.GetValue(3).ToString();
                textBoxDOB.Text = patientInfo.GetValue(4).ToString();
                textBoxNum.Text = patientInfo.GetValue(5).ToString();
                textBoxStreet.Text = patientInfo.GetValue(6).ToString();
                textBoxDistrict.Text = patientInfo.GetValue(7).ToString();
                textBoxCity.Text = patientInfo.GetValue(8).ToString();
                textBoxMedicalHistory.Text = patientInfo.GetValue(9).ToString();
                textBoxFamilyMedicalHistory.Text = patientInfo.GetValue(10).ToString();
                textBoxAllergy.Text = patientInfo.GetValue(11).ToString();

            }
        }

        private void buttonUpdateInfo_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            ); User Id = " + user_name + ";password=" + pass;

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = con;
                cmd.CommandText = "SOYTEX.proc_update_BenhNhan";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("p_mabn", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxMaBN.Text;
                cmd.Parameters.Add(new OracleParameter("p_csyt", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxMaCSYT.Text;
                cmd.Parameters.Add(new OracleParameter("p_patientName", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxName.Text;
                cmd.Parameters.Add(new OracleParameter("p_id", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxID.Text;
                cmd.Parameters.Add(new OracleParameter("p_dob", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxDOB.Text;
                cmd.Parameters.Add(new OracleParameter("p_num", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxNum.Text;
                cmd.Parameters.Add(new OracleParameter("p_street", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxStreet.Text;
                cmd.Parameters.Add(new OracleParameter("p_district", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxDistrict.Text;
                cmd.Parameters.Add(new OracleParameter("p_city", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxCity.Text;
                cmd.Parameters.Add(new OracleParameter("p_medicalHistory", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxMedicalHistory.Text;
                cmd.Parameters.Add(new OracleParameter("p_familyMedicalHistory", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxFamilyMedicalHistory.Text;
                cmd.Parameters.Add(new OracleParameter("p_allergy", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxAllergy.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã thêm cập nhật thông tin bệnh nhân");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();
        }
    }
}

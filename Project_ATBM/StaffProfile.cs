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
    public partial class StaffProfile : Form
    {
        string user_name = "";
        string pass = "";
        public StaffProfile(string username, string name, string password)
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
            cmdInfo.CommandText = $"SELECT MaNV, HoTen, Phai, TO_CHAR(NgaySinh, 'DD-MM-YYYY'), CMND, QueQuan, SoDT, CSYT, VaiTro, ChuyenKhoa FROM SOYTEX.NhanVien WHERE MaNV = :username";
            cmdInfo.CommandType = CommandType.Text;
            cmdInfo.Connection = con;

            cmdInfo.Parameters.Add("username", user_name);
            cmdInfo.CommandType = CommandType.Text;
            OracleDataReader staffInfo = cmdInfo.ExecuteReader();

            while (staffInfo.Read())
            {
                if (!staffInfo.HasRows)
                    break;

                textBoxMaNV.Text = staffInfo.GetValue(0).ToString();
                textBoxName.Text = staffInfo.GetValue(1).ToString();
                textBoxSex.Text = staffInfo.GetValue(2).ToString();
                textBoxDOB.Text = staffInfo.GetValue(3).ToString();
                textBoxID.Text = staffInfo.GetValue(4).ToString();
                textBoxDOP.Text = staffInfo.GetValue(5).ToString();
                textBoxPhone.Text = staffInfo.GetValue(6).ToString();
                textBoxMaCSYT.Text = staffInfo.GetValue(7).ToString();
                textBoxPosition.Text = staffInfo.GetValue(8).ToString();
                textBoxMajor.Text = staffInfo.GetValue(9).ToString();

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
                cmd.CommandText = "SOYTEX.proc_update_NhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("p_HoTen", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxName.Text;
                cmd.Parameters.Add(new OracleParameter("p_Phai", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxSex.Text;
                cmd.Parameters.Add(new OracleParameter("p_NgaySinh", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxDOB.Text;
                cmd.Parameters.Add(new OracleParameter("p_CMND", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxID.Text;
                cmd.Parameters.Add(new OracleParameter("p_QueQUan", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxDOP.Text;
                cmd.Parameters.Add(new OracleParameter("p_SoDT", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxPhone.Text;
                cmd.Parameters.Add(new OracleParameter("p_CSYT", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxMaCSYT.Text;
                cmd.Parameters.Add(new OracleParameter("p_VaiTro", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxPosition.Text;
                cmd.Parameters.Add(new OracleParameter("p_ChuyenKhoa", OracleDbType.Varchar2, ParameterDirection.Input)).Value = textBoxMajor.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đã cập nhật thông tin nhân viên", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            con.Close();
        }
    }
}

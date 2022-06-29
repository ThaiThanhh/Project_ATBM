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
using System.Collections;

namespace Project_ATBM
{
    public partial class GrantPrivelegetoUser : Form
    {
        string connectionString = @"Data Source=(DESCRIPTION =
            (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))
            (CONNECT_DATA =
              (SERVER = DEDICATED)
              (SERVICE_NAME = XE)
            )
            );User Id = DB_ADMIN;password=1234";

        

        public GrantPrivelegetoUser(string username)
        {
            InitializeComponent();
            username_txtbox.Text = username;
        }

        private void GrantPrivelegetoUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user_name = username_txtbox.Text.Trim().ToUpper();
            string priv = comboBox1.SelectedItem.ToString().ToUpper();
            string table = textBox1.Text.Trim().ToUpper();
            string columns = "";
            int option;
            
            if (checkedListBox1.CheckedItems.Count == checkedListBox1.Items.Count || checkedListBox1.CheckedItems.Count ==0)
            {
                columns = "all";
            } 
            else
            {
                for (int x = 0; x < checkedListBox1.CheckedItems.Count; x++)
                {
                    columns = columns + checkedListBox1.CheckedItems[x].ToString();
                    if (x != checkedListBox1.CheckedItems.Count - 1)
                    {
                        columns = columns + ", ";
                    }
                }
            }    
            

            if (radioButton1.Checked == true)
            {
                option = 1;
            }
            else option = 0;

            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            try
            {
                OracleCommand cmd_drop_user = new OracleCommand();
                cmd_drop_user.Connection = con;
                cmd_drop_user.CommandText = "SOYTEX.proc_grant_priv";
                cmd_drop_user.CommandType = CommandType.StoredProcedure;
                cmd_drop_user.Parameters.Add(new OracleParameter("user_name", OracleDbType.Varchar2, ParameterDirection.Input)).Value = user_name;
                cmd_drop_user.Parameters.Add(new OracleParameter("p_table", OracleDbType.Varchar2, ParameterDirection.Input)).Value = table;
                cmd_drop_user.Parameters.Add(new OracleParameter("p_columns", OracleDbType.Varchar2, ParameterDirection.Input)).Value = columns;
                cmd_drop_user.Parameters.Add(new OracleParameter("priv", OracleDbType.Varchar2, ParameterDirection.Input)).Value = priv;
                cmd_drop_user.Parameters.Add(new OracleParameter("grant_option", OracleDbType.Int64, ParameterDirection.Input)).Value = option;
               
                cmd_drop_user.ExecuteNonQuery();
                MessageBox.Show("Cấp quyền thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(columns);
                MessageBox.Show(ex.Message);
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Column_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string priv = comboBox1.SelectedItem.ToString().ToUpper();

            checkedListBox1.ClearSelected();
            checkedListBox1.Hide();
            label4.Hide();

            if ((priv == "INSERT") || (priv == "UPDATE"))
            {
                selectColumn.Show();
            }
            else
            {
                selectColumn.Hide();
            }
               
        }

        private void selectColumn_Click(object sender, EventArgs e)
        {
            string table = textBox1.Text.Trim().ToUpper();
            selectColumn.Hide();
            label4.Show();
            checkedListBox1.Show();
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();

            OracleCommand getColumns = new OracleCommand();

            getColumns.CommandText = "SELECT column_name FROM USER_TAB_COLUMNS WHERE table_name = '" + table +"'";

            getColumns.Connection = con;

            getColumns.CommandType = CommandType.Text;

            OracleDataReader userList = getColumns.ExecuteReader();

            DataTable tableUserList = new DataTable();

            tableUserList.Load(userList);

            foreach (DataRow dr in tableUserList.Rows)
            {
                checkedListBox1.Items.Add(dr[0].ToString().ToUpper());
            }

            con.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

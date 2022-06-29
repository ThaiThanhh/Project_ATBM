using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_ATBM
{
    public partial class PanelPhanHe1 : Form
    {
        public PanelPhanHe1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLyUser form = new QLyUser();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QuanLyRole form = new QuanLyRole();
            form.Show();
        }

        private void PanelPhanHe1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminSOYTEX form = new AdminSOYTEX();
            this.Hide();
            form.Show();
        }
    }
}

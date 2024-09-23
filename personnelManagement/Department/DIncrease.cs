using personnelManagement.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personnelManagement.Department
{
    public partial class DIncrease : Form
    {
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public DIncrease()
        {
            InitializeComponent();
        }

        private void DIncrease_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = " insert into department values('" + numericUpDown1.Value + "','" + textBox9.Text + "','" + textBox8.Text + "','" + textBox7.Text + "',0) ";
            if (sqlExecute.AddDeleteAndModify(sql)>0)
            {
                MessageBox.Show("添加成功");
            }
            numericUpDown1.Value = 0;
            textBox9.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
        }
    }
}

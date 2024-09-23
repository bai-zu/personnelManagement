
using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace personnelManagement.Employee
{
    public partial class EmployeeHome : Form
    {
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public EmployeeHome()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EmployeeHome_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            sql = "SELECT * FROM employee";
            MySqlDataReader mySqlDataReader= sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                int i = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = mySqlDataReader["EId"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["EName"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["EGender"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["EAge"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["EDepartment"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = mySqlDataReader["EDuties"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = mySqlDataReader["EAccount"].ToString();
                dataGridView1.Rows[i].Cells[7].Value = mySqlDataReader["EPassword"].ToString();
            }
            sql = "SELECT * FROM department";
            mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                comboBox1.Items.Add(mySqlDataReader["DName"].ToString());
               //MessageBox.Show(mySqlDataReader["DName"].ToString());
            }
            }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Text=comboBox2.Text+"查找:";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeHome_Load(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (comboBox2.Text!="")
            {
                if (comboBox2.Text== "员工姓名")
                {
                    sql = "SELECT * FROM employee WHERE EName ='"+ textBox1.Text+"'";
                }
                else
                {
                    sql = "SELECT * FROM employee WHERE EId ='" + textBox1.Text+"'";
                }
                if (comboBox1.Text!="")
                {
                    sql += " and EDepartment="+ comboBox1.Text;
                }
                MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
                while (mySqlDataReader.Read())
                {
                    int i = this.dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = mySqlDataReader["EId"].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["EName"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["EGender"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["EAge"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["EDepartment"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = mySqlDataReader["EDuties"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = mySqlDataReader["EAccount"].ToString();
                    dataGridView1.Rows[i].Cells[7].Value = mySqlDataReader["EPassword"].ToString();
                }
                //MessageBox.Show(sql);

            }
            else
            {
                MessageBox.Show("请选择需要查询的类型");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            string a = (string)dataGridView1.Rows[Index].Cells[0].Value;
            if (Index < this.dataGridView1.Rows.Count - 1)
            {
                sql = "DELETE FROM employee WHERE EId='"+a+"'";
                if (sqlExecute.AddDeleteAndModify(sql)>0)
                {
                    MessageBox.Show("删除成功");
                    EmployeeHome_Load(sender, e);                   
                }
                //sqlExecute.AddDeleteAndModify(sql);
            }
        }
    }
}

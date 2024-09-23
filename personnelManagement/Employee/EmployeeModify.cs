using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using personnelManagement.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personnelManagement.Employee
{
    public partial class EmployeeModify : Form
    {
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public EmployeeModify()
        {
            InitializeComponent();
        }

        private void EmployeeModify_Load(object sender, EventArgs e)
        {
            sql = "SELECT * FROM department";
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                comboBox1.Items.Add(mySqlDataReader["DName"].ToString());
            }
            dataGridView1.Rows.Clear();
            sql = "SELECT * FROM employee";
            mySqlDataReader = sqlExecute.Query(sql);
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
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            string a = (string)dataGridView1.Rows[Index].Cells[0].Value;
            if (Index < this.dataGridView1.Rows.Count - 1)
            {
                sql = "SELECT * FROM employee WHERE  EId='" + a + "'";
                //MessageBox.Show(sql);

                MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
                while (mySqlDataReader.Read())
                {
                    label11.Text = mySqlDataReader["EId"].ToString();
                    textBox2.Text = mySqlDataReader["EName"].ToString();
                    if (mySqlDataReader["EGender"].ToString()=="男")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    textBox3.Text = mySqlDataReader["EAge"].ToString();
                    comboBox1.Text = mySqlDataReader["EDepartment"].ToString();
                    textBox4.Text = mySqlDataReader["EDuties"].ToString();
                    textBox5.Text = mySqlDataReader["EAccount"].ToString();
                    textBox6.Text = mySqlDataReader["EPassword"].ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string EDepartment = "";
            if (radioButton1.Checked)
            {
                EDepartment = "男";
            }
            else
            {
                EDepartment = "女";
            }
            sql = "UPDATE employee SET EName='" + textBox2.Text + "',EAge='" + textBox3.Text + "', EDepartment='" + EDepartment + "',EDuties='" + textBox4.Text + "',EAccount='" + textBox5.Text + "',EPassword='" + textBox6.Text + "' WHERE EId='" + label11.Text + "'";
            MessageBox.Show(sql);
            if (sqlExecute.AddDeleteAndModify(sql) > 0)
            {
                MessageBox.Show("修改成功");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox7.Text!="")
            {
                dataGridView1.Rows.Clear();
                sql = "SELECT * FROM employee WHERE  EId='" + textBox7.Text + "'";
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
               
            }
        }
    }
}

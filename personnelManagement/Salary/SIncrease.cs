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

namespace personnelManagement.Salary
{
    public partial class SIncrease : Form
    {
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public SIncrease()
        {
            InitializeComponent();
        }

        private void SIncrease_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            sql = "SELECT * FROM employee";
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                int i = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = mySqlDataReader["EId"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["EName"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["EDepartment"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["EDuties"].ToString();
                sql = "SELECT * FROM wages where Id='" + mySqlDataReader["WId"].ToString() + "'";
                MySqlDataReader mySqlDataReader1 = sqlExecute.Query(sql);
                while (mySqlDataReader1.Read())
                {
                    dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader1["salary"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = mySqlDataReader1["bonus"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = mySqlDataReader1["overtime"].ToString();
                    float wages = float.Parse(mySqlDataReader1["salary"].ToString()) + float.Parse(mySqlDataReader1["bonus"].ToString()) + float.Parse(mySqlDataReader1["overtime"].ToString());
                    dataGridView1.Rows[i].Cells[7].Value = wages;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            string a = (string)dataGridView1.Rows[Index].Cells[0].Value;
            if (Index < this.dataGridView1.Rows.Count - 1)
            {
                sql = "SELECT * FROM employee WHERE  EId='" + a + "'";
                MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
                while (mySqlDataReader.Read())
                {
                    label11.Text = mySqlDataReader["EId"].ToString();
                    label14.Text = mySqlDataReader["EName"].ToString();
                    label12.Text = mySqlDataReader["EDepartment"].ToString();
                    label13.Text = mySqlDataReader["EDuties"].ToString();
                    sql = "SELECT * FROM wages where Id='" + mySqlDataReader["WId"].ToString() + "'";
                    MySqlDataReader mySqlDataReader1 = sqlExecute.Query(sql);
                    numericUpDown1.Value = 0;
                    numericUpDown2.Value = 0;
                    numericUpDown3.Value = 0;
                    label18.Text = "0";
                    while (mySqlDataReader1.Read())
                    {
                        numericUpDown1.Value = decimal.Parse(mySqlDataReader1["salary"].ToString());
                        numericUpDown2.Value = decimal.Parse(mySqlDataReader1["bonus"].ToString());
                        numericUpDown3.Value = decimal.Parse(mySqlDataReader1["overtime"].ToString());
                        float wages = float.Parse(mySqlDataReader1["salary"].ToString()) + float.Parse(mySqlDataReader1["bonus"].ToString()) + float.Parse(mySqlDataReader1["overtime"].ToString());
                        label18.Text = wages.ToString();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "SELECT * FROM employee WHERE  EId='" + label11.Text + "'";
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                if (mySqlDataReader["WId"].ToString() != "")
                {
                    sql = "UPDATE wages SET salary='" + numericUpDown1.Value + "',bonus='" + numericUpDown2.Value + "',overtime='" + numericUpDown3.Value + "' where EId='" + label11.Text + "'";
                    if (sqlExecute.AddDeleteAndModify(sql) > 0)
                    {
                        MessageBox.Show("修改成功");
                    }
                }
                else
                {
                    sql = "insert into wages(salary,bonus,overtime) values('" + numericUpDown1.Value + "','" + numericUpDown2.Value + "','" + numericUpDown3.Value + "') ";

                    if (sqlExecute.AddDeleteAndModify(sql) > 0)
                    {
                        sql = "UPDATE employee SET WId='" + 3 + "' where EId='" + label11.Text + "'";
                        if (sqlExecute.AddDeleteAndModify(sql) > 0)
                        {
                            MessageBox.Show("添加成功");
                        }
                    }
                }
            }
            //label11.Text
           
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace personnelManagement.Salary
{
    public partial class SHome : Form
    {
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public SHome()
        {
            InitializeComponent();
        }

        private void SHome_Load(object sender, EventArgs e)
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
                sql = "SELECT * FROM wages where Id='"+ mySqlDataReader["WId"].ToString()+"'";
                MySqlDataReader mySqlDataReader1 = sqlExecute.Query(sql);
                while (mySqlDataReader1.Read())
                {
                    dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader1["salary"].ToString();
                    dataGridView1.Rows[i].Cells[5].Value = mySqlDataReader1["bonus"].ToString();
                    dataGridView1.Rows[i].Cells[6].Value = mySqlDataReader1["overtime"].ToString();
                    float wages = float.Parse(mySqlDataReader1["salary"].ToString())+ float.Parse(mySqlDataReader1["bonus"].ToString())+ float.Parse(mySqlDataReader1["overtime"].ToString());
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
                    while (mySqlDataReader1.Read())
                    {
                        label15.Text = mySqlDataReader1["salary"].ToString();
                        label16.Text = mySqlDataReader1["bonus"].ToString();
                        label17.Text = mySqlDataReader1["overtime"].ToString();
                        float wages = float.Parse(mySqlDataReader1["salary"].ToString()) + float.Parse(mySqlDataReader1["bonus"].ToString()) + float.Parse(mySqlDataReader1["overtime"].ToString());
                        label18.Text = wages.ToString();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (textBox1.Text != "")
            {
                sql = "SELECT * FROM employee WHERE  EId='" + textBox1.Text + "'";
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SHome_Load(sender,e);
        }
    }
}

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

namespace personnelManagement.Department
{
    public partial class DInformation : Form
    {
        AutoSizeFormClass autoSizeFormClass = new AutoSizeFormClass();
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public DInformation()
        {
            InitializeComponent();
        }

        private void DInformation_Load(object sender, EventArgs e)
        {
            autoSizeFormClass.x = this.Width;
            autoSizeFormClass.y = this.Height;
            autoSizeFormClass.setTag(this);
            /*DQuery dQuery = new DQuery();
            ConciseInformation conciseInformation = new ConciseInformation();
            dQuery.TopLevel = false;//将子窗体设置成非顶级控件
            conciseInformation.TopLevel = false;
            dQuery.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            conciseInformation.FormBorderStyle = FormBorderStyle.None;
            dQuery.Parent = panel4;//指定子窗体显示的容器
            conciseInformation.Parent = panel5;
            dQuery.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            conciseInformation.Dock = DockStyle.Fill;
            dQuery.Show();
            conciseInformation.Show();*/
            sql = "SELECT * FROM department";
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                int i = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value= mySqlDataReader["DId"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["DName"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["DPosition"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["DPhone"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["DPeople"].ToString();
                //MessageBox.Show(mySqlDataReader["DId"].ToString());
            }
        }

        private void DInformation_Resize(object sender, EventArgs e)
        {
            autoSizeFormClass.ReWinformLayout(Width, Height, this);
        }
      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.Text + "查询";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            sql = "SELECT * FROM department";
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                int i = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = mySqlDataReader["DId"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["DName"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["DPosition"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["DPhone"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["DPeople"].ToString();;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = "";
            if (comboBox1.Text== "部门编号")
            {
                a = "DId";
            }
            else if (comboBox1.Text== "部门名称")
            {
                a = "DName";
            }
            else if(comboBox1.Text== "部门位置")
            {
                a = "DPosition";
            }
            else if (comboBox1.Text == "部门电话")
            {
                a = "DPhone";
            }
            else
            {
                a = "DPeople";
            }
            dataGridView1.Rows.Clear();
            sql = "SELECT * FROM department WHERE "+a+"='"+ textBox1.Text+"'";

            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                int i = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = mySqlDataReader["DId"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["DName"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["DPosition"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["DPhone"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["DPeople"].ToString(); 
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            string a = (string)dataGridView1.Rows[Index].Cells[0].Value;
            if (Index < this.dataGridView1.Rows.Count - 1)
            {
                sql = "SELECT * FROM department WHERE  DId='" + a + "'";
                //MessageBox.Show(sql);

                MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
                while (mySqlDataReader.Read())
                {
                    //int i = this.dataGridView1.Rows.Add();
                    label9.Text = mySqlDataReader["DId"].ToString();
                    textBox2.Text = mySqlDataReader["DName"].ToString();
                    textBox3.Text = mySqlDataReader["DPosition"].ToString();
                    textBox4.Text = mySqlDataReader["DPhone"].ToString();
                    label13.Text = mySqlDataReader["DPeople"].ToString(); 
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label9.Text!="")
            {
                sql = "DELETE FROM department WHERE DId='"+label9.Text+"'";
                if (sqlExecute.AddDeleteAndModify(sql)>0)
                {
                    MessageBox.Show("删除成功");
                    button1_Click(sender, e);
                }
                //MessageBox.Show(sql);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sql = "UPDATE department SET DName='"+ textBox2.Text+"',DPosition='"+textBox3.Text+"',DPhone='"+textBox4.Text+"' WHERE DId='"+label9.Text+"'";
            if (sqlExecute.AddDeleteAndModify(sql)>0)
            {
                MessageBox.Show("修改成功");
                button1_Click(sender, e);
            }
            //MessageBox.Show(sql);
        }
    }
}

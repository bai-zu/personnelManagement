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

namespace personnelManagement.Sys
{
    public partial class SyHome : Form
    {
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public SyHome()
        {
            InitializeComponent();
        }

        private void SyHome_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            sql = "SELECT * FROM authority";
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                int i = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = mySqlDataReader["AId"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["AName"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["DAdministration"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["EAdministration"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["WAdministration"].ToString();
                dataGridView1.Rows[i].Cells[5].Value = mySqlDataReader["UAdministration"].ToString();
                dataGridView1.Rows[i].Cells[6].Value = mySqlDataReader["XAdministration"].ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            //string a = (string)dataGridView1.Rows[Index].Cells[0].Value;
            if (Index < this.dataGridView1.Rows.Count - 1)
            {
                if ((string)dataGridView1.Rows[Index].Cells[2].Value=="1")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                if ((string)dataGridView1.Rows[Index].Cells[3].Value == "1")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
                if ((string)dataGridView1.Rows[Index].Cells[4].Value == "1")
                {
                    checkBox3.Checked = true;
                }
                else
                {
                    checkBox3.Checked = false;
                }
                if ((string)dataGridView1.Rows[Index].Cells[5].Value == "1")
                {
                    checkBox4.Checked = true;
                }
                else
                {
                    checkBox4.Checked = false;
                }
                if ((string)dataGridView1.Rows[Index].Cells[6].Value == "1")
                {
                    checkBox5.Checked = true;
                }
                else
                {
                    checkBox5.Checked = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int DAdministration = 0, EAdministration = 0, WAdministration = 0, UAdministration = 0, XAdministration = 0;
            if (checkBox1.Checked)
            {
                DAdministration = 1;
            }
            if (checkBox2.Checked)
            {
                EAdministration = 1;
            }
            if (checkBox3.Checked)
            {
                WAdministration = 1;
            }
            if (checkBox4.Checked)
            {
                UAdministration = 1;
            }
            if (checkBox5.Checked)
            {
                XAdministration = 1;
            }
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            //string a = (string)dataGridView1.Rows[Index].Cells[0].Value;
            if (Index < this.dataGridView1.Rows.Count - 1)
            {
                string id = (string)dataGridView1.Rows[Index].Cells[0].Value;
                sql = "UPDATE authority SET DAdministration='" + DAdministration + "',EAdministration='" + EAdministration + "',WAdministration='" + WAdministration + "',XAdministration='" + XAdministration + "',UAdministration='" + UAdministration + "',UAdministration='" + UAdministration + "' where AId='" + id + "'";
                if (sqlExecute.AddDeleteAndModify(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                }
            }
        }
    }
}

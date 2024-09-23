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
    public partial class EIncrease : Form
    {
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public EIncrease()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string EGender = "男";
            if (radioButton1.Checked)
            {
                EGender = "男";
            }
            else
            {
                EGender = "女";
            }
            sql = " insert into employee(EId,EName,EGender,EAge,EDepartment,EDuties) values('" + textBox1.Text + "','" + textBox2.Text + "','" + EGender + "','" + textBox3.Text + "','"+ comboBox1.Text+"','"+ textBox4.Text+"') ";
            MessageBox.Show(sql);
            if (sqlExecute.AddDeleteAndModify(sql) > 0)
            {
                MessageBox.Show("添加成功");
            }
            sql = " insert into user(state,user_group,username,password,employee_id) values(0,'学生','" + textBox5.Text + "','" + textBox6.Text + "','"+ textBox1.Text+"') " ;
            if (sqlExecute.AddDeleteAndModify(sql) > 0)
            {
                MessageBox.Show("创建账号成功");
            }
            MessageBox.Show(sql);
        }

        private void EIncrease_Load(object sender, EventArgs e)
        {
            /*sql = "SELECT * FROM department";
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            if (mySqlDataReader.Read()) 
            {
                //comboBox1.Items.Add(mySqlDataReader["DName"].ToString());
                MessageBox.Show(mySqlDataReader["DName"].ToString());
            }*/
            sql = "SELECT * FROM department";
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                comboBox1.Items.Add(mySqlDataReader["DName"].ToString());
            }
        }
    }
}

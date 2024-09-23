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

namespace personnelManagement
{
    public partial class Form1 : Form
    {
        AutoSizeFormClass autoSizeFormClass = new AutoSizeFormClass();
        SqlExecute sqlExecute = new SqlExecute();

        public Form1()
        {
            InitializeComponent();
            //autoSizeFormClass.setControls
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM  user where username='"+ textBox1 .Text+ "' and password='"+textBox2.Text+"'";
            MySqlDataReader mySqlDataReader= sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                if (mySqlDataReader["state"].ToString() != null)
                {

                    //Console.WriteLine("管理员登录");
                    //MessageBox.Show("管理员登录");
                    homePage homePage = new homePage();
                    homePage.AId = mySqlDataReader["state"].ToString();
                    homePage.Group = mySqlDataReader["user_group"].ToString();
                    homePage.Pname = mySqlDataReader["nickname"].ToString();
                    homePage.userId = mySqlDataReader["user_id"].ToString();
                    homePage.Show();
                    this.Hide();
                    return;
                }
                
                //Console.WriteLine(mySqlDataReader["state"].ToString());
            }
            MessageBox.Show("账号或密码错误");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            autoSizeFormClass.x = this.Width;
            autoSizeFormClass.y = this.Height;
            autoSizeFormClass.setTag(this);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            autoSizeFormClass.ReWinformLayout(Width, Height, this);
        }
    }
}

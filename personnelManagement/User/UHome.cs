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

namespace personnelManagement.User
{
    public partial class UHome : Form
    {
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public static string password = "";
        public static string EId = "";
        public UHome()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void UHome_Load(object sender, EventArgs e)
        {
            string username = "";
            sql = "SELECT * FROM  user WHERE user_id='"+ homePage.userId+"'";
            //MessageBox.Show(sql);
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                username = mySqlDataReader["username"].ToString();
                password = mySqlDataReader["password"].ToString();
            }
            sql = "SELECT * FROM  employee WHERE EAccount='" + username + "' and EPassword='"+password+"'";
            MySqlDataReader mySqlDataReader1 = sqlExecute.Query(sql);
            while (mySqlDataReader1.Read())
            {
                EId= mySqlDataReader1["EId"].ToString();
                label2.Text= mySqlDataReader1["EId"].ToString();
                label7.Text = mySqlDataReader1["EName"].ToString();
                label16.Text= mySqlDataReader1["EAge"].ToString();
                label4.Text = mySqlDataReader1["EDepartment"].ToString();
                label15.Text = mySqlDataReader1["EDuties"].ToString();
                label17.Text = mySqlDataReader1["EGender"].ToString();
                sql = "SELECT * FROM wages where EId='" + mySqlDataReader1["EId"].ToString() + "'";
                MySqlDataReader mySqlDataReader2 = sqlExecute.Query(sql);
                while (mySqlDataReader2.Read())
                {
                    label20.Text = mySqlDataReader2["salary"].ToString();
                    label19.Text = mySqlDataReader2["bonus"].ToString();
                    label25.Text = mySqlDataReader2["overtime"].ToString();
                    float wages = float.Parse(mySqlDataReader2["salary"].ToString()) + float.Parse(mySqlDataReader2["bonus"].ToString()) + float.Parse(mySqlDataReader2["overtime"].ToString());
                    label18.Text = wages.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            UModify uModify = new UModify();
            uModify.TopLevel = false;//将子窗体设置成非顶级控件
            uModify.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            uModify.Parent = panel4;//指定子窗体显示的容器
            uModify.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            uModify.Show();
        }
    }
}

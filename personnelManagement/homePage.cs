
using MySql.Data.MySqlClient;
using personnelManagement.control;
using personnelManagement.Department;
using personnelManagement.Employee;
using personnelManagement.Salary;
using personnelManagement.Sys;
using personnelManagement.User;
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
    public partial class homePage : Form
    {
        public string Pname = "";
        public string Group = "";
        public string AId = "";
        public static string userId = "";
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public homePage()
        {
            InitializeComponent();
        }

        private void homePage_Load(object sender, EventArgs e)
        {
            panel5.Visible = !panel5.Visible;
            panel6.Visible = !panel6.Visible;
            panel7.Visible = !panel7.Visible;
            label7.Text = Pname+"("+Group+")";
            if (AId!="")
            {
                sql = "SELECT * FROM authority where AId='"+AId+"'";
                MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
                while (mySqlDataReader.Read())
                {
                    if (mySqlDataReader["DAdministration"].ToString()=="0")
                    {
                        button2.Visible = false;
                    }
                    if (mySqlDataReader["EAdministration"].ToString() == "0")
                    {
                        button5.Visible = false;
                    }
                    if (mySqlDataReader["WAdministration"].ToString() == "0")
                    {
                        button10.Visible = false;
                    }
                    if (mySqlDataReader["UAdministration"].ToString() == "0")
                    {
                        button13.Visible = false;
                    }
                    if (mySqlDataReader["XAdministration"].ToString() == "0")
                    {
                        button12.Visible = false;
                    }
                }
            }
            Home home = new Home();
            home.TopLevel = false;//将子窗体设置成非顶级控件
            home.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            home.Parent = panel4;//指定子窗体显示的容器
            home.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            home.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            button1.BackColor = Color.Cyan;
            button2.BackColor = Color.Gray;
            button6.BackColor = Color.DimGray;
            button7.BackColor = Color.DimGray;
            Home home = new Home();
            home.TopLevel = false;//将子窗体设置成非顶级控件
            home.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            home.Parent = panel4;//指定子窗体显示的容器
            home.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Cyan;
            button5.BackColor = Color.Gray;
            panel5.Visible = !panel5.Visible;
            button6.BackColor = Color.DimGray;
            button7.BackColor = Color.DimGray;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //清掉panel4中数据
            panel4.Controls.Clear();
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Gray;
            button6.BackColor=  Color.Cyan;
            button7.BackColor = Color.DimGray;
            DInformation dInformation = new DInformation();
            dInformation.TopLevel = false;//将子窗体设置成非顶级控件
            dInformation.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            dInformation.Parent = panel4;//指定子窗体显示的容器
            dInformation.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            dInformation.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Gray;
            button6.BackColor = Color.DimGray;
            button7.BackColor= Color.Cyan;
            DIncrease dIncrease = new DIncrease();
            dIncrease.TopLevel = false;//将子窗体设置成非顶级控件
            dIncrease.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            dIncrease.Parent = panel4;//指定子窗体显示的容器
            dIncrease.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            dIncrease.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Gray;
            button5.BackColor = Color.Cyan;
            panel6.Visible = !panel6.Visible;
            button6.BackColor = Color.DimGray;
            button7.BackColor = Color.DimGray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            button5.BackColor = Color.Gray;
            button4.BackColor = Color.Cyan;
            button8.BackColor = Color.Gray;
            button9.BackColor = Color.Gray;
            EmployeeHome employeeHome = new EmployeeHome();
            employeeHome.TopLevel = false;//将子窗体设置成非顶级控件
            employeeHome.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            employeeHome.Parent = panel4;//指定子窗体显示的容器
            employeeHome.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            employeeHome.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            button5.BackColor = Color.Gray;
            button4.BackColor = Color.Gray;
            button8.BackColor = Color.Cyan;
            button9.BackColor = Color.Gray;
            EIncrease employeeIncrease = new EIncrease();
            employeeIncrease.TopLevel = false;//将子窗体设置成非顶级控件
            employeeIncrease.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            employeeIncrease.Parent = panel4;//指定子窗体显示的容器
            employeeIncrease.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            employeeIncrease.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            button5.BackColor = Color.Gray;
            button4.BackColor = Color.Gray;
            button8.BackColor = Color.Gray;
            button9.BackColor = Color.Cyan;
            EmployeeModify employeeModify = new EmployeeModify();
            employeeModify.TopLevel = false;//将子窗体设置成非顶级控件
            employeeModify.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            employeeModify.Parent = panel4;//指定子窗体显示的容器
            employeeModify.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            employeeModify.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Gray;
            button5.BackColor = Color.Gray;
            panel7.Visible = !panel7.Visible;
            button6.BackColor = Color.DimGray;
            button7.BackColor = Color.DimGray;
            button10.BackColor = Color.Cyan;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            button10.BackColor = Color.Gray;
            button11.BackColor = Color.Gray;
            button3.BackColor = Color.Cyan;
            SHome sHome = new SHome();
            sHome.TopLevel = false;//将子窗体设置成非顶级控件
            sHome.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            sHome.Parent = panel4;//指定子窗体显示的容器
            sHome.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            sHome.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            button10.BackColor = Color.Gray;
            button11.BackColor = Color.Cyan;
            button3.BackColor = Color.Gray;
            SIncrease sIncrease = new SIncrease();
            sIncrease.TopLevel = false;//将子窗体设置成非顶级控件
            sIncrease.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            sIncrease.Parent = panel4;//指定子窗体显示的容器
            sIncrease.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            sIncrease.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            button12.BackColor = Color.Cyan;
            SyHome syHome = new SyHome();
            syHome.TopLevel = false;//将子窗体设置成非顶级控件
            syHome.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            syHome.Parent = panel4;//指定子窗体显示的容器
            syHome.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            syHome.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            button12.BackColor = Color.Cyan;
            UHome uHome = new UHome();
            uHome.TopLevel = false;//将子窗体设置成非顶级控件
            uHome.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            uHome.Parent = panel4;//指定子窗体显示的容器
            uHome.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            uHome.Show();
        }
    }
}

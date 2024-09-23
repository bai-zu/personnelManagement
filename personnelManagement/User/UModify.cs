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
    public partial class UModify : Form
    {
        SqlExecute sqlExecute = new SqlExecute();
        string sql = "";
        public UModify()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UHome.password == textBox1.Text)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    sql = "UPDATE employee SET EPassword='" + textBox2.Text + "' where EId='" + UHome.EId + "'";
                    if (sqlExecute.AddDeleteAndModify(sql) > 0)
                    {
                        sql = "UPDATE user SET password='" + textBox2.Text + "' where user_id='" + homePage.userId + "'";
                        if (sqlExecute.AddDeleteAndModify(sql) > 0)
                        {
                            UHome.password = textBox2.Text;
                            MessageBox.Show("修改成功");
                        }
                    }
                }
               
            }
            
        }
    }
}

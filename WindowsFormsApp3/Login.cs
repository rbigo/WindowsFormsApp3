using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox3.Text == "")//判断文本框内容
                {
                    MessageBox.Show("用户名或密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;  //退出事件
                }
                DB db = new DB();
                
string id = textBox2.Text.Trim();
                string password = textBox3.Text.Trim();
                string inquire = "select type from userlogin where id='" + id + "' ";

                string type = db.Inquire(inquire).Trim();
                
                string power = (type == "admin") ? "管理员" : "学生";
                db.Open();
                NewMethod(id, password, power, db);
                db.Close();


            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }

        private void NewMethod(string name, string password, string power, DB db)
        {
            
            string unpwd = "select * from userlogin where id='" + name + "' and password='" + password + "'";
            SqlDataReader dr = db.Sdr(unpwd);
            if (dr.Read())
            {
                Main Main = new Main();//创建主窗体对象
                Main.user = name.ToString();
                Main.power = power.ToString();
                Main.stuid = name.ToString();
                Main.Show();
            }
            else
            {
                textBox2.Text = "";//清空用户名
                textBox3.Text = "";//清空密码
                MessageBox.Show("用户名或密码错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}

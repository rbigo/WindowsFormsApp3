using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Main : Form
    {
        public string power;
        public string user;
        public string stuid;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text =  power +user + "你好，欢迎使用本系统！";
            if (power == "学生")
            {
                ToolStripMenuItem2.Enabled = false;
                ToolStripMenuItem3.Enabled = false;
                panel1.Visible = false;
                panel2.Visible = false;
            } 
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            personal personal = new personal();
            personal.stuid = stuid;
            personal.type = power;
            personal.ShowDialog();
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            user user = new user();
            user.ShowDialog();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Dorm dorm = new Dorm();
            dorm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into register (name,type,action,temperature,buildingnumber,data) values('"+text1.Text.Trim()+ "','waibu','" + comboBox1.Text.Trim() + "','" + text3.Text.Trim() + "','" + text4.Text.Trim() + "',' " + DateTime.Now.ToString("yyyy-MM-dd") + " ')";
            DB db = new DB();
            db.Open();
          int i=  db.OperateData(sql);
            db.Close();
            if (i>0)
            {
                MessageBox.Show("添加用户信息成功", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);              
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "insert into register (name,type,temperature,data) values('" + textBox1.Text.Trim() + "','xuesheng','" + textBox2.Text.Trim() + "',' " + DateTime.Now.ToString("yyyy-MM-dd") + " ')";
            DB db = new DB();
            db.Open();
            int i = db.OperateData(sql);
            db.Close();
            if (i > 0)
            {
                MessageBox.Show("记录学生体温成功", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

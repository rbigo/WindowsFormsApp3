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
    public partial class personal : Form
    {
        public personal()
        {
            InitializeComponent();
        }
        public string stuid;
        public string type;
        private void personal_Load(object sender, EventArgs e)
        {
            if (type=="管理员")
            {
                dataGridView1.Visible = false;
            }
            else
            {
                dataGridView1.Visible = true;
                NewMethod();
            }

        }

        private void NewMethod()
        {
            string sql = "select  p.floor as 楼层,p.name as 姓名,p.roomnumber as 房间号,p.pay 住宿费,p.warn as 警告记录,p.fix as 维修 from personal as p where stuid=" + stuid + " ";
            DB dB = new DB();
            dB.Open();
            dB.BindDataGridView(dataGridView1, sql);
            dB.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update userlogin set password='" + textBox1.Text.ToString().Trim() +"' where id='"+stuid+"'";
                DB db = new DB();
                db.Open();
               int a= db.OperateData(sql);
                db.Close();
                if (a>0)
                {
                    MessageBox.Show("密码更改成功", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update personal set fix ='"+textBox2.Text.ToString()+"' where stuid='" + stuid + "'";
                DB db = new DB();
                db.Open();
                int a = db.OperateData(sql);
                NewMethod();
                db.Close();
                if (a > 0)
                {
                    MessageBox.Show("提交成功", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }
    }
}

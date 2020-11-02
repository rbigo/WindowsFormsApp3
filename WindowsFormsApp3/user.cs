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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text.ToString().Trim();
                string floor = comboBox1.Text.ToString().Trim();
                string name = textBox2.Text.ToString().Trim();
                string sex = comboBox2.Text.ToString().Trim();
                string roomnumber = textBox3.Text.ToString().Trim();
                if (id.Length!=7)
                {
                    MessageBox.Show("学号格式输入错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string sql = "insert into personal (stuid,floor,name,sex,roomnumber) values(" + id + "," + floor + ",'" + name + "','" + sex + "'," + roomnumber + ")";
                    NewMethod(sql);
                }
            }
            catch (Exception )
            {

                MessageBox.Show("信息输入错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private static void NewMethod(string sql)
        {
            DB db = new DB();
            db.Open();
            int i = db.OperateData(sql);
            db.Close();
            if (i > 0)
            {
                MessageBox.Show("添加用户信息成功", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text.ToString().Trim();
                if (id.Length != 7)
                {
                    MessageBox.Show("学号输入错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string sql = "select * from personal where stuid="+id+"";
                DB db = new DB();
                db.Open();
                    db.BindDataGridView( dataGridView1,sql);    
                    try
                    {
                        DataSet ds= db.Find(sql);

                        comboBox1.Text = ds.Tables[0].Rows[0][1].ToString();
                        comboBox2.Text = ds.Tables[0].Rows[0][3].ToString();
                        textBox2.Text = ds.Tables[0].Rows[0][2].ToString();
                        textBox3.Text = ds.Tables[0].Rows[0][4].ToString();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("信息输入错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                  
                  
                    db.Close();
                }
                
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "update personal set floor ='" + comboBox1.Text.ToString() + "' ,name='"+textBox2.Text.ToString()+"' ,sex='"+comboBox2.Text.ToString()+"', roomnumber="+textBox3.Text.ToString()+" where stuid=" + textBox1.Text.ToString()+ " "; ;
                NewMethod1(sql);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message); 
            }
        }

        private static void NewMethod1(string sql)
        {
            DB db = new DB();
            db.Open();
            int i = db.OperateData(sql);
            db.Close();
            if (i > 0)
            {
                MessageBox.Show("修改用户信息成功", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text.ToString();
                string sql = "delete from personal where stuid=" + id + "";
                NewMethod2(sql);
            }
            catch (Exception ee )
            {
                MessageBox.Show($"输入有误 {ee.Message}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
        }

        private static void NewMethod2(string sql)
        {
            DB db = new DB();
            db.Open();
            int i = db.OperateData(sql);
            db.Close();
            if (i > 0)
            {
                MessageBox.Show("用户删除成功", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string adminid = textBox4.Text.ToString();
                string adminname = textBox5.Text.ToString();
                string sql = "insert into userlogin (id,password,type,name) values('aa','13142','admin','xxx')";
            }
            catch (Exception ee)
            {

               
            }
        }
    }
}

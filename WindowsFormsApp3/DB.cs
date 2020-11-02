using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class DB
    {
        string constring = " Data Source =.; Initial Catalog = DormSystem; Integrated Security = True";
        private SqlConnection scon = null;
        private SqlDataAdapter sda = null;
        private DataSet ds = null;
        private SqlCommand scmd = null;
        private SqlDataReader sdr = null;

        public void Open()//打开
        {
            scon = new SqlConnection(constring);
            scon.Open();
        }
        public string Inquire(string inquire)
        {
            scon = new SqlConnection(constring);
            scon.Open();
            SqlCommand sqlCommand = new SqlCommand(inquire, scon);
            string type = (string)sqlCommand.ExecuteScalar();
            scon.Close();
            return type;
        }
        public void Close()//关闭
        {
            if (sdr == null)
            {
                scon.Close();
            }
            else
            {
                sdr.Close();
                scon.Close();
            }
        }

        public void Dispose()//释放资源
        {
            scon.Dispose();
        }

        public DataSet Find(string usql)//查询并返回结果到内存
        {
            sda = new SqlDataAdapter(usql, scon);
            ds = new DataSet();
            sda.Fill(ds, "myTable");
            return ds;
        }

        public void Cmd(string usql)//执行命令
        {
            /* if (sdr.HasRows == null)
             {
                 sdr.Close();
             }*/

            scmd = new SqlCommand(usql, scon);
            scmd.ExecuteNonQuery();
        }

        public SqlDataReader Sdr(string usql)//返回一行记录
        {
            scmd = new SqlCommand(usql, scon);
            sdr = scmd.ExecuteReader();
            return sdr;
        }
        public int OperateData(string strsql)//增删查改
        {
             //打开数据库
            SqlCommand cmd = new SqlCommand(strsql, scon); //创建命令对象
            int i = (int)cmd.ExecuteNonQuery(); //执行SQL命令
            //关闭数据库
            return i; //返回受影响行数
        }
        public void BindDataGridView(DataGridView dgv, string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, scon);//创建数据适配器对象
            DataSet sd = new DataSet();//创建数据集对象
            sda.Fill(sd);       //填充数据库
            dgv.DataSource = sd.Tables[0];//绑定到数据表
            sd.Dispose();       //释放资源
        }
    }
}

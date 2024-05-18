using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS
{
    public partial class Logon : Form
    {
        public Logon()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "")
            {
                SQL dao = new SQL();
                string sql = $"select id from login where id='{textBox1.Text}'";
                IDataReader dc = dao.read(sql);
                if(dc.Read())//判断注册的用户id是否已存在
                {
                    MessageBox.Show("该用户已存在");
                }
                else
                {
                    logon();
                }
            }
            else
            {
                MessageBox.Show("有空项，请重新输入");
            }
        }
        public void logon()
        {
            if (radioButton1.Checked == true)//选中学生选项，级别为1
            {
                SQL dao = new SQL();
                string sql = $"insert into login values('{textBox1.Text}','{textBox2.Text }','1')";
                int n = dao.Execute(sql);//dao.Execute(sql)返回值为int类型
                sql = $"insert into db_user values('{textBox1.Text}','{textBox3.Text}','{textBox5.Text}','1')";
                dao.Execute(sql);
                if (n == 1)
                {
                    
                    MessageBox.Show("注册成功");
                    this.Close();
                }
                else if(n>1)
                {
                    MessageBox.Show("该用户名已存在");
                }
                else
                {
                    MessageBox.Show("注册失败");
                }
            }
            if (radioButton2.Checked == true)//选中老师选项，级别为2
            {
                SQL dao = new SQL();
                string sql = $"insert into login values('{textBox1.Text}','{textBox2.Text }','2')";
                int n = dao.Execute(sql);//dao.Execute(sql)返回值为int类型
                sql = $"insert into db_user values('{textBox1.Text}','{textBox3.Text}','{textBox5.Text}','2')";
                dao.Execute(sql);
                if (n == 1)
                {
                    
                    MessageBox.Show("注册成功");
                    this.Close();
                }
                else if (n > 1)
                {
                    MessageBox.Show("该用户名已存在");
                }
                else
                {
                    MessageBox.Show("该用户名已存在");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

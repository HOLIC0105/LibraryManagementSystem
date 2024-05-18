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
    
    
    public partial class Log : Form
    {
        public Log()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Logon logon = new Logon();
            this.Hide();
            logon.ShowDialog();
            this.Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("用户名或密码为空，请重新输入");
            }
            
        }
        //
        

        public void Login()
        {
            if(radioButtonUser.Checked == true)//选中用户选项
            {
                SQL dao = new SQL();
                string sql = "select * from login where id ='"+textBox1.Text+"' and password = '"+textBox2.Text+ "'and ulevel != 3";
                //string sql = String.Format("select * from login where id = '{0}' and password = '{1}' and ulevel != 3,textBox1.Text,textBox2.Text);
                //string sql = $"select * from login where id ='{ textBox1.Text}' and password = '{ textBox1.Text}'and ulevel != 3";
                IDataReader dc = dao.read(sql);//使用SQL语句对数据库进行查询
                if(dc.Read())//dc.read()为读取操作，Boolean类型
                {//为真时，登录成功
                    //MessageBox.Show("登录成功");
                    User user = new User(textBox1.Text);//对将要跳转窗体进行定义
                    this.Hide();//打开用户界面后，把登录界面隐藏
                    user.ShowDialog();//以对话框的形式弹出窗体
                    this.Show();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误");//界面提示
                }
                dao.SQLClose();
            }
            if(radioButtonAdmin.Checked == true)//选中管理员选项
            {
                SQL dao = new SQL();
                string sql = "select * from login where id ='" + textBox1.Text + "' and password = '" + textBox2.Text + "' and ulevel = 3";
                IDataReader dc = dao.read(sql);
                if (dc.Read())//dc.read()为读取操作，Boolean类型
                {//为真时，登录成功
                    //MessageBox.Show("登录成功");
                    Admin admin = new Admin();//
                    this.Hide();
                    admin.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("用户名或密码错误");
                }
                dao.SQLClose();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

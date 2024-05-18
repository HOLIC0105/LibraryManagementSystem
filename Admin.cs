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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Adminuser adminuser = new Adminuser();
            this.Hide();
            adminuser.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin_book adminbook = new Admin_book();//实例化
            this.Hide();
            adminbook.ShowDialog();//以对话窗的形式显示图书管理页面
            this.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Adminlend adminlend = new Adminlend();
            this.Hide();
            adminlend.ShowDialog();
            this.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Adminorder adminorder = new Adminorder();
            this.Hide();
            adminorder.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Adminmessage adminmessage = new Adminmessage();
            this.Hide();
            adminmessage.ShowDialog();
            this.Show();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            Adminnotice adminnotice = new Adminnotice();
            this.Hide();
            adminnotice.ShowDialog();
            this.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SQL dao = new SQL();
            string sql = $"select * from listbook ";//查询当前用户的借书信息
            IDataReader dc = dao.read(sql);//使用SQL语句对数据库进行查询
            if (dc.Read())//dc.read()为读取操作，Boolean类型
            {//为真时，有未归还的书
                Adminlistbook adminlistbook = new Adminlistbook();
                this.Hide();
                adminlistbook.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("您没有未编目的书籍");
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admincost admincost = new Admincost();
            this.Hide();
            admincost.ShowDialog();
            this.Show();
        }
    }
}

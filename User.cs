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
    public partial class User : Form
    {
        private readonly string UserID;
        public User(string UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }

        private void User_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//查询图书按钮
        {
            UserSelect userSelect = new UserSelect(UserID);
            this.Hide();
            userSelect.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)//预约图书按钮
        {
            Userorder userorder = new Userorder(UserID);
            this.Hide();
            userorder.ShowDialog();
            this.Show();
        }

        private void button7_Click(object sender, EventArgs e)//返回按钮
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)//归还图书按钮
        {
            SQL dao = new SQL(); 
            string sql = $"select * from lendbook where  LendUserID='{UserID }'";//查询当前用户的借书信息
            IDataReader dc = dao.read(sql);//使用SQL语句对数据库进行查询
            if (dc.Read())//dc.read()为读取操作，Boolean类型
            {//为真时，有未归还的书
                Userlend booklend = new Userlend(UserID);
                this.Hide();
                booklend.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("您没有未归还的书籍");
            }
        }

        private void button8_Click(object sender, EventArgs e)//个人信息按钮
        {
            Usernews usernews = new Usernews(UserID);
            this.Hide();
            usernews.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)//帮助按钮
        {
            Userhelp userhelp = new Userhelp();
            this.Hide();
            userhelp.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)//公告栏按钮
        {
            Usernotice usernotice = new Usernotice();
            this.Hide();
            usernotice.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)//留言按钮
        {
            Usermessage usermessage = new Usermessage(UserID);
            this.Hide();
            usermessage.ShowDialog();
            this.Show();
        }
    }
    
}

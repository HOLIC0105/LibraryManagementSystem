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
 
    public partial class Usernews : Form
    {
        private readonly string UserID;
        public Usernews(string UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
            TableID();
            TableName();
            TableAge();
            TableLevel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Usernews_Load(object sender, EventArgs e)
        {

        }
        public void TableID()
        {
            SQL dao = new SQL();
            string sql = $"select id from db_user where id='{UserID}'";//查询数据库用户信息表里的学号
            IDataReader dc = dao.read(sql);
            if (dc.Read())
            {
                label6.Text = dc["id"].ToString();//将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            else 
            {
                MessageBox.Show("发生错误");
            }

            dc.Close();//断开连接
            dao.SQLClose();
        }
        public void TableName()
        {
            SQL dao = new SQL();
            string sql = $"select name from db_user where id='{UserID}'";//查询数据库用户信息表里的姓名
            IDataReader dc = dao.read(sql);
            if (dc.Read())
            {
                label7.Text = dc["name"].ToString();//将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }
        public void TableAge()
        {
            SQL dao = new SQL();
            string sql = $"select age from db_user where id='{UserID}'";//查询数据库用户信息表里的年龄
            IDataReader dc = dao.read(sql);
            if (dc.Read())
            {
                label9.Text = dc["age"].ToString();//将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }
        public void TableLevel()
        {
            SQL dao = new SQL();
            string sql = $"select ulevel from db_user where id='{UserID}'";//查询数据库用户信息表里的用户等级
            IDataReader dc = dao.read(sql);
            if (dc.Read())
            {
                label10.Text = dc["ulevel"].ToString();//将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }
    }
}

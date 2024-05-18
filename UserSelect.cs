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
    public partial class UserSelect : Form
    {
        private readonly string UserID;
        public UserSelect(string UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }

        private void UserSelect_Load(object sender, EventArgs e)
        {
            Table();
            string Bid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书号
            string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书名
            label2.Text = "书号：" + Bid + "  书名：" + Bname;

        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = "select * from book";//查询数据库图书信息表里的全部信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }
        public void TableID()//书号查询
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = $"select * from book where id ='{textBox2.Text}'";//查询数据库图书信息表里的全部信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }
        //根据书名查询
        public void TableName()//书名查询
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = $"select * from book where name like '%{textBox1.Text}%'";//like语句模糊查询信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TableID();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)//用户借书功能
        {
            string Bid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书号
            string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书名
            string Bpress = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//获取选中图书的书名
            int num =int.Parse( dataGridView1.SelectedRows[0].Cells[4].Value.ToString());//获取选中图书的库存
            if(num < 1)
            {
                MessageBox.Show("该书籍库存不足，请及时通知管理员");
            }
            else
            {
                string sql = $"insert into lendbook(LendUserID,LendBookID,LendBookName,LendBookPress,LendTime) values ('{UserID}', '{Bid}',  '{Bname}', '{Bpress}', getdate());update book set number = number - 1 where id = '{Bid}'";
                SQL dao = new SQL();
                if(dao.Execute(sql)>1)//执行了两条SQL语句,大于1才是成功
                {
                    MessageBox.Show("借书成功");
                    Table();
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string Bid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书号
            string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书名
            label2.Text = "书号：" + Bid + "  书名：" + Bname;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            Table();
        }
    }
}

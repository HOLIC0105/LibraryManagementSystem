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
    public partial class Userorder : Form
    {
        private readonly string UserID;
        public Userorder(string UserID)
        {
            InitializeComponent();
            this.UserID = UserID;
        }
        public Userorder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)//预约图书按钮
        {
            
            SQL dao = new SQL();
            string sql = $"select Uid from orderbook where Uid='{UserID}'and Bname='{textBox1.Text}'and Bauthor='{textBox2.Text}'";
            int m = dao.Execute(sql);
            if (m< 1)//判断该图书该用户是否已预约过
            {
                sql = $"insert into orderbook values('{UserID}','{textBox1.Text}','{textBox2.Text}','{textBox3.Text}')";
                int n = dao.Execute(sql);//dao.Execute(sql)返回值为int类型
                if (n > 0)
                {
                    MessageBox.Show("图书预约成功");
                    Table();
                }
                else
                {
                    MessageBox.Show("图书预约失败");
                }
            }
            else
            {
                MessageBox.Show("你已预约过该图书");
            }
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = $"select * from orderbook where Uid = '{UserID}'";//查询数据库图书信息表里的全部信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            Table();

        }

        private void button3_Click(object sender, EventArgs e)//获取选中的预约记录信息
        {
            SQL dao = new SQL();
            string sql = $"select * from orderbook where Uid = '{UserID}'";
            IDataReader dc = dao.read(sql);
            if(dc.Read())
            {
                string Bname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书名
                string Bauthor = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的作者
                string Bpress = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中图书的出版社
                textBox1.Text = Bname;
                textBox2.Text = Bauthor;
                textBox3.Text = Bpress;
            }
            else
            {
                MessageBox.Show("你并没有预约记录");
            }
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string Bname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书名
                string Bauthor = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的作者
                string Bpress = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中图书的出版社
                textBox1.Text = Bname;
                textBox2.Text = Bauthor;
                textBox3.Text = Bpress;
                DialogResult dr = MessageBox.Show("是否确认删除？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from orderbook where Uid = '{UserID}'and Bname='{Bname}'and Bauthor='{Bauthor}'";
                    SQL dao = new SQL();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
            catch
            {
                MessageBox.Show("请选中想要删除的预约记录");
            }
        }
    }
}

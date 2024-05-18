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
    public partial class Adminlistbook : Form
    {
        public Adminlistbook()
        {
            InitializeComponent();
        }
        public void Table()//刷新
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = "select * from listbook";//查询数据库图书信息表里的全部信息
            IDataReader dc = dao.read(sql);
            if(dc.Read())
            {

           
                while (dc.Read())
                {
                    dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
                    //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
                }
                dc.Close();//断开连接
                dao.SQLClose();
            }
            else
            {
                MessageBox.Show("没有未编目的图书");
            }
        }
        private void button8_Click(object sender, EventArgs e)//获取选中编目信息
        {
            string Bname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书名
            string Bauthor = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的作者
            string Bpress = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中图书的出版社
            string Bnumber = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//获取选中图书的库存
            label3.Text = Bname;
            label8.Text = Bauthor;
            label9.Text = Bpress;
            label10.Text = Bnumber;
        }

        private void button1_Click(object sender, EventArgs e)//编目图书信息
        {
            string Bname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书名
            string Bauthor = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的作者
            string Bpress = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中图书的出版社
            string Bnumber = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//获取选中图书的库存
            string Bid = textBox1.Text;
            if (textBox1.Text != "")
            {
                SQL dao = new SQL();
                string sql = $"select id from book where id='{textBox1.Text}'";
                int m = dao.Execute(sql);
                IDataReader dc = dao.read(sql);//使用SQL语句对数据库进行查询
                if (dc.Read())//dc.read()为读取操作，Boolean类型
                {
                    MessageBox.Show($"该图书:{textBox1.Text}已存在");
                }
                else
                {
                    sql = $"insert into book values('{textBox1.Text}','{Bname}','{Bauthor}','{Bpress}',{Bnumber})";
                    //库存为int类型可以不加单引号
                    int n = dao.Execute(sql);//dao.Execute(sql)返回值为int类型
                    if (n > 0)
                    {
                        
                        sql = $"delete from listbook where name = '{Bname}'and author = '{Bauthor}'and press = '{Bpress}'";
                        dao.Execute(sql);
                        MessageBox.Show("图书添加成功");
                    }
                    else
                    {
                        MessageBox.Show("图书添加失败");
                    }
                    textBox1.Text = "";//添加图书后，把每一个框置为空
                    Table();
                }
            }
            else
            {
                MessageBox.Show("书号不能为空");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Adminlistbook_Load(object sender, EventArgs e)
        {
            Table();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string Bname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书名
            string Bauthor = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的作者
            string Bpress = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中图书的出版社
            string Bnumber = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//获取选中图书的库存
            label3.Text = Bname;
            label8.Text = Bauthor;
            label9.Text = Bpress;
            label10.Text = Bnumber;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Bname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书名
            string Bauthor = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的作者
            string Bpress = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中图书的出版社
            string Bnumber = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//获取选中图书的库存
            SQL dao = new SQL();
            string sql = $"delete from listbook where name = '{Bname}'and author = '{Bauthor}'and press = '{Bpress}'";
            DialogResult dr = MessageBox.Show("是否确认删除？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
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
    }
}

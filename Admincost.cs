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
    public partial class Admincost : Form
    {
        public Admincost()
        {
            InitializeComponent();
        }
        public void Table()//刷新
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = "select * from listbook";//查询数据库编目信息表里的全部信息
            IDataReader dc = dao.read(sql);
            if (dc.Read())
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Table();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!=""&&textBox4.Text!="")
            {

            string Bname = textBox1.Text;//获取添加图书的书名
            string Bauthor = textBox2.Text;//获取添加图书的作者
            string Bpress = textBox3.Text;//获取添加图书的出版社
            string Bnumber = textBox4.Text;//获取添加图书的库存
            SQL dao = new SQL();
            string sql = $"insert into listbook values('{Bname}','{Bauthor}','{Bpress}',{Bnumber})";
                int n = dao.Execute(sql);//dao.Execute(sql)返回值为int类型
                if (n > 0)
                {
                    MessageBox.Show("图书添加成功");

                }
                else
                {
                    MessageBox.Show("图书添加失败");
                }
                textBox1.Text = "";//添加图书后，把每一个框置为空
                Table();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("书名不能为空");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("作者不能为空");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("出版社不能为空");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("库存不能为空");
            }

        }

        private void Admincost_Load(object sender, EventArgs e)
        {
            Table();
        }
    }
}

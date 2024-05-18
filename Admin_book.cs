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
    public partial class Admin_book : Form
    {
        public Admin_book()
        {
            InitializeComponent();
            
        }
        private void Admin_book_Load_1(object sender, EventArgs e)
        {
            Table();//打开界面自动显示图书信息表里的信息
            string Bid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书号
            string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书名
            label2.Text = "书号：" + Bid + "  书名：" + Bname;
            textBox1.Text = Bid;
        }
        private void button1_Click(object sender, EventArgs e)//添加图书按钮
        {
            //AdminAddbook adminAddbook = new AdminAddbook();
            //this.Hide();
            //adminAddbook.ShowDialog();
            //this.Show();
            //Table();
            string Bid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书号
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                
                SQL dao = new SQL();
                /*string sql = $"select id from book where id='{textBox1.Text}'";
                int m = dao.Execute(sql);
                if (m > 0)
                {
                    sql = $"update book set namber ='{textBox5.Text}'where id='{Bid}'";
                    dao.Execute(sql);
                    MessageBox.Show($"图书:{Bid}的库存已增加:{textBox5.Text}");

                }
                else
                */
                string sql = $"select id from book where id='{textBox1.Text}'";
                int m = dao.Execute(sql);
                IDataReader dc = dao.read(sql);//使用SQL语句对数据库进行查询
                if (dc.Read())//dc.read()为读取操作，Boolean类型
                {
                    MessageBox.Show($"该图书:{textBox1.Text}已存在,若要添加库存，请在修改功能添加");
                }
                else
                {
                    sql = $"insert into book values('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}',{textBox1.Text})";
                    //库存为int类型可以不加单引号
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
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    Table();
                }
                
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("书号不能为空");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("书名不能为空");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("作者不能为空");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("出版社不能为空");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("添加图书数目不能为空");
            }

        }
        private void Admin_book_load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //从数据库读取数据显示在表格控件里
        public void Table()//刷新
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

        private void button3_Click(object sender, EventArgs e)//删除按钮
        {
            try
            {
                string Bid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书号
                string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书名
                label2.Text = "书号：" + Bid + "  书名：" + Bname;
                DialogResult dr = MessageBox.Show("是否确认删除？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from book where id = '{Bid}'";
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
                MessageBox.Show("请选中想要删除的图书");
            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)//显示框点击事件，显示选中的图书的书号与书名
        {
            string Bid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书号
            string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书名
            label2.Text = "书号：" + Bid + "  书名：" + Bname;
            textBox1.Text = Bid;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//修改按钮
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                //AdminUpdatebook adminUpdatebook = new AdminUpdatebook();
                //adminUpdatebook.ShowDialog();
                //this.Show();
                string Bid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书号
                string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书名
                SQL dao = new SQL();
                string sql = $"update book set id='{textBox1.Text}',name='{textBox2.Text}',author='{textBox3.Text}',press='{textBox4.Text}',number='{textBox5.Text}' where id='{Bid}'";
                if(dao.Execute(sql)>0)
                {
                    MessageBox.Show("修改成功");
                    Table();//修改后对表里数据进行刷新
                }
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("书号不能为空");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("书名不能为空");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("作者不能为空");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("出版社不能为空");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("修改库存图书数目不能为空");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//刷新按钮
        {
            Table();//对表里数据进行刷新
            textBox1.Text = "";//将输入框清空
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
        private void button6_Click(object sender, EventArgs e)
        {
            TableID();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            TableName();
        }
        //根据书号查询
        public void TableID()
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = $"select * from book where id ='{textBox7.Text}'";//查询数据库图书信息表里的全部信息
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
        public void TableName()
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = $"select * from book where name like '%{textBox6.Text}%'";//like语句模糊查询信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)//获取选中信息
        {
            string Bid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书号
            string Bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中图书的书名
            string Bauthor = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中图书的作者
            string Bpress = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//获取选中图书的出版社
            string Bnumber = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();//获取选中图书的库存
            textBox1.Text = Bid;
            textBox2.Text = Bname;
            textBox3.Text = Bauthor;
            textBox4.Text = Bpress;
            textBox5.Text = Bnumber;

        }
    }
}

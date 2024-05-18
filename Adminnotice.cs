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
    public partial class Adminnotice : Form
    {
        public Adminnotice()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = "select * from notice";//查询数据库信息表里的全部信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string Nid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中公告的序号
            label2.Text = "公告序号：" + Nid;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQL dao = new SQL();
            string Nid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中公告的ID（string类型）
            DialogResult dr = MessageBox.Show("是否确认删除？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                string sql = $"delete from notice where id = '{Nid}'";
                int m = dao.Execute(sql);
                if (m > 0)
                {
                    MessageBox.Show("公告删除成功");
                    textBox1.Text = "";
                    Table();
                }
                else
                {
                    MessageBox.Show("公告删除失败");
                }
            }
            dao.SQLClose();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SQL dao = new SQL();
                string sql = $"select * from notice where id ='{textBox2.Text}'";//查询数据库信息表里的全部信息
                int n = dao.Execute(sql);
                if(n != 0)
                {
                    string sqL = $"insert into notice values('{textBox2.Text}','{textBox1.Text}', getdate())";
                    //库存为int类型可以不加单引号
                    int m = dao.Execute(sqL);//dao.Execute(sql)返回值为int类型
                    if (m > 0)
                    {
                        MessageBox.Show("公告添加成功");
                        textBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("公告添加失败");
                    }
                    textBox1.Text = "";//添加公告后，把框置为空
                    Table();
                    dao.SQLClose();
                }
                else
                {
                    MessageBox.Show("该公告号已存在");
                }

            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("公告内容不能为空");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string Nid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中公告的序号
            SQL dao = new SQL();
            string sql = $"select * from notice where id ='{Nid}'";//查询数据库图书信息表里的全部信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                listBox1.Items.Add(dc[1].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            Table();
        }

        private void Adminnotice_Load(object sender, EventArgs e)
        {
            Table();
            string Nid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中图书的书号
            label2.Text = "公告序号：" + Nid ;
        }
    }
}

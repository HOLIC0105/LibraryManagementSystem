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
    public partial class Adminuser : Form
    {
        public Adminuser()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Adminuser_Load(object sender, EventArgs e)
        {
            Table();//打开界面自动显示信息表里的信息
            string Uid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中用户的ID
            string Uname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中用户的姓名
            label2.Text = "用户ID：" + Uid + "  用户姓名名：" + Uname;
            textBox1.Text = Uid;
        }
        public void Table()
        {
            dataGridView1.Rows.Clear();//清空表格里的旧数据
            SQL dao = new SQL();
            string sql = "select * from db_user";//查询数据库信息表里的全部信息
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(), dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
                //将数据库里面的信息显示出来，也可以写成dc["id"].ToString等
            }
            dc.Close();//断开连接
            dao.SQLClose();
        }


        private void button2_Click(object sender, EventArgs e)//修改用户信息
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                string Uid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中用户的ID
                string Uname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中用户的姓名
                SQL dao = new SQL();
                string sql = $"update db_user set id='{textBox1.Text}',name='{textBox2.Text}',age='{textBox3.Text}',ulevel='{textBox4.Text}' where id='{Uid}'";
                if (dao.Execute(sql) > 0)
                {
                    MessageBox.Show("用户信息修改成功");
                    Table();//修改后对表里数据进行刷新
                }
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("用户ID不能为空");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("用户姓名不能为空");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("用户年龄不能为空");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("用户等级不能为空");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)//删除用户信息
        {
            try
            {
                string Uid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中用户的ID
                string Uname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中用户的姓名
                DialogResult dr = MessageBox.Show("是否确认删除？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from db_user where id = '{Uid}';delete from login where id = '{Uid}'";
                    SQL dao = new SQL();
                    if (dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("用户信息删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("用户信息删除失败");
                    }
                }
            }
            catch
            {
                MessageBox.Show("请选中想要删除的用户");
            }
        }

        private void Adminuser_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string Uid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中用户的ID
            string Uname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中用户的姓名
            label2.Text = "用户ID：" + Uid + "  用户姓名名：" + Uname;
            textBox1.Text = Uid;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Uid = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取选中用户的ID
            string Uname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取选中用户的姓名
            string Uage = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取选中用户的年龄
            string Ulevel = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//获取选中用户的等级
            textBox1.Text = Uid;
            textBox2.Text = Uname;
            textBox3.Text = Uage;
            textBox4.Text = Ulevel;
        }
    }
}

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
    public partial class AdminAddbook : Form
    {
        public AdminAddbook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&&textBox2.Text!="" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                SQL dao = new SQL();
                string sql = $"insert into book values('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}',{textBox1.Text})";
                //库存为int类型可以不加单引号
                int n = dao.Execute(sql);//dao.Execute(sql)返回值为int类型
                if(n > 0)
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

        private void AdminAddbook_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class AdminUpdatebook : Form
    {
        public AdminUpdatebook()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public AdminUpdatebook(string id,string name,string author,string press,string number)
        {
            InitializeComponent();
            textBox1.Text = id;
            textBox2.Text = name;
            textBox3.Text = author;
            textBox4.Text = press;
            textBox5.Text = number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using demoWinform.Helper;
namespace demoWinform
{
    public partial class Mainfrm : Form
    {
        public Mainfrm()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(textBox1.Text);
            int num2 = Convert.ToInt32(textBox2.Text);
            int kq = MyMath.Add(num1, num2);
            txtresult.Text = kq.ToString();
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(textBox1.Text);
            int num2 = Convert.ToInt32(textBox2.Text);
            int kq = MyMath.Sub(num1, num2);
            txtresult.Text = kq.ToString();
        }

        private void btnmul_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(textBox1.Text);
            int num2 = Convert.ToInt32(textBox2.Text);
            int kq = MyMath.Mul(num1, num2);
            txtresult.Text = kq.ToString();
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(textBox1.Text);
            int num2 = Convert.ToInt32(textBox2.Text);
            int kq = MyMath.Div(num1, num2);
            txtresult.Text = kq.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoBrowser
{
    public partial class Form1 : Form
    {
        String DefaulURL = "http://google.com";
        public Form1()
        {
            InitializeComponent();
            tbUrl.Enter += TbUrl_Enter;
            wbChrome.Navigate(DefaulURL);
        }
        private void TbUrl_Enter(object sender, EventArgs e)
        {
            string value = tbUrl.Text;
            wbChrome.Navigate(value);
        }
    }
}

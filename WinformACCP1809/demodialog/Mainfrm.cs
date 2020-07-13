using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demodialog
{
    public partial class Form1 : Form
    {
        public static string DataView { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpendialog_Click(object sender, EventArgs e)
        {
            string data = tbTest.Text;
            //Application.UserAppDataRegistry.SetValue("mydata", data);
            DataView = data;
            dgTest dg = new dgTest();
            dg.ShowDialog(this);// this : Mainfrm
            //string dt = (Application.UserAppDataRegistry.GetValue("mydata") ?? "") as string;
            //tbTest.Text = dt;
            tbTest.Text = DataView;
        }
    }
}

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
    public partial class dgTest : Form
    {
        public dgTest()
        {
            InitializeComponent();
            //string dt = (Application.UserAppDataRegistry.GetValue("mydata") ?? "") as string;
            //tbDialogTest.Text = dt;
            tbDialogTest.Text = Form1.DataView;
        }
        public dgTest(Object data)
        {
            InitializeComponent();
            tbDialogTest.Text = (data ?? "") as string;
        }
        private void btnCloseDialog_Click(object sender, EventArgs e)
        {
            //Application.UserAppDataRegistry.SetValue("mydialogData", tbDialogTest.Text);
            Form1.DataView = tbDialogTest.Text;
        }
    }
}

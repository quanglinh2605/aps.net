using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demodialog2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnfont_Click(object sender, EventArgs e)
        {
            dgfont.ShowEffects = true;
            dgfont.ShowColor = true;
            dgfont.ShowDialog(this);
            Font fonttext = dgfont.Font;
            Color colortext = dgfont.Color;
            rtbContent.SelectionFont = fonttext;
            rtbContent.SelectionColor = colortext;
        }
    }
}

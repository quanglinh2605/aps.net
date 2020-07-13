using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using transferListBox.Models;

namespace transferListBox
{
    public partial class Form1 : Form
    {
        List<sinhvien> lssv = new List<sinhvien>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int newid = int.Parse(tbMaSV.Text);
            string newTen = tbTenSV.Text;
            tbMaSV.Text = "";
            tbTenSV.Text = "";

            sinhvien sv = new sinhvien();
            sv.MaSV = newid;
            sv.TenSV = newTen;
            lssv.Add(sv);

            cboSV.DataSource = null;
            cboSV.DataSource = lssv;
            cboSV.DisplayMember = "TenSV";
            cboSV.ValueMember = "MaSV";

            lbSV1.Items.Add(sv);
            lbSV1.DisplayMember="TenSV";
            lbSV1.ValueMember = "MaSV";
        }

        private void cboSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSV.DataSource != null)
            {
                sinhvien itemchoose = cboSV.SelectedItem as sinhvien;
                lblMaSV.Text = itemchoose.MaSV.ToString();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            foreach(var item in lbSV1.SelectedItems)
            {
                sinhvien sv = new sinhvien();
                sv.MaSV = ((sinhvien)item).MaSV;
                sv.TenSV = ((sinhvien)item).TenSV;
                lbSV2.Items.Add(sv);
            }
            lbSV2.DisplayMember = "TenSV";
            lbSV2.ValueMember = "MaSV";
            while (lbSV1.SelectedItems.Count != 0)
            {
                lbSV1.Items.Remove(lbSV1.SelectedItems[0]);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            foreach(var item in lbSV2.SelectedItems)
            {
                sinhvien sv = new sinhvien();
                sv.MaSV = ((sinhvien)item).MaSV;
                sv.TenSV = ((sinhvien)item).TenSV;
                lbSV1.Items.Add(sv);
            }
            lbSV2.DisplayMember = "TenSV";
            lbSV2.ValueMember = "MaSV";
            while (lbSV2.SelectedItems.Count != 0)
            {
                lbSV2.Items.Remove(lbSV2.SelectedItems[0]);
            }
        }
    }
}

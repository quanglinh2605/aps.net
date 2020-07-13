using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap2
{
    public partial class Form1 : Form
    {
        Dept model = new Dept();
        public Form1()
        {
            InitializeComponent();
        }
        void clear()
        {
            txtName.Text = txtLoc.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
            clear();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            model.DName = txtName.Text.Trim();
            model.loc = txtLoc.Text.Trim();
            using (baitap2Entities db = new baitap2Entities())
            {
                if (model.DeptNo == 0)
                {
                    db.Depts.Add(model);
                    db.SaveChanges();
                }
                else db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            clear();
            Show();
            MessageBox.Show("Successful");
        }
        void Show()
        {
            dvgDept.AutoGenerateColumns = false;
            using(baitap2Entities db = new baitap2Entities())
            {
                dvgDept.DataSource = db.Depts.ToList<Dept>(); 
            }
        }

        private void dvgDept_DoubleClick(object sender, EventArgs e)
        {
            if (dvgDept.CurrentRow.Index != -1)
            {
                model.DeptNo = Convert.ToInt32(dvgDept.CurrentRow.Cells["ID"].Value);
                using(baitap2Entities db = new baitap2Entities())
                {
                    model = db.Depts.Where(x => x.DeptNo == model.DeptNo).FirstOrDefault();
                    txtName.Text = model.DName;
                    txtLoc.Text = model.loc;
                }
                btnSave.Text = "Update";
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure","Quang Linh",MessageBoxButtons.YesNo)== DialogResult.Yes){
                using (baitap2Entities db = new baitap2Entities())
                {
                    var entry = db.Entry(model);
                    if (entry.State == System.Data.Entity.EntityState.Detached)
                        db.Depts.Attach(model);
                    db.SaveChanges();
                    Show();
                    clear();
                    MessageBox.Show("Delete Successful");
                }
            }
        }
    }
}

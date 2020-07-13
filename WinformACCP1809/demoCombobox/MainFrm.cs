using demoCombobox.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoCombobox
{
    public partial class MainFrm : Form
    {
        private Categories cates = new Categories();
        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(tbID.Text);
            string name = tbName.Text;
            tbID.Text = "";
            tbName.Text = "";
            Category newitem = new Category { Name = name, ID = id };// c# version 5
            cates.Add(newitem);
            ////---------------------------
            //cboCates.DataSource = null;//reset datasource
            //cboCates.DataSource = cates;//new datasource
            //cboCates.DisplayMember = "Name";
            //cboCates.ValueMember = "ID";
            //header combobox
            //cboCates.Items.Insert(0, new Category { ID = -1, Name = "choose category" });
            bindingCbo(cates, cboCates, "Hay chon danh muc");
        }
        private void bindingCbo(Categories data, ComboBox updateItem, String title)
        {
            updateItem.Items.Clear();
            updateItem.Items.Add(new Category{ID = -1, Name =title});
            foreach(Category item in data){
                updateItem.Items.Add(item);
            }
            updateItem.DisplayMember = "Name";
            updateItem.ValueMember = "ID";
            updateItem.SelectedIndex = 0;
        }

        private void cboCates_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category itemchoose = (Category)cboCates.SelectedItem;//Phan tu duoc chon
            lblCate.Text = itemchoose.ID.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using realstate.Classes;

namespace realstate
{
    public partial class HamshahriList : Form
    {
        databaseManager manager = new databaseManager();
        FontClass fontclass = new FontClass();
        public HamshahriList()
        {
            InitializeComponent();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            allControls.Where(x => x.Name == "label1").FirstOrDefault().Font = GlobalVariable.HlistFONT;


            this.CenterToScreen();
            setDataGrid();
        }
        public void setDataGrid() {
            dataGridView1.DataSource = manager.getHamshahri();
            dataGridView1.Columns["ID"].Visible = false;
            this.dataGridView1.Columns["title"].HeaderText = "عنوان";
            this.dataGridView1.Columns["content"].HeaderText = "متن ";
            this.dataGridView1.Columns["title"].Width = 150;
            this.dataGridView1.Columns["content"].Width = 250;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row > -1)
            {
                string id = dataGridView1.Rows[row].Cells[1].Value.ToString();
                deleteVrification del = new deleteVrification(id, "4","");
                del.Show();
                
            }
           
        }
    }
}

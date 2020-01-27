using Newtonsoft.Json;
using realstate.Classes;
using realstate.ListOfAdds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace realstate
{
    public partial class ArchiveList : Form
    {
       
        

        //ArchiveList newArchiveList = null;
        List<gridVM> model;
        public ArchiveList(string query)
        {
            GlobalVariable.temporaryOwnList = "";
            // جهت سورت مجدد لیست استفاده می شود
            GlobalVariable.lastSearchModel = query;
            InitializeComponent();
            setPreliminaries();
            InitializeDataGridView();
            model = JsonConvert.DeserializeObject<List<gridVM>>(query);
            GlobalVariable.RowIDList.Clear();
            foreach (var item in model)
            {
                //جهت نگهداری لیست آی دی ها به منظور فراخوانی فایل بعدی یا قبلی
                GlobalVariable.RowIDList.Add(item.codegrid);
            }

            count.Text = model.Count.ToString();

            setDateGridData(model);
            this.listGrid.Columns["phones"].Visible = false;
            this.listGrid.Columns["Address1"].Visible = false;
            this.listGrid.Columns["Address2"].Visible = false;
            this.listGrid.Columns["Address3"].Visible = false;
            this.listGrid.Columns["datetime"].Visible = false;
            this.listGrid.Columns["checkbox"].Visible = false;
            



        }

        databaseManager manager = new databaseManager();
        FontClass fontclass = new FontClass();
        const int CUSTOM_CONTENT_HEIGHT = 10;

        private void setPreliminaries()
        {





            Settings1.Default.address = "A";
            Settings1.Default.rahntotal = "A";
            Settings1.Default.ejaremetri = "A";



            listGrid.Columns[9].DefaultCellStyle.Format = "N3";
            listGrid.Columns[10].DefaultCellStyle.Format = "N3";


            this.WindowState = FormWindowState.Maximized;
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            foreach (DataGridViewColumn c in listGrid.Columns)
            {
                c.DefaultCellStyle.Font = GlobalVariable.headerlistFONT;
            }
           
        }
        private void InitializeDataGridView()
        {


            // Initialize basic DataGridView properties.
            listGrid.Dock = DockStyle.Fill;
            listGrid.BackgroundColor = Color.LightGray;
            listGrid.BorderStyle = BorderStyle.Fixed3D;

            Padding newPadding = new Padding(0, 1, 0, CUSTOM_CONTENT_HEIGHT);
            this.listGrid.RowTemplate.DefaultCellStyle.Padding = newPadding;
            this.listGrid.RowTemplate.Height += CUSTOM_CONTENT_HEIGHT;
            this.listGrid.Enabled = true;
            this.listGrid.ReadOnly = false;

            //listGrid.DefaultCellStyle.SelectionBackColor = Color.LightGreen;
            //listGrid.DefaultCellStyle.SelectionForeColor = Color.White;


        }

        private void setDateGridData(List<gridVM> list)
        {

            var bindingList = new BindingList<gridVM>(list);
            var source = new BindingSource(bindingList, null);
            listGrid.DataSource = source;
        }

        private void listGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = listGrid.Columns[e.ColumnIndex];
            string name = newColumn.Name;
            List<gridVM> model = JsonConvert.DeserializeObject<List<gridVM>>(GlobalVariable.lastSearchModel);
            switch (name)
            {
                case ("dategrid"):
                    if (Settings1.Default.date == "A")
                    {
                        model = model.OrderBy(x => x.datetime).ToList();
                        Settings1.Default.date = "D";
                    }
                    else
                    {
                        model = model.OrderByDescending(x => x.datetime).ToList();
                        Settings1.Default.date = "A";
                    }
                    break;
                case ("Address"):
                    if (Settings1.Default.address == "A")
                    {
                        model = model.OrderBy(x => x.Address).ToList();
                        Settings1.Default.address = "D";
                    }
                    else
                    {
                        model = model.OrderByDescending(x => x.Address).ToList();
                        Settings1.Default.address = "A";
                    }

                    break;
                case ("ejare_metri"):
                    if (Settings1.Default.ejaremetri == "A")
                    {
                        model = model.OrderBy(x => x.ejare_metri).ToList();
                        Settings1.Default.ejaremetri = "D";
                    }
                    else
                    {
                        model = model.OrderByDescending(x => x.ejare_metri).ToList();
                        Settings1.Default.ejaremetri = "A";
                    }

                    break;
                case ("rahn_total"):
                    if (Settings1.Default.rahntotal == "A")
                    {
                        model = model.OrderBy(x => x.rahn_total).ToList();
                        Settings1.Default.rahntotal = "D";
                    }
                    else
                    {
                        model = model.OrderByDescending(x => x.rahn_total).ToList();
                        Settings1.Default.rahntotal = "A";
                    }

                    break;
            }

            setDateGridData(model);
        }


       

       
     
        private void listGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string content = e.ToString();
            int column = e.ColumnIndex;

            int row = e.RowIndex;
            string id = listGrid.Rows[row].Cells["codegrid"].Value.ToString();
            GlobalVariable.RowIDList.Clear();
            for (int i = 0; i < listGrid.Rows.Count; i++)
            {
                GlobalVariable.RowIDList.Add(listGrid.Rows[i].Cells["codegrid"].Value.ToString());

            }
            item selecteditem = manager.getitem(Convert.ToInt32(id));
            string srt = JsonConvert.SerializeObject(selecteditem);

            ItemDetail detail = new ItemDetail(srt, "archive");
            detail.Show();
        }
        private void listGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int count = this.listGrid.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    this.listGrid.Rows[i].Selected = false;
                }
                int column = e.ColumnIndex;
                int row = e.RowIndex;

                if (row > -1)
                {
                    this.listGrid.Rows[row].Selected = true;

                }
                if (listGrid.Columns[column].Name == "deleteItem")
                {
                    string id = this.listGrid.Rows[row].Cells["codegrid"].Value.ToString();
                    deleteVrification del = new deleteVrification(id, "2", System.Environment.MachineName);
                    del.Show();
                }
                else
                {
                    phone.Text = this.listGrid.Rows[row].Cells["phones"].Value.ToString().Substring(0, this.listGrid.Rows[row].Cells["phones"].Value.ToString().Length - 1);
                    if (listGrid.Columns[column].Name == "checkbox")
                    {
                        if (this.listGrid.Rows[row].Cells["checkbox"].EditedFormattedValue.ToString() == "False")
                        {
                            GlobalVariable.temporaryOwnList = GlobalVariable.temporaryOwnList + this.listGrid.Rows[row].Cells["codegrid"].Value.ToString() + ",";
                        }
                        else
                        {
                            List<string> lst = GlobalVariable.temporaryOwnList.Split(',').ToList();
                            lst.RemoveAt(lst.Count() - 1);
                            lst.Remove(this.listGrid.Rows[row].Cells["codegrid"].Value.ToString());
                            GlobalVariable.temporaryOwnList = "";
                            foreach (var item in lst)
                            {
                                GlobalVariable.temporaryOwnList = GlobalVariable.temporaryOwnList + item + ",";
                            }
                        }
                    }
                }

            }
            catch (Exception error)
            {

            }
        }







        private void detail_Click(object sender, EventArgs e)
        {

        }



        private void sameaddress_Click(object sender, EventArgs e)
        {

        }

        private void archive_Click(object sender, EventArgs e)
        {

        }


        private void print_Click(object sender, EventArgs e)
        {

        }
        public string bringPersionName(string srt)
        {
            string value = "";
            switch (srt)
            {
                case "phones":
                    value = "تلفن";
                    break;
                case "dategrid":
                    value = "تاریخ";
                    break;
                case "ownergrid":
                    value = "مالک";
                    break;
                case "typegrid":
                    value = "نوع";
                    break;
                case "floorgrid":
                    value = "طبقه";
                    break;
                case "kindgrid":
                    value = "مورد";
                    break;
                case "rahn_total":
                    value = "کل-رهن";
                    break;
                case "ejare_metri":
                    value = "متری-اجاره";
                    break;
                case "bed":
                    value = "تعداد خواب";
                    break;
                case "zirbana":
                    value = "متراژ";
                    break;
                case "mantagheName":
                    value = "نام منطقه";
                    break;
                case "Address":
                    value = "آدرس";
                    break;





            }
            return value;
        }
        private void sameaddress_MouseHover(object sender, EventArgs e)
        {

        }

        private void sameaddress_MouseLeave(object sender, EventArgs e)
        {

        }


    }
}

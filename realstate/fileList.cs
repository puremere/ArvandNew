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
using Newtonsoft.Json;
using realstate.ListOfAdds;
using realstate.Classes;
using System.Drawing.Drawing2D;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Base;
using Stimulsoft.Base.Drawing;
using System.Collections;
using Stimulsoft.Report.Dictionary;

namespace realstate
{
    public partial class fileList : Form
    {
        BackgroundWorker getDataBackGroundWorkerFileList = new BackgroundWorker();
      
        //fileList newfilelist = null;
        List<gridVM> model;
        public fileList(string query)
        {
            GlobalVariable.temporaryOwnList = "";
            // جهت سورت مجدد لیست استفاده می شود
            GlobalVariable.lastSearchModel = query;
            InitializeComponent();
            setPreliminaries();
            InitializeDataGridView();
            model = JsonConvert.DeserializeObject<List<gridVM>>(query);
            GlobalVariable.RowIDList.Clear();
            foreach(var item in model)
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
            if (GlobalVariable.role != "admin")
            {
                this.listGrid.Columns["deleteItem"].Visible = false;
            }
            else
            {
                this.listGrid.Columns["deleteItem"].Visible = true;
            }

        }

        databaseManager manager = new databaseManager();
        FontClass fontclass = new FontClass();
        const int CUSTOM_CONTENT_HEIGHT = 10;
       
        private void setPreliminaries() {



            

            Settings1.Default.address = "A";
            Settings1.Default.rahntotal = "A";
            Settings1.Default.ejaremetri = "A";

            

            listGrid.Columns["rahn_total"].DefaultCellStyle.Format = "N3";
            listGrid.Columns["ejare_metri"].DefaultCellStyle.Format = "N3";

            
            this.WindowState = FormWindowState.Maximized;
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            foreach (DataGridViewColumn c in listGrid.Columns)
            {
                c.DefaultCellStyle.Font = GlobalVariable.headerlistFONT;
            }
            getDataBackGroundWorkerFileList.WorkerSupportsCancellation = true;
            getDataBackGroundWorkerFileList.DoWork += new DoWorkEventHandler(getDataBackGroundWorkerFileList_do);
            getDataBackGroundWorkerFileList.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getDataBackGroundWorkerFileList_done);
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
       
        private void setDateGridData(List<gridVM> list) {

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

    
        private void getDataFromServer(string address1, string address2, string address3)
        {



            string id = address1 + "," + address2 + "," + address3;
            getDataBackGroundWorkerFileList.RunWorkerAsync(argument: id);


        }

        void getDataBackGroundWorkerFileList_do(object sender, DoWorkEventArgs e)
        {

            queryModel model = new queryModel();
            List<string> addressList = e.Argument.ToString().Split(',').ToList();
            model.address1 = addressList[0];
            model.address2 = addressList[1];
            model.address3 = addressList[2];
           
            string query = JsonConvert.SerializeObject(model);


            try
            {
                CatsAndAreasObject CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);

                List<gridVM> list = new List<gridVM>();
                foreach (var item in manager.getList(query))
                {
                    if (GlobalVariable.searchTabghe == "")
                    {
                        GlobalVariable.searchTabghe = "1";
                    }
                    string phones = item.phones;
                    string tabaghe = GlobalVariable.searchTabghe;
                    string fullprice = item.tabaghe_1_total_price.ToString();
                    string metriprice = item.tabaghe_1_metri.ToString();
                    string rahnprice = item.tabaghe_1_rahn.ToString();
                    string ejareprice = item.tabaghe_1_ejare.ToString();
                    string tabagh = item.tabaghe1.ToString();
                    string kha = item.bed1.ToString();
                    string zirban = item.zirbana1.ToString();
                    string tb1 = item.tabaghe1.ToString();
                    string tb2 = item.tabaghe2.ToString();
                    string tb3 = item.tabaghe3.ToString();

                    if (tb1 == tabaghe)
                    {
                        fullprice = item.tabaghe_1_total_price.ToString();
                        metriprice = item.tabaghe_1_metri.ToString();
                        rahnprice = item.tabaghe_1_rahn.ToString();
                        ejareprice = item.tabaghe_1_ejare.ToString();
                        tabagh = item.tabaghe1.ToString();
                        kha = item.bed1.ToString();
                        zirban = item.zirbana1.ToString();
                    }
                    if (tb2 == tabaghe)
                    {
                        fullprice = item.tabaghe_2_total_price.ToString();
                        metriprice = item.tabaghe_2_metri.ToString();
                        rahnprice = item.tabaghe_2_rahn.ToString();
                        ejareprice = item.tabaghe_2_ejare.ToString();
                        tabagh = item.tabaghe2.ToString();
                        kha = item.bed2.ToString();
                        zirban = item.zirbana2.ToString();
                    }
                    if (tb3 == tabaghe)
                    {
                        fullprice = item.tabaghe_3_total_price.ToString();
                        metriprice = item.tabaghe_3_metri.ToString();
                        rahnprice = item.tabaghe_3_rahn.ToString();
                        ejareprice = item.tabaghe_3_ejare.ToString();
                        tabagh = item.tabaghe3.ToString();
                        kha = item.bed3.ToString();
                        zirban = item.zirbana3.ToString();
                    }


                    string serverid = item.ID.ToString();
                    string date = item.date_updated.ToString();
                    string address = item.address.ToString();
                    string owner = item.malek.ToString();
                    string senn = item.senn == 0 ? "-" : (from q in CATS.data.list.senn
                                                          where q.ID == item.senn.ToString()
                                                          select q.title).First();

                    string melkkind = "";

                    if (item.maghaze != null && item.maghaze != "0")
                    {
                        melkkind = melkkind + "مغازه،";
                    }
                    if (item.apartment != null && item.apartment != "0")
                    {
                        melkkind = melkkind + "آپارتمان،";
                    }
                    if (item.villa != null && item.villa != "0")
                    {
                        melkkind = melkkind + "ویلا،";
                    }
                    if (item.mostaghellat != null && item.mostaghellat != "0")
                    {
                        melkkind = melkkind + "مستغلات،";
                    }
                    if (item.kolangi != null && item.kolangi != "0")
                    {
                        melkkind = melkkind + "کلنگی،";
                    }
                    if (item.office != null && item.office != "0")
                    {
                        melkkind = melkkind + "دفتر،";
                    }
                    if (melkkind.Length > 0)
                    {
                        melkkind = melkkind.Remove(melkkind.Length - 1, 1);
                    }

                    string Dealkind = "";
                    if (Convert.ToInt32(item.isForoosh.ToString()) > 0)
                    {
                        Dealkind = Dealkind + "فروش،";
                    }
                    if (Convert.ToInt32(item.isRahn.ToString()) > 0)
                    {
                        Dealkind = Dealkind + "رهن،";
                    }
                    if (Convert.ToInt32(item.isEjare.ToString()) > 0)
                    {
                        Dealkind = Dealkind + "اجاره،";
                    }
                    if (Dealkind.Length > 0)
                    {
                        Dealkind = Dealkind.Remove(Dealkind.Length - 1, 1);
                    }


                    string totalrahn = item.isForoosh.ToString() == "1" ? fullprice : rahnprice;
                    string metriejare = item.isForoosh.ToString() == "1" ? metriprice : ejareprice;


                    string Rtabaghe = tabagh;
                    string khab = kha;
                    string zirbana = zirban;



                    bool mycheckbox = false;
                    totalrahn = totalrahn.Replace(".", "");
                    if (totalrahn == "0")
                    {
                        totalrahn = "0";
                    }
                    else if (Convert.ToInt64(totalrahn) > 0)
                    {
                        string mytotal = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(totalrahn));
                        totalrahn = mytotal;
                    }
                    //else if (totalrahn == "-1")
                    //{
                    //    totalrahn = "توافقی";
                    //}
                    //else if (totalrahn == "-2")
                    //{
                    //    totalrahn = "رایگان";
                    //}

                    metriejare = metriejare.Replace(".", "");
                    if (Convert.ToInt64(metriejare) == 0)
                    {
                        metriejare = "0";
                    }
                    else if (Convert.ToInt64(metriejare) > 0)
                    {
                        string mymetriejare = string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(metriejare));
                        metriejare = mymetriejare;
                    }
                    //else if (metriejare == "-1")
                    //{
                    //    metriejare = "توافقی";
                    //}
                    //else if (metriejare == "-2")
                    //{
                    //    metriejare = "رایگان";
                    //}
                    if (GlobalVariable.temporaryOwnList.Contains(serverid + ","))
                    {
                        mycheckbox = true;
                    }
                    gridVM newitem = new gridVM()
                    {
                        Address = item.address1 + item.address2 + item.address3,
                        Address1 = item.address1,
                        Address2 = item.address2,
                        Address3 = item.address3,
                        bed = kha,
                        codegrid = item.number.ToString(),
                        dategrid = dateTimeConvert.ToPersianDateString(item.date_updated),
                        datetime = item.date_updated,
                        ejare_metri = int.Parse(metriejare.Replace(",","")),
                        floorgrid = tabagh,
                        kindgrid = Dealkind,
                        typegrid = melkkind,
                        ownergrid = item.malek,
                        rahn_total = int.Parse(totalrahn.Replace(",","")),
                        zirbana = zirban,
                        checkbox = mycheckbox,
                        Senn = senn,
                        phones = phones

                    };
                    list.Add(newitem);
                }

                string FILELIST = JsonConvert.SerializeObject(list);
                e.Result = FILELIST;




            }
            catch (Exception error)
            {
                e.Result = "error";
            }
        }
        private void getDataBackGroundWorkerFileList_done(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() == "error")
            {
                //refresh.Visible = false;
            }
            else
            {
                fileList newfilelist = new fileList(e.Result.ToString());
                newfilelist.Show();
                //refresh.Visible = false;

            }
        }
        private void listGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string content = e.ToString();
            int column = e.ColumnIndex;

            int row = e.RowIndex;
            if (listGrid.Columns[column].Name == "Address")
            {
                string address1 = listGrid.Rows[row].Cells["Address1"].Value.ToString();
                string address2 = listGrid.Rows[row].Cells["Address2"].Value.ToString();
                string address3 = listGrid.Rows[row].Cells["Address3"].Value.ToString();
                getDataFromServer(address1, address2, address3);

            }
            else
            {
                string id = listGrid.Rows[row].Cells["codegrid"].Value.ToString();
                GlobalVariable.RowIDList.Clear();
                for (int i =0; i< listGrid.Rows.Count; i++)
                {
                    GlobalVariable.RowIDList.Add(listGrid.Rows[i].Cells["codegrid"].Value.ToString());

                }
                item selecteditem = manager.getitem(Convert.ToInt32(id));
                string srt = JsonConvert.SerializeObject(selecteditem);
               
                ItemDetail detail = new ItemDetail(srt, "field");
                detail.Show();
            }
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
                    deleteVrification del = new deleteVrification(id, "3","");
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
            List<string> lst = GlobalVariable.temporaryOwnList.Split(',').ToList();
            lst.RemoveAt(lst.Count - 1);
            foreach(var item in lst)
            {

                item selecteditem = manager.getitem(Convert.ToInt32(item));
                string srt = JsonConvert.SerializeObject(selecteditem);

                ItemDetail detail = new ItemDetail(srt, "field");
                detail.Show();
            }
           
            
        }

      

        private void sameaddress_Click(object sender, EventArgs e)
        {
            List<string> lst = GlobalVariable.temporaryOwnList.Split(',').ToList();
            lst.RemoveAt(lst.Count - 1);
            string address1 = "";
            string address2 = "";
            string address3 = "";
            foreach (var item in lst)
            {

                item selecteditem = manager.getitem(Convert.ToInt32(item));
                address1 = address1 + selecteditem.address1 + "-";
                address2 = address2 + selecteditem.address2 + "-";
                address3 = address3 + selecteditem.address3 + "-";
            }
             
           
            getDataFromServer(address1, address2, address3);
        }

        private void archive_Click(object sender, EventArgs e)
        {
            List<string> lst = GlobalVariable.temporaryOwnList.Split(',').ToList();
            lst.RemoveAt(lst.Count - 1);
            if (lst.Count() > 0)
            {
                foreach (var item in lst)
                {
                    manager.addToArchive(item, System.Environment.MachineName);
                }
                MessageBox.Show("فایل های مورد نظر آرشیو شد");

            }
            else
            {
                MessageBox.Show("موردی انتخاب نشده است");

            }


        }
        
      
        private void print_Click(object sender, EventArgs e)
        {

            StiReport report = new StiReport();
            report.ScriptLanguage = StiReportLanguageType.CSharp;

            //Add data to datastore
            report.RegData("MyList", model);

            //Fill dictionary
            report.Dictionary.Synchronize();
            StiPage page = report.Pages.Items[0];
            page.Orientation = StiPageOrientation.Landscape;
            //Create HeaderBand
            StiHeaderBand headerBand = new StiHeaderBand();
            headerBand.Name = "HeaderBand";
            page.Components.Add(headerBand);

            //Create Dataaband
            StiDataBand dataBand = new StiDataBand();
            dataBand.DataSourceName = "MyList";
            dataBand.Height = 0.5f;
            dataBand.Name = "DataBand";
            page.Components.Add(dataBand);

            StiDataSource dataSource = report.Dictionary.DataSources[0];

            //Create texts
            Double pos = 0;
            Double columnWidth = StiAlignValue.AlignToMinGrid((page.Width*3*1.1) / 44, 0.1, true);
            Double AddressWidth = StiAlignValue.AlignToMinGrid((page.Width) / 4, 0.1, true);
            int nameIndex = 1;
            foreach (StiDataColumn column in dataSource.Columns)
            {
                if ( column.Name == "mantagheName" || column.Name == "Senn" || column.Name == "_ID" || column.Name == "_Current" || column.Name == "checkbox" || column.Name == "codegrid" || column.Name == "datetime" || column.Name == "Address1" || column.Name == "Address2" || column.Name == "Address3") continue;

                //Create text on header
                StiText headerText = null;
                if (column.Name == "Address")
                {
                    headerText = new StiText(new RectangleD(pos, 0, AddressWidth, 0.5f));
                }
                else
                {
                    headerText = new StiText(new RectangleD(pos, 0, columnWidth, 0.5f));

                }

                headerText.WordWrap = false;
                string val = bringPersionName(column.Name);
                headerText.Text.Value = val;//
                
                headerText.HorAlignment = StiTextHorAlignment.Center;
                headerText.VertAlignment = StiVertAlignment.Center;
                headerText.Name = "HeaderText" + nameIndex.ToString();
                headerText.Brush = new StiSolidBrush(Color.LightGreen);
                headerText.Border.Side = StiBorderSides.All;
                headerBand.Components.Add(headerText);

                //Create text on Data Band
                StiText dataText = null;
                if (column.Name == "Address")
                {
                    dataText = new StiText(new RectangleD(pos, 0, AddressWidth, 0.5f));
                }
                else
                {
                    dataText = new StiText(new RectangleD(pos, 0, columnWidth, 0.5f));
                }
             
               
                dataText.WordWrap = false;
                if (column.Name != "Address" || column.Name != "phones")
                {
                    dataText.HorAlignment = StiTextHorAlignment.Center;

                }
                dataText.VertAlignment = StiVertAlignment.Center;
                dataText.Text.Value = "{MyList." + column.Name + "}";
                dataText.Name = "DataText" + nameIndex.ToString();
                dataText.Border.Side = StiBorderSides.All;
                dataText.RightToLeft = true;
                
                //Add highlight
                //dataText.HighlightCondition.Brush = new StiSolidBrush(Color.CornflowerBlue);
                //dataText.HighlightCondition.TextBrush = new StiSolidBrush(Color.Black);
                //dataText.HighlightCondition.Condition.Value = "(Line & 1) == 1";

                //uncomment this line for VB.Net
                //dataText.HighlightCondition.Condition.Value = "(Line And 1) = 1";

                dataBand.Components.Add(dataText);

                pos += columnWidth;

                nameIndex++;
            }
            //Create FooterBand
            StiFooterBand footerBand = new StiFooterBand();
            footerBand.Height = 0.5f;
            footerBand.Name = "FooterBand";
            page.Components.Add(footerBand);

            //Create text on footer
            StiText footerText = new StiText(new RectangleD(0, 0, page.Width, 0.5f));
            footerText.Text.Value = "Count - {Count()}";
            footerText.HorAlignment = StiTextHorAlignment.Right;
            footerText.Name = "FooterText";
            footerText.Brush = new StiSolidBrush(Color.LightGreen);
            footerBand.Components.Add(footerText);

            //Render without progress bar
            report.Render(false);

            report.Show();

            //For checking created report you can uncomment this line
            //report.Design();

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
            Button btn = sender as Button;
            btn.BackgroundImage = realstate.Properties.Resources.address2_;
        }

        private void sameaddress_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackgroundImage = realstate.Properties.Resources.address1;
        }

       
    }
}

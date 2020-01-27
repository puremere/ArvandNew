using Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using realstate.Classes;
using realstate.ListOfAdds;
using System.Net;
using realstate.VM;

namespace realstate
{
    public partial class ItemDetail : Form
    {
        FontClass fontclass = new FontClass();
        item  obj = new item();
        CatsAndAreasObject CATS = null;
        databaseManager manager = new databaseManager();
        public ItemDetail(string newItem, string fromwhere)
        {
            obj = JsonConvert.DeserializeObject<item>(newItem);
            CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);

            InitializeComponent();
            InitControl();
            if (fromwhere == "archive"  )
            {
                button1.Visible = false;
            }
            else
            {
                if (GlobalVariable.role != "admin")
                {
                    button1.Visible = false;
                }
            }
            
        }
        public ItemDetail()
        {
            InitializeComponent();
            InitControl();
        }
       
        public void InitControl()
        {
            List<string> phones = obj.phones.Split(',').ToList();
           

            title.Text = obj.title;
            
            if (phones != null)
            {
                if(phones.Count() > 0)
                {
                    phone1.Text = phones[0];
                }
                if (phones.Count() > 1)
                {
                    phone1.Text = phones[1];
                }
                if (phones.Count() > 2)
                {
                    phone1.Text = phones[2];
                }
               
               
            }
          

            owner.Text = obj.malek;
            address.Text = obj.address;
            date_updated.Text = obj.date_updated.ToString();
            ID.Text = obj.number.ToString();
            total_vahed.Text = obj.total_vahed.ToString();
            total_floor.Text = obj.total_floor.ToString();
            vahed_per_floor.Text = obj.vahed_per_floor.ToString();
            zirbana1.Text = obj.zirbana1.ToString();
            zirbana2.Text = obj.zirbana2.ToString();
            zirbana3.Text = obj.zirbana3.ToString();
            khab1.Text = obj.bed1.ToString();
            khab2.Text = obj.bed2.ToString();
            khab3.Text = obj.bed3.ToString();
            tabaghe1.Text = obj.tabaghe1.ToString();
            tabaghe2.Text = obj.tabaghe2.ToString();
            tabaghe3.Text = obj.tabaghe3.ToString();
            tabaghe_1_rahn.Text = getChangedValue(obj.tabaghe_1_rahn.ToString());
            tabaghe_2_rahn.Text =getChangedValue( obj.tabaghe_2_rahn.ToString());// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_2_rahn));
            tabaghe_3_rahn.Text = getChangedValue(obj.tabaghe_3_rahn.ToString());// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_3_rahn));
            tabaghe_1_ejare.Text = getChangedValue(obj.tabaghe_1_ejare.ToString());// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_1_ejare));
            tabaghe_2_ejare.Text = getChangedValue(obj.tabaghe_2_ejare.ToString());// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_2_ejare));
            tabaghe_3_ejare.Text = getChangedValue(obj.tabaghe_3_ejare.ToString());// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_3_ejare));
            tabaghe_1_total_price.Text = getChangedValue(obj.tabaghe_1_total_price.ToString());//== "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_1_total_price));
            tabaghe_2_total_price.Text = getChangedValue(obj.tabaghe_2_total_price.ToString());// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_2_total_price));
            tabaghe_3_total_price.Text =getChangedValue( obj.tabaghe_3_total_price.ToString());// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_3_total_price));
            tabaghe_1_metri.Text =getChangedValue(obj.tabaghe_1_metri.ToString());// string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64();
            tabaghe_2_metri.Text =getChangedValue(obj.tabaghe_2_metri.ToString());// string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64();
            tabaghe_3_metri.Text = getChangedValue(obj.tabaghe_3_metri.ToString());// string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64();
            tarakom.Text = obj.tarakom;
            toole_bar.Text = obj.toole_bar;
            masahat_zamin.Text = obj.masahat_zamin.ToString();
            ertefa.Text = obj.ertefa;
            eslahi.Text = obj.eslahi;
            zirzamin.Text = obj.zirzamin;
            desc.Text = obj.desc;
            isForoosh.Checked =  obj.isForoosh == "1" ? true : false;
            isEjare.Checked = obj.isEjare == "1" ? true : false;
            isMosharekat.Checked = obj.isMosharekat == "1" ? true : false;
            isRahn.Checked = obj.isRahn == "1" ? true : false;
            isMoaveze.Checked = obj.isMoaveze == "1" ? true : false;
            sell2khareji.Checked = obj.sell2khareji == "1" ? true : false;
            hasEstakhr.Checked = obj.hasEstakhr == "1" ? true : false;
            hasJakoozi.Checked = obj.hasJakoozi == "1" ? true : false;
            hasSauna.Checked = obj.hasSauna == "1" ? true : false;
            takhlie.Checked = obj.takhlie == "1" ? true : false;
            balkon1.Checked = obj.balkon1 == "1" ? true : false;
            balkon2.Checked = obj.balkon2 == "1" ? true : false;
            balkon3.Checked = obj.balkon3 == "1" ? true : false;
            parking1.Checked = obj.parking1 == "1" ? true : false;
            parking2.Checked = obj.parking2 == "1" ? true : false;
            parking3.Checked = obj.parking3 == "1" ? true : false;
            anbari1.Checked = obj.anbari1 == "1" ? true : false;
            anbari2.Checked = obj.anbari2 == "1" ? true : false;
            anbari3.Checked = obj.anbari3 == "1" ? true : false;
            asansor1.Checked = obj.asansor1 == "1" ? true : false;
            asansor2.Checked = obj.asansor2 == "1" ? true : false;
            asansor3.Checked = obj.asansor3 == "1" ? true : false;
            hasGym.Checked = obj.hasGym == "1" ? true : false;
            hasShooting.Checked = obj.hasShooting == "1" ? true : false;
            hasHall.Checked = obj.hasHall == "1" ? true : false;
            hasRoofGarden.Checked = obj.hasRoofGarden == "1" ? true : false;
            isMoble.Checked = obj.isMoble == "1" ? true : false;
            hasLobbyMan.Checked = obj.hasLobbyMan == "1" ? true : false;
            maghaze.Checked = obj.maghaze == "1" ? true : false;
            

            mantaghe_id.Text = obj.mantaghe_id == "0" ? "-" : (from q in CATS.data.list.mantaghe_id
                                                               where q.ID == obj.mantaghe_id
                                                               select q.title).First();

            mantaghe_name.Text = obj.mantaghe_name == "0" ? "-" : (from q in CATS.data.list.mantaghe
                                                                   where q.ID == obj.mantaghe_name
                                                                   select q.title).First();

            
            apartment.Text = obj.apartment == "0" ? "-" : (from q in CATS.data.list.apartment
                                                           where q.ID == obj.apartment
                                                           select q.title).First();

            office.Text = obj.office == "0" ? "-" : (from q in CATS.data.list.office
                                                     where q.ID == obj.office
                                                     select q.title).First();

            villa.Text = obj.villa == "0" ? "-" : (from q in CATS.data.list.villa
                                                   where q.ID == obj.villa
                                                   select q.title).First();

            mostaghellat.Text = obj.mostaghellat == "0" ? "-" : (from q in CATS.data.list.mostaghellat
                                                                 where q.ID == obj.mostaghellat
                                                                 select q.title).First();


            kolangi.Text = obj.kolangi == "0" ? "-" : (from q in CATS.data.list.kolangi
                                                       where q.ID == obj.kolangi
                                                       select q.title).First();

            seraydar.Text = obj.seraydar == "0" ? "-" : (from q in CATS.data.list.seraydar
                                                         where q.ID == obj.seraydar
                                                         select q.title).First();

            kaf_type.Text = obj.kaf_type == "0" ? "-" : (from q in CATS.data.list.kaf_type
                                                         where q.ID == obj.kaf_type
                                                         select q.title).First();

            if (obj.garmayesh_sarmayesh.Length > 1)
            {
                string final = "";
                string srt = obj.garmayesh_sarmayesh.Remove(obj.garmayesh_sarmayesh.Length - 1, 1);
                srt = srt.Remove(0, 1);

                if (srt.Contains(','))
                {
                    List<string> lstsg3 = srt.Split(',').ToList();
                    foreach (var itemm in lstsg3)
                    {
                        final = final + (from q in CATS.data.list.garmayesh_sarmayesh
                                         where q.ID == itemm
                                         select q.title).First() + ",";
                    }
                }
                else
                {
                    final = (from q in CATS.data.list.garmayesh_sarmayesh
                             where q.ID == srt
                             select q.title).First();
                }

                //final = final.Remove(final.Length - 1, 1);
                garmayesh_sarmayesh.Text = final;

            }
            else if (obj.garmayesh_sarmayesh.Length == 1)
            {

                if (obj.garmayesh_sarmayesh == "0")
                {
                    garmayesh_sarmayesh.Text = "-";
                }
                else
                {
                    garmayesh_sarmayesh.Text = (from q in CATS.data.list.garmayesh_sarmayesh
                                                where q.ID == obj.garmayesh_sarmayesh
                                                select q.title).First();
                }

            }
            else
            {
                garmayesh_sarmayesh.Text = "-";
            }

            if (obj.ashpazkhane1.Length > 1)
            {
                string final = "";
                string srt = obj.ashpazkhane1.Remove(obj.ashpazkhane1.Length - 1, 1);
                srt = srt.Remove(0, 1);

                if (srt.Contains(','))
                {
                    List<string> lstsg3 = srt.Split(',').ToList();
                    foreach (var itemm in lstsg3)
                    {
                        final = final + (from q in CATS.data.list.ashpazkhane
                                         where q.ID == itemm
                                         select q.title).First() + ",";
                    }
                }
                else
                {
                    final = (from q in CATS.data.list.ashpazkhane
                             where q.ID == srt
                             select q.title).First();
                }
               // final = final.Remove(final.Length - 1, 1);
                ashpazkhane1.Text = final;

            }
            else if (obj.ashpazkhane1.Length == 1)
            {

                if (obj.ashpazkhane1 == "0")
                {
                    ashpazkhane1.Text = "-";
                }
                else
                {
                    ashpazkhane1.Text = (from q in CATS.data.list.ashpazkhane
                                         where q.ID == obj.ashpazkhane1
                                         select q.title).First();
                }

            }
            else
            {
                ashpazkhane1.Text = "-";
            }

            if (obj.ashpazkhane2.Length > 0)
            {
                string final = "";
                string srt = obj.ashpazkhane2.Remove(obj.ashpazkhane2.Length - 1, 1);
                srt = srt.Remove(0, 1);

                if (srt.Contains(','))
                {
                    List<string> lstsg3 = srt.Split(',').ToList();
                    foreach (var itemm in lstsg3)
                    {
                        final = final + (from q in CATS.data.list.ashpazkhane
                                         where q.ID == itemm
                                         select q.title).First() + ",";
                    }
                }
                else
                {
                    final = (from q in CATS.data.list.ashpazkhane
                             where q.ID == srt
                             select q.title).First();
                }
                //final = final.Remove(final.Length - 1, 1);
                ashpazkhane2.Text = final;

            }

            else if (obj.ashpazkhane2.Length == 1)
            {

                if (obj.ashpazkhane2 == "0")
                {
                    ashpazkhane2.Text = "-";
                }
                else
                {
                    ashpazkhane2.Text = (from q in CATS.data.list.ashpazkhane
                                         where q.ID == obj.ashpazkhane2
                                         select q.title).First();
                }

            }
            else
            {
                ashpazkhane2.Text = "-";
            }
            if (obj.ashpazkhane3.Length > 0)
            {
                string final = "";
                string srt = obj.ashpazkhane3.Remove(obj.ashpazkhane3.Length - 1, 1);
                srt = srt.Remove(0, 1);

                if (srt.Contains(','))
                {
                    List<string> lstsg3 = srt.Split(',').ToList();
                    foreach (var itemm in lstsg3)
                    {
                        final = final + (from q in CATS.data.list.ashpazkhane
                                         where q.ID == itemm
                                         select q.title).First() + ",";
                    }
                }
                else
                {
                    final = (from q in CATS.data.list.ashpazkhane
                             where q.ID == srt
                             select q.title).First();
                }
                //final = final.Remove(final.Length - 1, 1);
                ashpazkhane3.Text = final;

            }
            else if (obj.ashpazkhane3.Length == 1)
            {

                if (obj.ashpazkhane3 == "0")
                {
                    ashpazkhane3.Text = "-";
                }
                else
                {
                    ashpazkhane3.Text = (from q in CATS.data.list.ashpazkhane
                                         where q.ID == obj.ashpazkhane3
                                         select q.title).First();
                }

            }
            else
            {
                ashpazkhane3.Text = "-";
            }


            if (obj.wc !=  null)
            {
                if (obj.wc.Length > 1)
                {
                    string final = "";
                    string srt = obj.wc.Remove(obj.wc.Length - 1, 1);
                    srt = srt.Remove(0, 1);

                    if (srt.Contains(','))
                    {
                        List<string> lstsg3 = srt.Split(',').ToList();
                        foreach (var itemm in lstsg3)
                        {
                            final = final + (from q in CATS.data.list.behdashti
                                             where q.ID == itemm
                                             select q.title).First() + ",";
                        }
                    }
                    else
                    {
                        final = (from q in CATS.data.list.behdashti
                                 where q.ID == srt
                                 select q.title).First();
                    }
                    // final = final.Remove(final.Length - 1, 1);
                    wc.Text = final;
                }
                else if (obj.wc.Length == 1)
                {

                    if (obj.wc == "0")
                    {
                        wc.Text = "-";
                    }
                    else
                    {
                        wc.Text = (from q in CATS.data.list.behdashti
                                   where q.ID == obj.wc
                                   select q.title).First();
                    }

                }
                

            }
           
            else
            {
                wc.Text = "-";
            }


            senn.Text = obj.senn.ToString() == "0"?  "-" : (from q in CATS.data.list.senn
                                                 where q.ID == obj.senn.ToString()
                                                               select q.title).First();


                samt.Text = obj.samt == "0" ? "-" : (from q in CATS.data.list.samt
                                                 where q.ID == obj.samt
                                                 select q.title).First();

            sanad.Text = obj.sanad == "0" ? "-" : (from q in CATS.data.list.sanad
                                                   where q.ID == obj.sanad
                                                   select q.title).First();







        }

        private void ItemDetail_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;



            CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);


            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);


           
            la7.Font = GlobalVariable.headerlistFONTsmall;
            la8.Font = GlobalVariable.headerlistFONTsmall;
            la9.Font = GlobalVariable.headerlistFONTsmall;
            la10.Font = GlobalVariable.headerlistFONTsmall;
            la11.Font = GlobalVariable.headerlistFONTsmall;
            la12.Font = GlobalVariable.headerlistFONTsmall;
            la13.Font = GlobalVariable.headerlistFONTsmall;
            la14.Font = GlobalVariable.headerlistFONTsmall;
            la15.Font = GlobalVariable.headerlistFONTsmall;
            la09.Font = GlobalVariable.headerlistFONTsmall;
            la17.Font = GlobalVariable.headerlistFONTsmall;
            la18.Font = GlobalVariable.headerlistFONTsmall;
            la19.Font = GlobalVariable.headerlistFONTsmall;
            //la20.Font = GlobalVariable.headerlistFONTsmall;
            //la21.Font = GlobalVariable.headerlistFONTsmall;
            //la22.Font = GlobalVariable.headerlistFONTsmall;
            //label13.Font = GlobalVariable.headerlistFONTsmall;
            label12.Font = GlobalVariable.headerlistFONTsmall;
            la57.Font = GlobalVariable.headerlistFONTsmall;

            this.MinimizeBox = true;
            this.MaximizeBox = true;
            whishon.Visible = false;
            ListOfAdds.RootObject log = JsonConvert.DeserializeObject<ListOfAdds.RootObject>(GlobalVariable.result);
         
            InitControl();

            wishoff.Name = "0-" + obj.ID;
            whishon.Name = "1-" + obj.ID;
            saveToPrivate.Name = "2-" + obj.ID;
            next.Name = "3-" + obj.ID;
            back.Name = "4-" + obj.ID;

            string ideas = Settings1.Default.ides;
            if (ideas.Contains("," + obj.ID))
            {
                wishoff.Visible = false;
                whishon.Visible = true;
            }
            else
            {
                whishon.Visible = false;
                wishoff.Visible = true;

            }
          
           
        }



        









        private void wishoff_Click(object sender, EventArgs e)
        {
          
            wishoff.Visible = false;
            whishon.Visible = true;
            string ideas = Settings1.Default.ides;
            Settings1.Default.ides = ideas + "," + this.obj.number;
            Settings1.Default.Save();
        }

        private void whishon_Click(object sender, EventArgs e)
        {
            
            string idesss = Settings1.Default.ides.Remove(0, 1);
            List<string> TagIds = idesss.Split(',').ToList();
            int index = 0;
            foreach (var item in TagIds)
            {
                if (item == this.obj.number.ToString())
                {
                    index = TagIds.IndexOf(item);
                }
            }
            TagIds.RemoveAt(index);
            string ides = "";
            foreach (var item in TagIds)
            {
                ides = "," + item;
            }

            Settings1.Default.ides = ides;
            Settings1.Default.Save();
            wishoff.Visible = true;
            whishon.Visible = false;
        }

        private void saveToPrivate_Click(object sender, EventArgs e)
        {
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(directory, "Arvand", "objects.txt");
            string allobject = "";
            try
            {
               
                if (System.IO.File.Exists(path) == false)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    using (FileStream fs = new FileStream(path, FileMode.Create))
                    {

                    }
                }
                using (StreamReader sr = new StreamReader(path, true))
                {

                    allobject = sr.ReadToEnd();

                }
            }
            catch 
            {

               
            }
           

            List<item> list = new List<item>();
            List<item> list2 = new List<item>();
            try
            {
                list2 = JsonConvert.DeserializeObject<List<item>>(allobject);

            }
            catch
            {
            }
            if (list2 != null)
            {
                foreach (var item in list2)
                {
                    list.Add(item);
                }
            }
            list.Add(this.obj);
            string jsonmodel = JsonConvert.SerializeObject(list);
            try
            {

                System.IO.File.WriteAllText(path, string.Empty);
                System.IO.File.WriteAllText(path, jsonmodel);



                MessageBox.Show("فایل مورد نظر با موفقیت به فایل های اختصاصی شما اضافه شد");

            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);

            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            bringNextData();
        }
        public void bringNextData() {
            string id = ID.Text;
            int Indexof = GlobalVariable.RowIDList.IndexOf(id);
            int mustbe = Indexof + 1;
            if (mustbe <= GlobalVariable.RowIDList.Count() - 1 && mustbe >= 0)
            {
               // GlobalVariable.fromarrow = true;

                int mustid = int.Parse(GlobalVariable.RowIDList[mustbe]);
                getNewDetail(mustid);
                //getDataFromServer(mustid);

            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            bringPreData();
            
        }

        public void bringPreData() {
            string id = ID.Text;

            int Indexof = GlobalVariable.RowIDList.IndexOf(id);
            int mustbe = Indexof - 1;


            if (mustbe <= GlobalVariable.RowIDList.Count() - 1 && mustbe >= 0)
            {
               // GlobalVariable.fromarrow = true;

                int mustid = int.Parse(GlobalVariable.RowIDList[mustbe]);
                getNewDetail(mustid);



            }
        }
        //private void bel56_Click(object sender, EventArgs e)
        //{
        //    string finalstring = address.Text + "+++";
        //    GlobalVariable.relatedAddress =  finalstring;
        //    GlobalVariable.temporaryOwnList = "";


        //    getDataFromServer(null);

        //}

        private void getNewDetail(int id)
        {
            refresh.Visible = true;
            BackgroundWorker getNewDSetailBackGroundWorker = new BackgroundWorker();
            getNewDSetailBackGroundWorker.WorkerSupportsCancellation = true;
            getNewDSetailBackGroundWorker.DoWork += new DoWorkEventHandler(getNewDSetailBackGroundWorker_do);
            getNewDSetailBackGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getNewDSetailBackGroundWorker_done);

            getNewDSetailBackGroundWorker.RunWorkerAsync(argument: id.ToString());
        }
        void   getNewDSetailBackGroundWorker_do(object sender, DoWorkEventArgs e)
        {
            string id = (string)e.Argument;
            obj = manager.getitem(Convert.ToInt32(id));
            
        }
        private void getNewDSetailBackGroundWorker_done(object sender, RunWorkerCompletedEventArgs e)
        {
            refresh.Visible = false;
            InitControl();
        }
        
        

     
        public string getChangedValue(string value)
        {
            string final = "";
            if (value == "-1")
            {
                final = "توافقی";

            }
            else if (value == "-2")
            {
                final = "رایگان";
            }
            else
            {
                final = string.Format(CultureInfo.InvariantCulture, "{0:#,##0}", Convert.ToInt64(value));
            }
            return final;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                string controlVal = ((CheckBox)sender).Checked.ToString();
                string result = "";
                if (controlVal == "True")
                {
                    
                }
                else
                {
                    MessageBox.Show("فایل مورد نظر  فعال شد");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            deleteVrification del = new deleteVrification(ID.Text, "1","");
            del.Show();
          
        }

        private void ItemDetail_KeyDown(object sender, KeyEventArgs e)
        {
            //capture left arrow key
            if (e.KeyData == Keys.Left)
            {
                bringPreData();
              
            }
            //capture right arrow key
            if (e.KeyData == Keys.Right)
            {
                bringNextData();
               
            }
        }
       
    }
}























// sameaddress from detail
//private void getDataFromServer(int? id)
//{
//    if (refresh.Visible == false)
//    {
//        refresh.Visible = true;
//        BackgroundWorker getDataBackGroundWorker = new BackgroundWorker();
//        getDataBackGroundWorker.WorkerSupportsCancellation = true;
//        getDataBackGroundWorker.DoWork += new DoWorkEventHandler(getDataBackGroundWorker_do);
//        getDataBackGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getDataBackGroundWorker_done);

//        try
//        {
//            queryModel model = new queryModel();
//            if (id != null)
//            {
//                model.ID = id.ToString();
//            }
//            model.relatedAddress = GlobalVariable.relatedAddress;

//            string str = JsonConvert.SerializeObject(model);

//            getDataBackGroundWorker.RunWorkerAsync(argument: str);
//            refresh.Visible = true;
//        }
//        catch (Exception)
//        {



//        }
//    }



//}
//private void getDataBackGroundWorker_done(object sender, RunWorkerCompletedEventArgs e)
//{
//    try
//    {


//        if (e.Result.ToString() == "error")
//        {
//            refresh.Visible = false;
//        }
//        else
//        {

//            if (GlobalVariable.fromarrow == true)
//            {
//                List<item> log = JsonConvert.DeserializeObject<List<item>>(GlobalVariable.result);
//                obj = log.First();
//                InitControl();
//                GlobalVariable.fromarrow = false;
//                refresh.Visible = false;
//            }
//            else
//            {
//                foreach (Form item in Application.OpenForms)
//                {
//                    if (item.Name == "main")
//                    {
//                        item.Close();
//                        break;
//                    }
//                }
//                GlobalVariable.fromwhere = "main";

//                main main = new main();
//                Control clt0 = main.Controls.Find("flowLayoutPanel1", true).First();
//                clt0.BackgroundImage = null;
//                Control clt = main.Controls.Find("radListView1", true).First();
//                clt.Visible = true;

//                Control clt2 = main.Controls.Find("searchpanel", true).First();
//                clt2.Visible = true;

//                Control clt3 = main.Controls.Find("dissconnect", true).First();
//                clt3.Visible = false;

//                Control clt4 = main.Controls.Find("connect", true).First();
//                clt4.Visible = true;


//                main.Show();
//                this.Close();
//                refresh.Visible = false;
//            }



//        }
//    }
//    catch (Exception)
//    {

//        MessageBox.Show("موردی وجود ندارد");
//        refresh.Visible = false;
//    }



//}
//void getDataBackGroundWorker_do(object sender, DoWorkEventArgs e)
//{


//    string query = (string)e.Argument;
//    GlobalVariable.result = JsonConvert.SerializeObject(manager.getList(query, ""));




//}
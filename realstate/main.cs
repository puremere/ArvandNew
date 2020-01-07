using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

using System.Runtime.InteropServices;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Management;

using System.Net.Sockets;
using System.Security.Cryptography;
using System.Drawing.Text;
using System.Globalization;
using Telerik.WinControls.Layouts;

using realstate.Classes;
using realstate.ListOfAdds;
using realstate.VM;
using realstate.ListOfAdds.Inbox;

namespace realstate
{


    public partial class main : Form
    {

        FontClass fontclass = new FontClass();
        databaseManager manager = new databaseManager();
        public main()
        {
           
            InitializeComponent();
          
        }

        private void addfileBotton_Click(object sender, EventArgs e)
        {
            manageFile managefile = new manageFile();
            managefile.Show();
        }

        private void getDateForm_Click(object sender, EventArgs e)
        {
            getData getdata = new getData();
            getdata.Show();
           
        }

        private void searchFiltButt_Click(object sender, EventArgs e)
        {

            search srch = new search();
            srch.Show();
            //fileList filelist = new fileList();
            //filelist.Show();
        }

        private void main_Load(object sender, EventArgs e)
        {
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            this.CenterToScreen();
            dataLable.Text = dateTimeConvert.ToPersianDateString(DateTime.Now);
            manager.delinbox();
            getInbox();// admin only get any message from internetServer
            getNewMessageNumber(System.Environment.MachineName);// user
        }
        private void getNewMessageNumber(string name)
        {
            int count = 0;
            string srt = manager.GetLatestMessageNumber(name);
            if (srt.Length > 1)
            {
                GlobalVariable.notSeenInbox = srt;
                srt = srt.Substring(1, srt.Length - 2);
                count = srt.Split(',').ToList().Count();
            }
           
            if (count > 0)
            {
                newMessage.Text = count.ToString();
            }
        }
        private void register_Click(object sender, EventArgs e)
        {
            Register REGISTER = new Register();
            REGISTER.Show();
        }

        private void archive_Click(object sender, EventArgs e)
        {
            BackgroundWorker getDataBackGroundWorker = new BackgroundWorker();
            getDataBackGroundWorker.WorkerSupportsCancellation = true;
            getDataBackGroundWorker.DoWork += new DoWorkEventHandler(getDataBackGroundWorker_do);
            getDataBackGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getDataBackGroundWorker_done);
            getDataBackGroundWorker.RunWorkerAsync(argument: System.Environment.MachineName);
        }
        void getDataBackGroundWorker_do(object sender, DoWorkEventArgs e)
        {


            string NAME = (string)e.Argument;
            string S = "";


            try
            {
                CatsAndAreasObject CATS = new CatsAndAreasObject();
                CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);

                List<gridVM> list = new List<gridVM>();
                List<item> Listitem = manager.getArchive(NAME);
                foreach (var item in Listitem)
                {
                    if (GlobalVariable.searchTabghe == "")
                    {
                        GlobalVariable.searchTabghe = "1";
                    }
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

                    if (item.maghaze != "0")
                    {
                        melkkind = melkkind + "مغازه،";
                    }
                    if (item.apartment != "0")
                    {
                        melkkind = melkkind + "آپارتمان،";
                    }
                    if (item.villa != "0")
                    {
                        melkkind = melkkind + "ویلا،";
                    }
                    if (item.mostaghellat != "0")
                    {
                        melkkind = melkkind + "مستغلات،";
                    }
                    if (item.kolangi != "0")
                    {
                        melkkind = melkkind + "کلنگی،";
                    }
                    if (item.office != "0")
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

                    //// جهت بازیابی آیتم های تیک خورده استفاده می شود
                    //if (.Contains(serverid + ","))
                    //{
                    //    mycheckbox = true;
                    //}
                    gridVM newitem = new gridVM()
                    {
                        phones = item.phones,
                        Address = item.address1 + item.address2 + item.address3,
                        Address1 = item.address1,
                        Address2 = item.address2,
                        Address3 = item.address3,
                        bed = kha,
                        codegrid = item.number.ToString(),
                        dategrid = dateTimeConvert.ToPersianDateString(item.date_updated),
                        ejare_metri = Convert.ToInt64(metriejare),
                        floorgrid = tabagh,
                        kindgrid = Dealkind,
                        typegrid = melkkind,
                        ownergrid = item.malek,
                        rahn_total = Convert.ToInt64(totalrahn),
                        zirbana = zirban,
                        checkbox = false,
                        Senn = senn,
                        mantagheName = item.mantaghe_name

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
        private void getDataBackGroundWorker_done(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() == "error")
            {
                //refresh.Visible = false;
            }
            else
            {

                fileList filelist = new fileList(e.Result.ToString());
                filelist.Show();
               // refresh.Visible = false;

            }
        }

        private void inbox_Click(object sender, EventArgs e)
        {
            
            Message message = new Message();
            message.Show();

        }
        
        private void getInbox()
        {
            string result = "";
            using (WebClient client = new WebClient())
            {
                var collection = new System.Collections.Specialized.NameValueCollection();
                collection.Add("serial-number", "1111-1111-1111-1111");
                collection.Add("after-date", DateTime.Now.ToString());



                //  string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
                byte[] response =
                client.UploadValues("http://Arvandfile.com/api/v2/inbox", collection);
                result = System.Text.Encoding.UTF8.GetString(response);
                InboxVM model = JsonConvert.DeserializeObject<InboxVM>(result);
                if (model.status == 200)
                {
                    foreach (var item in model.data.list)
                    {
                        manager.addToInbox(item);
                    }
                }


            }
        }
    }
}
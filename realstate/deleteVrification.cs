using Newtonsoft.Json;
using realstate.Classes;
using realstate.VM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace realstate
{
    public partial class deleteVrification : Form
    {
        FontClass fontclass = new FontClass();
        string id = "";
        string deltype = "";
        string EXTRA = "";
     
        databaseManager manager = new databaseManager();
        public deleteVrification(string srt, string type, string extradata)
        {
            deltype = type;
            EXTRA = extradata;
            InitializeComponent();
            id = srt;
            this.CenterToScreen();

            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            label1.Font = GlobalVariable.shoonzdah;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = "";
            if (deltype == "1")// حذف آیتم از سرور
            {
                using (WebClient client = new WebClient())
                {
                    var collection = new System.Collections.Specialized.NameValueCollection();
                    collection.Add("serial-number", Settings1.Default.SerialNumber);
                    collection.Add("fileID", id);



                    //  string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
                    byte[] response =
                    client.UploadValues("http://Arvandfile.com/api/v2/mark_as_expired", collection);
                    result = System.Text.Encoding.UTF8.GetString(response);

                    ExpireVM model = JsonConvert.DeserializeObject<ExpireVM>(result);
                    if (model.status == 200)
                    {
                        MessageBox.Show("فایل مورد نظر  منقضی شد");
                    }

                }
            }
            else if (deltype == "2")// حذف از آرشیو
            {
                manager.deleteArchive(Convert.ToInt64(id), EXTRA);
                this.Dispose();
                MessageBox.Show("آیتم مورد نظر از آرشیو شما حذف شد");
            }
            else if (deltype == "3")// حذف از آرشیو
            {
                manager.deleteitem(Convert.ToInt64(id));
                this.Dispose();
                MessageBox.Show("آیتم مورد نظر از پایگاه داده شما حذف شد");
            }
            else if (deltype == "4")// حذف از همشهری
            {
                manager.deleHamshari(id);
                this.Dispose();
                MessageBox.Show("آیتم مورد نظر از لیست همشهری  شما حذف شد");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

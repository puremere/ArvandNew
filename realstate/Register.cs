using Newtonsoft.Json;
using realstate.Classes;
using realstate.ListOfAdds;
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
    public partial class Register : Form
    {
        FontClass fontclass = new FontClass();
        functions classobj = new functions();
        public Register()
        {
            InitializeComponent();
            dopreliminaries();
        }
        private void dopreliminaries()
        {

            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            this.CenterToScreen();
        }

        private void VerifySerial_Click(object sender, EventArgs e)
        {
            loader.Visible = true;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.RunWorkerAsync();

        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string result = "";
            using (WebClient client = new WebClient())
            {
                var collection = new System.Collections.Specialized.NameValueCollection();
                collection.Add("serial-number", serialNumber.Text);



                //  string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
                byte[] response =
                client.UploadValues("http://Arvandfile.com/api/v2/validation", collection);
                result = System.Text.Encoding.UTF8.GetString(response);

                e.Result = result;

            }
               

        }
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            RegisterResponse model = JsonConvert.DeserializeObject<RegisterResponse>(e.Result.ToString());

            if(model.status != 200)
            {
                MessageBox.Show(model.message);
            }
            else
            {
                MessageBox.Show("سریال با موفقیت ثبت شد");

            }
            loader.Visible = false;
        }
    }
   
}

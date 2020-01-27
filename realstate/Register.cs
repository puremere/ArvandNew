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
            serialNumber.Text = "  - - - -   - - - -    - - - -   - - - -   ";
            serialNumber.Font = GlobalVariable.HlistFONT;
            label1.Font = GlobalVariable.shoonzdah;
            label3.Font = GlobalVariable.shoonzdah;
            this.MaximizeBox = false;
            if (Settings1.Default.SerialNumber != "")
            {
                checkSerial();
            }
        }

        private void checkSerial()
        {
            string check = serialNumber.Text.Trim().Replace("-", "");
            check = check.Replace(" ", "");
                if (check != "")
                {
                Settings1.Default.SerialNumber = serialNumber.Text.Trim();
                loader.Visible = true;
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                backgroundWorker.RunWorkerAsync();
            }
                else if (Settings1.Default.SerialNumber != "")
            {
                loader.Visible = true;
                BackgroundWorker backgroundWorker = new BackgroundWorker();
                backgroundWorker.WorkerSupportsCancellation = true;
                backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
                backgroundWorker.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("شماره سریال صحیح وارد نمایید");
            }
        }
        private void VerifySerial_Click(object sender, EventArgs e)
        {

            checkSerial();

        }
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            string result = "";
            using (WebClient client = new WebClient())
            {
                var collection = new System.Collections.Specialized.NameValueCollection();
                collection.Add("serial-number", Settings1.Default.SerialNumber);



                //  string json = JsonConvert.SerializeObject(collection, Formatting.Indented);
                byte[] response =
                client.UploadValues("http://Arvandfile.com/api/v2/validation", collection);
                result = System.Text.Encoding.UTF8.GetString(response);
                RegisterResponse model = JsonConvert.DeserializeObject<RegisterResponse>(result);

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
                if (model.data.is_valid != true)
                {
                    expireDate.Text = model.data.expire_timestamp;
                    ActivePanel.Visible = true;
                    ActivePanel.BackColor = Color.Red;
                    label3.Text = "غیر فعال";
                }
                else
                {
                    if (Settings1.Default.SerialNumber == "")
                    {
                        Settings1.Default.SerialNumber = serialNumber.Text;
                        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dtDateTime = dtDateTime.AddSeconds(double.Parse(model.data.expire_timestamp)).ToLocalTime();
                        string DATE = dateTimeConvert.ToPersianDateString(dtDateTime);
                        expireDate.Text = DATE;
                        ActivePanel.Visible = true;
                        MessageBox.Show("سریال با موفقیت ثبت شد");
                    }
                    else
                    {
                        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                        dtDateTime = dtDateTime.AddSeconds(double.Parse(model.data.expire_timestamp)).ToLocalTime();
                        string DATE = dateTimeConvert.ToPersianDateString(dtDateTime);
                        expireDate.Text = DATE;
                        ActivePanel.Visible = true;
                        serialNumber.Text = Settings1.Default.SerialNumber;
                    }
                      
                }
                

            }
            loader.Visible = false;
        }

        private void serialNumber_KeyDown(object sender, KeyEventArgs e)
        {
            string real = serialNumber.Text.Trim().Replace("-", "");
            if (((real.Length) % 4) == 0 && serialNumber.Text.Length > 0 && serialNumber.Text.Length != 19)
            {
                string srt = serialNumber.Text + "-";

                serialNumber.Text = srt;
                serialNumber.SelectionStart = serialNumber.Text.Length;
                serialNumber.SelectionLength = 0;
            }
        }

        private void serialNumber_Enter(object sender, EventArgs e)
        {
            if (serialNumber.Text.Contains("-") )
            {
                serialNumber.Text = "";
            }
        }

        private void serialNumber_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(serialNumber.Text))
                serialNumber.Text = "  - - - -   - - - -    - - - -   - - - -   ";
        }

        private void serialNumber_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
   
}

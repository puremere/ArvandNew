using Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using realstate.Classes;
using System.Drawing.Text;

namespace realstate
{
    public partial class Form3 : Form
    {
        databaseManager manager = new databaseManager();
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();
        FontClass fontclass = new FontClass();
        BackgroundWorker backgroundWorkerSearch = new BackgroundWorker();
        public void initFont()
        {

            byte[] fontData = Properties.Resources.IRANSans_FaNum_;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.IRANSans_FaNum_.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.IRANSans_FaNum_.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            GlobalVariable.headerlistFONT = new Font(fonts.Families[0], 9.0F, System.Drawing.FontStyle.Regular);
            GlobalVariable.headerlistFONTsmall = new Font(fonts.Families[0], 8.0F, System.Drawing.FontStyle.Regular);
            GlobalVariable.headerlistFONTBold = new Font(fonts.Families[0], 11.0F, System.Drawing.FontStyle.Bold);


            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);

        }
        public Form3()
        {
            InitializeComponent();
           
        }
      
        private void Form3_Load(object sender, EventArgs e)
        {
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            username.Text = Settings1.Default.username;
            password.Text = Settings1.Default.password;
            this.CenterToScreen();
            backgroundWorkerSearch.WorkerSupportsCancellation = true;
            backgroundWorkerSearch.DoWork += new DoWorkEventHandler(backgroundWorkerSearch_DoWork);
            backgroundWorkerSearch.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerSearch_RunWorkerCompleted);
            //setfont
            initFont();
        }


        private void confirm_Click(object sender, EventArgs e) {

            if (username.Text == "1" && password.Text == "1")
            {
                backgroundWorkerSearch.RunWorkerAsync();
                confirm.Enabled = false;
                loadingIMG.Visible = true;
            }
        }

        private void backgroundWorkerSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            string result = "";
           
            
            try
            {

                using (WebClient client = new WebClient())
                {
                    string srt ="";// manager.getCats();
                    if (srt == "")
                    {
                        var collection = new System.Collections.Specialized.NameValueCollection();
                        collection.Add("serial-number", "1111-1111-1111-1111");
                        byte[] response =
                        client.UploadValues("http://Arvandfile.com/api/v2/collections", collection);
                        result = System.Text.Encoding.UTF8.GetString(response);
                        manager.saveCats(result);
                        srt = result;
                    }

                   
                    

                    //CatsAndAreasObject CATS = new CatsAndAreasObject();
                    //CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(srt);
                    GlobalVariable.newCatsAndAreas = srt;


                }

                //this.Close();
            }
            catch (Exception eror)
            {
                e.Result = eror;
               // loadingIMG.Visible = false;
                backgroundWorkerSearch.CancelAsync();
                
            }
        }
        
        private void backgroundWorkerSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Result.ToString());
                // handle the error
            }
            else if (e.Cancelled)
            {
                
                //MessageBox.Show("خطا در ارتباط با سرور، لطفاً مجدداً تلاش کنید");
            }
            else
            {
                if (e.Result != null)
                {
                    MessageBox.Show(e.Result.ToString());
                }
                else
                {
                    main main = new main();
                    main.Show();
                    this.Visible = false;
                }
               
               
                // use it on the UI thread
            }
            confirm.Enabled = true;
            loadingIMG.Visible = false;
        }











    }
}

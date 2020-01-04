using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using System.Windows.Forms;
using System.Drawing;
using Telerik.WinControls;
using System.IO;

namespace realstate
{

    class Context
    {

    }

    public class Dialog
    {
        public int status { get; set; }
        public bool showDialog { get; set; }
        public string dialogTitle { get; set; }
        public string dialogMessage { get; set; }
        public string positiveBtn { get; set; }
        public string positiveBtnUrl { get; set; }
        public string negativeBtn { get; set; }
    }

    public class LoginResult
    {
        public string token { get; set; }
        public int users_limit { get; set; }
        public string status { get; set; }
        public string exp_date { get; set; }
        public int exp_timestamp { get; set; }
        public string message { get; set; }
    }

    public class responseModel
    {
        public Dialog dialog { get; set; }
        public LoginResult loginResult { get; set; }
    }


    public class Response
    {
        public int status { get; set; }
        public bool showDialog { get; set; }
        public string dialogTitle { get; set; }
        public string dialogMessage { get; set; }
        public string positiveBtn { get; set; }
        public string positiveBtnUrl { get; set; }
        public string negativeBtn { get; set; }
    }

    public class errorResponse
    {
        public Response response { get; set; }
    }








    public class File
    {
        public string tabaghat { get; set; }
        public string zirbana { get; set; }
        public string khab { get; set; }
        public string balkon { get; set; }
        public string telephone { get; set; }
        public string ashpazkhane { get; set; }
        public string open { get; set; }
        public string behdashti { get; set; }
        public string kafpoosh { get; set; }
        public bool parking { get; set; }
        public bool anbari { get; set; }
        public bool shoomine { get; set; }
        public string total_ptice { get; set; }
        public string metri { get; set; }
    }

  

   
    public class image
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ProductID { get; set; }
        public string name { get; set; }

    }




    public class MyElement : LightVisualElement
    {
        protected override void PaintElement(Telerik.WinControls.Paint.IGraphics graphics, float angle, SizeF scale)
        {
            object state = graphics.SaveState();

            Graphics g = (graphics.UnderlayGraphics as Graphics);

            Rectangle rect = new Rectangle(0, 0, this.Bounds.Width, this.Bounds.Height);
            g.SetClip(this.Shape.CreatePath(rect), System.Drawing.Drawing2D.CombineMode.Intersect);

            base.PaintElement(graphics, angle, scale);

            graphics.RestoreState(state);
        }
    }




    public class mehrdadPanel : RadLabelElement
    {



        public string name { get; set; }
        // main main = new main();
        RadLabelElement label = null;
        RadLabelElement label2 = null;
        RadPanelElement panel = null;
        RadLabelElement label3 = null;
        RadLabelElement label4 = null;
        RadLabelElement label5 = null;
        RadLabelElement label6 = null;
        RadLabelElement label7 = null;
        RadLabelElement label8 = null;
        RadLabelElement label9 = null;
        RadLabelElement label10 = null;
        RadLabelElement label11 = null;
        RadLabelElement label12 = null;
        RadCheckBoxElement checkbox = null;
       




    
        private void detailpic_click(object sender, EventArgs e)
        {
            var pic = (MyElement)sender;
            string server_id = pic.Name;
            //GlobalVariable.selectedIDofList = server_id;
            //Form2 form2 = new Form2(server_id);
           // form2.Show();

        }
 


        public RadPanelElement getView()
        {
            return panel;
        }

        public void setTitle(String serverid, String date, String owner, String melkkind, String dealkind, String totalrahn, String metriejare, string tabaghe, string khab, string zirbana, bool mycheckbox, string address, string senn)
        {
            label.Text = serverid;
            label2.Text = date;
            label3.Text = owner;
            label4.Text = melkkind;
            label5.Text = dealkind;
            label6.Text = totalrahn;
            label7.Text = metriejare;
            label8.Text = tabaghe;
            label9.Text = senn;
            label10.Text = khab;
            label11.Text = zirbana;
            label12.Text = address;
            
            checkbox.Checked = mycheckbox;
            checkbox.Name = address;
            //imp.Name = serverid;
            //Picpanel.Name = "P" + serverid;

            //impon.Name = "1" + serverid;
            //impoff.Name = "0" + serverid;
            //  string listid = Settings1.Default.ides;
            //if (Settings1.Default.ides.Contains(serverid))
            //{

            //    if (panel.Children.Contains(Picpaneloff))
            //    {
            //        panel.Children.Remove(Picpaneloff);
            //    }
            //}
            //else
            //{
            //    if (panel.Children.Contains(Picpanelon))
            //    {
            //        panel.Children.Remove(Picpanelon);
            //    }

            //}

        }


    }
    
}

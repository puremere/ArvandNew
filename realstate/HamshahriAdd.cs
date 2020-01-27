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
    
    public partial class HamshahriAdd : Form
    {
        databaseManager manager = new databaseManager();
        FontClass fontclass = new FontClass();

        public HamshahriAdd()
        {
            InitializeComponent();
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            this.CenterToScreen();
            label3.Font = GlobalVariable.HlistFONT;
            label4.Font = GlobalVariable.headerlistFONTBold;
        }

        private void addHamshahri_Click(object sender, EventArgs e)
        {
            string Ti = Htitle.Text;
            string con = content.Text;
            if (Ti != "" && con != "")
            {
               int status =  manager.addToHamshahri(Ti,con);
                if (status == 200)
                {
                    MessageBox.Show("پیام شما با موفقیت منتقل شد");
                }
                else
                {
                    MessageBox.Show("خطا! لطفاً دوباره تلاش کنید");

                }
            }
            else
            {
                MessageBox.Show("عنوان و متن را وارد نمایید");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

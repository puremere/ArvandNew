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
    public partial class Message : Form
    {
        databaseManager manager = new databaseManager();
        FontClass fontclass = new FontClass();
        public Message()
        {
            InitializeComponent();
           
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            setDataForGrid("");
            this.CenterToScreen();
            //
            header.Font = GlobalVariable.shoonzdah;
            int count = 0;
            try
            {
                string srt = GlobalVariable.notSeenInbox.Substring(2, GlobalVariable.notSeenInbox.Count() - 3);
                 count = srt.Split(',').Count();
                List<string> countList = srt.Split(',').ToList();
            }
            catch (Exception)
            {

               
            }
            
            

            if (count > 0)
            {
                label1.Text = count.ToString() + " مورد خوانده نشده ";
            }
            else
            {
                label1.Visible = false;
            }
        }

        private void setDataForGrid(string search)
        {
            List<Inbox> list = manager.GetLatestMessage(System.Environment.MachineName, search);
            List<NewInbox> listVM = new List<NewInbox>();

            foreach (var item in list)
            {
                listVM.Add(new NewInbox()
                {
                    date = dateTimeConvert.ToPersianDateString(item.date),
                    message = item.message,
                    ID = item.ID,
                    title = item.title,
                    to = item.to,
                    userWatched = item.userWatched
                });

            }
            dataGridView1.DataSource = listVM;
            this.dataGridView1.Columns["ID"].Visible = false;
            this.dataGridView1.Columns["userWatched"].Visible = false;
            this.dataGridView1.Columns["to"].Visible = false;
            this.dataGridView1.Columns["message"].Visible = false;
            this.dataGridView1.Columns["title"].HeaderText = "عنوان";
            this.dataGridView1.Columns["date"].HeaderText = "تاریخ";
            this.dataGridView1.Columns["message"].HeaderText = "متن پیام";
           
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                for (int index = e.RowIndex; index <= e.RowIndex + e.RowCount - 1; index++)
                {
                    DataGridViewRow row = dataGridView1.Rows[index];

                    
                    if (GlobalVariable.notSeenInbox.Contains("," + row.Cells[0].Value.ToString() + ","))
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
                
            }
            catch (Exception ex)
            {
                //ErrorLabel.Text = ex.Message;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;
            int row = e.RowIndex;
            if (row > -1)
            {
                richTextBox1.Text = this.dataGridView1.Rows[row].Cells[1].Value.ToString();

            }

        }

        private void searchInbox_Click(object sender, EventArgs e)
        {
            string srt = search.Text;
            manager.GetLatestMessage(System.Environment.MachineName, srt);
        }

        private void searchInbox_Click_1(object sender, EventArgs e)
        {

        }

        private void search_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(search.Text))
                search.Text = "جستجو در پیام ها";
        }

        private void search_Enter(object sender, EventArgs e)
        {
            if (search.Text == "جستجو در پیام ها")
            {
                search.Text = "";
            }
        }
       
       
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using System.Reflection;
using System.Globalization;

namespace realstate
{

    public partial class manageFile : Form
    {

        databaseManager dbmanager = new databaseManager();
        Classes.functions FUNS = new Classes.functions();
        Classes.FontClass fontclass = new Classes.FontClass();
        ListOfAdds.File obj = new ListOfAdds.File();
        CatsAndAreasObject CATS = null;
        public manageFile()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

      
        

        public string SetDropDownValue(string value, string collection)
        {
            string final = "";
            if (value == "0")
            {
                return "-";
            }
            if (!value.All(char.IsDigit))
            {
                final = value;
            }

            else if (value.Contains(","))
            {

                string srt = value.Remove(value.Length - 1, 1);
                srt = srt.Remove(0, 1);

                if (srt.Contains(','))
                {
                    List<string> lstsg3 = srt.Split(',').ToList();
                    foreach (var itemm in lstsg3)
                    {
                        switch (collection)
                        {
                            case "apartment":
                                final = final + (from q in CATS.data.list.apartment
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "villa":
                                final = final + (from q in CATS.data.list.villa
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "office":
                                final = final + (from q in CATS.data.list.office
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "mostaghellat":
                                final = final + (from q in CATS.data.list.mostaghellat
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "kolangi":
                                final = final + (from q in CATS.data.list.kolangi
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "samt":
                                final = final + (from q in CATS.data.list.samt
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "senn":
                                final = final + (from q in CATS.data.list.senn
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "sanad":
                                final = final + (from q in CATS.data.list.sanad
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "seraydar":
                                final = final + (from q in CATS.data.list.seraydar
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "mantaghe_id":
                                final = final + (from q in CATS.data.list.mantaghe_id
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "mantaghe":
                                final = final + (from q in CATS.data.list.mantaghe
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "kaf_type":
                                final = final + (from q in CATS.data.list.kaf_type
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "garmayesh_sarmayesh":
                                final = final + (from q in CATS.data.list.garmayesh_sarmayesh
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "ashpazkhane1":
                                final = final + (from q in CATS.data.list.ashpazkhane
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "ashpazkhane2":
                                final = final + (from q in CATS.data.list.ashpazkhane
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "ashpazkhane3":
                                final = final + (from q in CATS.data.list.ashpazkhane
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;

                        }

                    }
                }


                final = final.Remove(final.Length - 1, 1);


            }
            else
            {
                switch (collection)
                {
                    case "apartment":
                        final = (from q in CATS.data.list.apartment
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "villa":
                        final = (from q in CATS.data.list.villa
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "office":
                        final = (from q in CATS.data.list.office
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "mostaghellat":
                        final = (from q in CATS.data.list.mostaghellat
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "kolangi":
                        final = (from q in CATS.data.list.kolangi
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "samt":
                        final = (from q in CATS.data.list.samt
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "senn":
                        final = (from q in CATS.data.list.senn
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "sanad":
                        final = (from q in CATS.data.list.sanad
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "seraydar":
                        final = (from q in CATS.data.list.seraydar
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "mantaghe_id":
                        final = (from q in CATS.data.list.mantaghe_id
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "mantaghe":
                        final = (from q in CATS.data.list.mantaghe
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "kaf_type":
                        final = (from q in CATS.data.list.kaf_type
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "garmayesh_sarmayesh":
                        final = (from q in CATS.data.list.garmayesh_sarmayesh
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "ashpazkhane1":
                        final = (from q in CATS.data.list.ashpazkhane
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "ashpazkhane2":
                        final = (from q in CATS.data.list.ashpazkhane
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "ashpazkhane3":
                        final = (from q in CATS.data.list.ashpazkhane
                                 where q.ID == value
                                 select q.title).First();
                        break;

                }
            }

            return final;

        }
        private void SetDelimiter(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox.Text != "")
            {
                textbox.Text = string.Format("{0:#,##0}", double.Parse(textbox.Text));
            }
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
     
        private void manageFile_Load(object sender, EventArgs e)
        {
            List<Control> allControls = fontclass.GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
            CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
            //CATS = GlobalVariable.catsAndAreas;
            delete.Visible = false;
            deletepanel.Visible = false;

           
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            
            // جهت فراخوانی فایل آرشیو شده به کار می رود
            if (GlobalVariable.selectedOwnObject != null)
            {
                obj = GlobalVariable.selectedOwnObject;

                InitControl();
            }
            else
            {
                setcat();
               // setcatforclient();
               
            }

            


        }

        public void InitControl()
        {

            CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);



            title.Text = obj.title;
            List<string> phones = JsonConvert.DeserializeObject<List<string>>(obj.phones);

            if (obj.phones != null)
            {
                try
                {
                    phone1.Text = phones[0];
                }
                catch (Exception)
                {

                    phone1.Text = "";
                }
                try
                {
                    phone2.Text = phones[1];
                }
                catch (Exception)
                {

                    phone2.Text = "";
                }
                try
                {
                    phone3.Text = phones[2];
                }
                catch (Exception)
                {

                    phone3.Text = "";
                }

            }


            owner.Text = obj.malek;
            address.Text = obj.address;
            date_updated.Text = obj.date_updated;
            ID.Text = obj.ID;
            total_vahed.Text = obj.total_vahed;
            total_floor.Text = obj.total_floor;
            vahed_per_floor.Text = obj.vahed_per_floor;
            zirbana1.Text = obj.zirbana1;
            zirbana2.Text = obj.zirbana2;
            zirbana3.Text = obj.zirbana3;
            khab1.Text = obj.bed1;
            khab2.Text = obj.bed2;
            khab3.Text = obj.bed3;
            tabaghe1.Text = obj.tabaghe1;
            tabaghe2.Text = obj.tabaghe2;
            tabaghe3.Text = obj.tabaghe3;
            tabaghe_1_rahn.Text = getChangedValue(obj.tabaghe_1_rahn);
            tabaghe_2_rahn.Text = getChangedValue(obj.tabaghe_2_rahn);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_2_rahn));
            tabaghe_3_rahn.Text = getChangedValue(obj.tabaghe_3_rahn);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_3_rahn));
            tabaghe_1_ejare.Text = getChangedValue(obj.tabaghe_1_ejare);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_1_ejare));
            tabaghe_2_ejare.Text = getChangedValue(obj.tabaghe_2_ejare);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_2_ejare));
            tabaghe_3_ejare.Text = getChangedValue(obj.tabaghe_3_ejare);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_3_ejare));
            tabaghe_1_total_price.Text = getChangedValue(obj.tabaghe_1_total_price);//== "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_1_total_price));
            tabaghe_2_total_price.Text = getChangedValue(obj.tabaghe_2_total_price);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_2_total_price));
            tabaghe_3_total_price.Text = getChangedValue(obj.tabaghe_3_total_price);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_3_total_price));
            tabaghe_1_metri.Text = getChangedValue(obj.tabaghe_1_metri);// string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64();
            tabaghe_2_metri.Text = getChangedValue(obj.tabaghe_2_metri);// string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64();
            tabaghe_3_metri.Text = getChangedValue(obj.tabaghe_3_metri);// string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64();
            tarakom.Text = obj.tarakom;
            toole_bar.Text = obj.toole_bar;
            masahat_zamin.Text = obj.masahat_zamin;
            ertefa.Text = obj.ertefa;
            eslahi.Text = obj.eslahi;
            zirzamin.Text = obj.zirzamin;
            desc.Text = obj.desc;
            isForoosh.Checked = obj.isForoosh == "1" ? true : false;
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
            senn.Text = obj.senn == "0" ? "-" : (from q in CATS.data.list.senn
                                                 where q.ID == obj.senn
                                                 select q.title).First();


            samt.Text = obj.samt == "0" ? "-" : (from q in CATS.data.list.samt
                                                 where q.ID == obj.samt
                                                 select q.title).First();

            sanad.Text = obj.sanad == "0" ? "-" : (from q in CATS.data.list.sanad
                                                   where q.ID == obj.sanad
                                                   select q.title).First();







        }

        private void confirm_Click(object sender, EventArgs e)
        {


            if (title.Text != "")
            {
                //در اینجا لیست آیتم ها به جای اینکه از فایل خوانده شود باید از دیتا بیس خوانده شود
                
                List<ListOfAdds.item> list = new List<ListOfAdds.item>();
                long id = 0;
                
                id =Convert.ToInt64(ID.Text);
                ListOfAdds.item model = list.Where(x => x.number == id).FirstOrDefault();
                if (model == null)
                {
                    model = new ListOfAdds.item();
                    id =Convert.ToInt64(FUNS.RandomStringDIGIT(7));
                }
                string PHNS = "";
                    if (phone1.Text != "")
                {
                    PHNS = PHNS + phone1.Text + ",";
                }
                if (phone2.Text != "")
                {
                    PHNS = PHNS + phone2.Text + ",";
                }
                if (phone3.Text != "")
                {
                    PHNS = PHNS + phone3.Text + ",";
                }
                if (phone4.Text != "")
                {
                    PHNS = PHNS + phone4.Text + ",";
                }
              
                model.address = address.Text;

                model.anbari1 = anbari1.Checked ? "1" : "0";
                model.anbari2 = anbari2.Checked ? "1" : "0";
                model.anbari3 = anbari3.Checked ? "1" : "0";
                model.asansor1 = asansor1.Checked ? "1" : "0";
                model.asansor2 = asansor2.Checked ? "1" : "0";
                model.asansor3 = asansor3.Checked ? "1" : "0";


                model.desc = desc.Text;
                model.ertefa = ertefa.Text;
                model.eslahi = eslahi.Text;
                model.hasEstakhr = hasEstakhr.Checked ? "1" : "0";
                model.hasJakoozi = hasJakoozi.Checked ? "1" : "0";
                model.hasSauna = hasSauna.Checked ? "1" : "0";
                model.number = id;
                model.isEjare = isEjare.Checked ? "1" : "0";
                model.isForoosh = isForoosh.Checked ? "1" : "0";
                model.isMoaveze = isMoaveze.Checked ? "1" : "0";
                model.isMosharekat = isMosharekat.Checked ? "1" : "0";
                model.isRahn = isRahn.Checked ? "1" : "0";

                model.maghaze = maghaze.Checked ? "1" : "0";
                model.malek = owner.Text;


                model.phones = PHNS;

                model.sell2khareji = sell2khareji.Checked ? "1" : "0";

                model.suit = suit.Checked ? "1" : "0";

                model.tabaghe_1_ejare =Convert.ToInt32(tabaghe_1_ejare.Text.Replace(",",""));
                model.tabaghe_1_metri =Convert.ToInt32( tabaghe_1_metri.Text.Replace(",", ""));
                model.tabaghe_1_rahn =Convert.ToInt32( tabaghe_1_rahn.Text.Replace(",", ""));
                model.tabaghe_1_total_price =Convert.ToInt32( tabaghe_1_total_price.Text.Replace(",", ""));
                model.tabaghe_2_ejare =Convert.ToInt32( tabaghe_2_ejare.Text.Replace(",", ""));
                model.tabaghe_2_metri =Convert.ToInt32( tabaghe_2_metri.Text.Replace(",", ""));
                model.tabaghe_2_rahn =Convert.ToInt32( tabaghe_2_rahn.Text.Replace(",", ""));
                model.tabaghe_2_total_price =Convert.ToInt32( tabaghe_2_total_price.Text.Replace(",", ""));
                model.tabaghe_3_ejare =Convert.ToInt32( tabaghe_3_ejare.Text.Replace(",", ""));
                model.tabaghe_3_metri =Convert.ToInt32( tabaghe_3_metri.Text.Replace(",", ""));
                model.tabaghe_3_rahn =Convert.ToInt32( tabaghe_3_rahn.Text.Replace(",", ""));
                model.tabaghe_3_total_price =Convert.ToInt32( tabaghe_3_total_price.Text.Replace(",", ""));

                model.takhlie = takhlie.Checked ? "1" : "0";
                model.tarakom = tarakom.Text;
                model.title = title.Text;
                model.toole_bar = toole_bar.Text;
                model.total_floor = Convert.ToInt64(total_floor.Text);
                model.total_vahed = Convert.ToInt64(total_vahed.Text);
                model.vahed_per_floor = Convert.ToInt64(vahed_per_floor.Text);

                model.zirzamin = zirzamin.Text;
                model.tabaghe1 = Convert.ToInt32(tabaghe1.Text);
                model.tabaghe2 = Convert.ToInt32(tabaghe2.Text);
                model.tabaghe3 = Convert.ToInt32(tabaghe3.Text);
                model.balkon1 = balkon1.Checked ? "1" : "0";
                model.balkon2 = balkon2.Checked ? "1" : "0";
                model.balkon3 = balkon3.Checked ? "1" : "0";
                model.bed1 = Convert.ToInt32(khab1.Text);
                model.bed2 = Convert.ToInt32(khab2.Text);
                model.bed3 = Convert.ToInt32(khab3.Text);
                model.date_updated = Convert.ToDateTime(date_updated.Text);
                model.hasGym = hasGym.Checked ? "1" : "0";
                model.hasHall = hasHall.Checked ? "1" : "0";
                model.hasLobbyMan = hasLobbyMan.Checked ? "1" : "0";
                model.hasRoofGarden = hasRoofGarden.Checked ? "1" : "0";
                model.hasShooting = hasShooting.Checked ? "1" : "0";
                model.isMoble = isMoble.Checked ? "1" : "0";
                model.parking1 = parking1.Checked ? "1" : "0";
                model.parking2 = parking2.Checked ? "1" : "0";
                model.parking3 = parking3.Checked ? "1" : "0";

                model.zirbana1 = Convert.ToInt32(zirbana1.Text);
                model.zirbana2 = Convert.ToInt32(zirbana2.Text);
                model.zirbana3 = Convert.ToInt32(zirbana3.Text);

                

                // تا اینجا مدل یا ادیت شده یا ساخته شده که باید در دیتا بیس یا سرور اضافه 
                // یا ادیت شود که بستگی به چک باکس های داخل صفحه دارد

                if (dbSave.Checked == true)
                {
                    dbmanager.deleteitem(id);
                    dbmanager.additem(model);
                   
                    // در دیتا بیس ذخیره کن
                }
                if(serverSave.Checked == true)
                {
                    // بفرست به سمت سرور
                }
                
            }
            else
            {
                MessageBox.Show("عنوان فایل وجود ندارد");
            }




        }


        private void deletItem(object sender, EventArgs e)
        {
           
            if (ID.Text.Length == 0)
            {
                MessageBox.Show("شماره فایل نباید خالی باشد");
                return;
            }
            string id = ID.Text;
            if(dbSave.Checked == true)
            {
                // حذف از دیتا بیس
            }
            if (serverSave.Checked == true)
            {
                // حذف از سرور
            }
            MessageBox.Show("فایل مورد نظر با موفقیت حذف شد");
            this.Dispose();
        }

        

        public void setcat()
        {


            CatsAndAreasObject log = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
            Settings1.Default.IsLogedIn = "1";

            apartment.DisplayMember = "title";
            apartment.ValueMember = "ID";
            apartment.DataSource = new BindingSource(log.data.list.apartment, null);


            ashpazkhane1.DisplayMember = "title";
            ashpazkhane1.ValueMember = "ID";
            ashpazkhane1.DataSource = new BindingSource(log.data.list.ashpazkhane, null);
            ashpazkhane2.DisplayMember = "title";
            ashpazkhane2.ValueMember = "ID";
            ashpazkhane2.DataSource = new BindingSource(log.data.list.ashpazkhane, null);
            ashpazkhane3.DisplayMember = "title";
            ashpazkhane3.ValueMember = "ID";
            ashpazkhane3.DataSource = new BindingSource(log.data.list.ashpazkhane, null);

            office.DisplayMember = "title";
            office.ValueMember = "ID";
            office.DataSource = new BindingSource(log.data.list.office, null);

            kolangi.DisplayMember = "title";
            kolangi.ValueMember = "ID";
            kolangi.DataSource = new BindingSource(log.data.list.kolangi, null);


            villa.DisplayMember = "title";
            villa.ValueMember = "ID";
            villa.DataSource = new BindingSource(log.data.list.villa, null);

            
            mostaghellat.DisplayMember = "title";
            mostaghellat.ValueMember = "ID";
            mostaghellat.DataSource = new BindingSource(log.data.list.mostaghellat, null);
            
            mantaghe_name.DisplayMember = "title";
            mantaghe_name.ValueMember = "ID";
            mantaghe_name.DataSource = new BindingSource(log.data.list.mantaghe, null);


            mantaghe_id.DisplayMember = "title";
            mantaghe_id.ValueMember = "ID";
            mantaghe_id.DataSource = new BindingSource(log.data.list.mantaghe_id, null);


            samt.DisplayMember = "title";
            samt.ValueMember = "ID";
            samt.DataSource = new BindingSource(log.data.list.samt, null);
            senn.DisplayMember = "title";
            senn.ValueMember = "ID";
            senn.DataSource = new BindingSource(log.data.list.senn, null);

            seraydar.DisplayMember = "title";
            seraydar.ValueMember = "ID";
            seraydar.DataSource = new BindingSource(log.data.list.seraydar, null);

            kaf_type.DisplayMember = "title";
            kaf_type.ValueMember = "ID";
            kaf_type.DataSource = new BindingSource(log.data.list.kaf_type, null);


            garmayesh_sarmayesh.DisplayMember = "title";
            garmayesh_sarmayesh.ValueMember = "ID";
            garmayesh_sarmayesh.DataSource = new BindingSource(log.data.list.garmayesh_sarmayesh, null);
            
        }
      
        
    }
}

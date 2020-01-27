using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using realstate.Model;
using realstate.ListOfAdds;
using Newtonsoft.Json;
using realstate.Classes;

namespace realstate
{
    class databaseManager
    {
        dbContext context = new dbContext();
        functions FUNS = new functions();

        public void addToArchive(string id, string name)
        {
            long ID = Convert.ToInt64(id);
            if (context.Archives.Any(x => x.number == ID && x.userName == name))
                return;
            item selectedITEM = context.items.Where(x => x.number == ID).FirstOrDefault();
            archive ARCHIVE = new archive()
            {
                address = selectedITEM.address,
                address1 = selectedITEM.address1,
                address2 = selectedITEM.address2,
                address3 = selectedITEM.address3,
                anbari1 = selectedITEM.anbari1,
                anbari2 = selectedITEM.anbari2,
                anbari3 = selectedITEM.anbari3,
                apartment = selectedITEM.apartment,
                asansor1 = selectedITEM.asansor1,
                asansor2 = selectedITEM.asansor2,
                asansor3 = selectedITEM.asansor3,
                ashpazkhane = selectedITEM.ashpazkhane,
                ashpazkhane1 = selectedITEM.ashpazkhane1,
                ashpazkhane2 = selectedITEM.ashpazkhane2,
                ashpazkhane3 = selectedITEM.ashpazkhane3,
                balkon1 = selectedITEM.balkon1,
                balkon2 = selectedITEM.balkon2,
                balkon3 = selectedITEM.balkon3,
                bed1 = selectedITEM.bed1,
                bed2 = selectedITEM.bed2,
                bed3 = selectedITEM.bed3,
                date_updated = selectedITEM.date_updated,
                desc = selectedITEM.desc,
                ertefa = selectedITEM.ertefa,
                eslahi = selectedITEM.eslahi,
                garmayesh_sarmayesh = selectedITEM.garmayesh_sarmayesh,
                gozar = selectedITEM.gozar,
                hasEstakhr = selectedITEM.hasEstakhr,
                hasGym = selectedITEM.hasGym,
                hasHall = selectedITEM.hasHall,
                hasJakoozi = selectedITEM.hasJakoozi,
                hasLobbyMan = selectedITEM.hasLobbyMan,
                hasRoofGarden = selectedITEM.hasRoofGarden,
                hasSauna = selectedITEM.hasSauna,
                hasShooting = selectedITEM.hasShooting,
                ID = selectedITEM.ID,
                isEjare = selectedITEM.isEjare,
                isForoosh = selectedITEM.isForoosh,
                isMoaveze = selectedITEM.isMoaveze,
                isMoble = selectedITEM.isMoble,
                isMosharekat = selectedITEM.isMosharekat,
                isRahn = selectedITEM.isRahn,
                kaf_type = selectedITEM.kaf_type,
                kolangi = selectedITEM.kolangi,
                maghaze = selectedITEM.maghaze,
                malek = selectedITEM.malek,
                mantaghe_id = selectedITEM.mantaghe_id,
                mantaghe_name = selectedITEM.mantaghe_name,
                masahat_zamin = selectedITEM.masahat_zamin,
                mostaghellat = selectedITEM.mostaghellat,
                no_tabdit = selectedITEM.no_tabdit,
                number = selectedITEM.number,
                office = selectedITEM.office,
                parking1 = selectedITEM.parking1,
                parking2 = selectedITEM.parking2,
                parking3 = selectedITEM.parking3,
                phones = selectedITEM.phones,
                samt = selectedITEM.samt,
                sanad = selectedITEM.sanad,
                sell2khareji = selectedITEM.sell2khareji,
                senn = selectedITEM.senn,
                seraydar = selectedITEM.seraydar,
                suit = selectedITEM.suit,
                tabaghe1 = selectedITEM.tabaghe_1_rahn,
                tabaghe_1_rahn = selectedITEM.tabaghe_1_rahn,
                tabaghe2 = selectedITEM.tabaghe2,
                tabaghe3 = selectedITEM.tabaghe3,
                tabaghe_1_ejare = selectedITEM.tabaghe_1_ejare,
                tabaghe_1_metri = selectedITEM.tabaghe_1_metri,
                tabaghe_1_total_price = selectedITEM.tabaghe_1_total_price,
                tabaghe_2_ejare = selectedITEM.tabaghe_2_ejare,
                tabaghe_2_metri = selectedITEM.tabaghe_2_metri,
                tabaghe_2_rahn = selectedITEM.tabaghe_2_rahn,
                tabaghe_2_total_price = selectedITEM.tabaghe_2_total_price,
                tabaghe_3_ejare = selectedITEM.tabaghe_3_ejare,
                tabaghe_3_metri = selectedITEM.tabaghe_3_metri,
                tabaghe_3_rahn = selectedITEM.tabaghe_3_rahn,
                tabaghe_3_total_price = selectedITEM.tabaghe_3_total_price,
                tabaghe_4_ejare = selectedITEM.tabaghe_4_ejare,
                tabaghe_4_metri = selectedITEM.tabaghe_4_metri,
                tabaghe_4_rahn = selectedITEM.tabaghe_4_rahn,
                tabaghe_4_total_price = selectedITEM.tabaghe_4_total_price,
                tabdil = selectedITEM.tabdil,
                takhlie = selectedITEM.takhlie,
                tarakom = selectedITEM.tarakom,
                title = selectedITEM.title,
                toole_bar = selectedITEM.toole_bar,
                total_floor = selectedITEM.total_floor,
                total_vahed = selectedITEM.total_vahed,
                userName = selectedITEM.userName,
                vahed_per_floor = selectedITEM.vahed_per_floor,
                villa = selectedITEM.villa,
                wc = selectedITEM.wc,
                zirbana1 = selectedITEM.zirbana1,
                wc1 = selectedITEM.wc1,
                wc2 = selectedITEM.wc2,
                wc3 = selectedITEM.wc3,
                zirbana2 = selectedITEM.zirbana2,
                zirbana3 = selectedITEM.zirbana3,
                zirzamin = selectedITEM.zirzamin,
            };
            ARCHIVE.userName = name;
            context.Archives.Add(ARCHIVE);
            context.SaveChanges();

        }
         public void addToInbox(ListOfAdds.Inbox.List input)
        {
            DateTime Date = Convert.ToDateTime(input.date);
            Inbox model = new Inbox() {

                message = input.message,
                date = Date,
                title = input.title,
                to = input.to,
                userWatched = ""
            };
            if (context.Inboxes.Any(x => x.date == Date && x.title == input.title)) return;
            context.Inboxes.Add(model);
            context.SaveChanges();
        }
        public int addToHamshahri(string title, string content)
        {
            try
            {
                context.Hames.Add(new Ham()
                {
                    content = content,
                    title = title

                });
                context.SaveChanges();
                return 200;
                
            }
             
            catch 
            {

                return 500;
            }
            
        }
        public List<Ham> getHamshahri()
        {
            return context.Hames.ToList();
        }
        public int deleHamshari(string ID)
        {
            try
            {
                Guid SID = Guid.Parse(ID);
                Ham model = context.Hames.Where(x => x.ID == SID).SingleOrDefault();

                context.Hames.Remove(model);
                context.SaveChanges();
                return 200;
            }
            catch (Exception error)
            {

                return 500;
            }
         
        }

        public void delinbox()
        {
            context.Inboxes.RemoveRange(context.Inboxes);
            context.SaveChanges();
        }
        public List<Inbox> GetLatestMessage(string name, string search)
        {
            List<Inbox> list = new List<Inbox>();
            foreach (var item in context.Inboxes.Where(x => !x.userWatched.Contains(name)).ToList())
            {
                item.userWatched = item.userWatched + "," + name;
            }
               
            try
            {
                if (search != "")
                {
                    list = context.Inboxes.Where(x=>x.title.Contains(search) || x.message.Contains(search)).OrderByDescending(x => x.date).ToList();

                }
                else
                {
                    list = context.Inboxes.OrderByDescending(x => x.date).ToList();

                }
            }
            catch (Exception)
            {

                
            }
            return list;
        }
        public string GetLatestMessageNumber(string name)
        {
            string srt = ",";
            List<Guid> count = context.Inboxes.Where(x => !x.userWatched.Contains(name)).Select(x => x.ID).ToList();

            foreach (var item in count)
            {
                srt = srt + item + ",";
            }
            return srt;
        }
        public List<archive> getArchive( string name)
        {
            List<archive> list = new List<archive>();
            try
            {
                list = context.Archives.Where(x => x.userName == name).ToList();
            }
         
            catch (Exception)
            {

            }
            return list;
        }
        public void deleteArchive (long number,string name)
        {
            try
            {
                context.Archives.Remove(context.Archives.Where(x => x.number == number && x.userName == name).SingleOrDefault());
                context.SaveChanges();
            }
            catch (Exception)
            {

            }
           
        }
        public void additem(item item)
        {
            long number = item.number;
            if (context.items.Any(o => o.number == number)) return;
            context.items.Add(item);
            context.SaveChanges();

        }
        public void deleteitem(long number)
        {

            item item = context.items.Where(b => b.number == number).FirstOrDefault();
            if (item != null)
            {

                context.items.Remove(item);
                context.SaveChanges();
            }

        }
        List<item> list = new List<item>();
        public List<item> getList(string query)
        {
            queryModel log = JsonConvert.DeserializeObject<queryModel>(query);
            List<item> lsT = context.items.ToList();
            IQueryable<item> q = context.items;
            IQueryable<item> final = null;
            if (log.address != "")
            {
                q = q.Where(x => x.address1.Contains(log.address) || x.address2.Contains(log.address) || x.address3.Contains(log.address3));
            }

            if (log.anbari == "1")
            {
                q = q.Where(x => x.anbari1 == "1" || x.anbari2 == "1" || x.anbari3 == "1");
            }
            if (log.apartment != "" && log.apartment != "0")
            {
                q = q.Where(x => x.apartment == log.apartment);

            }
            if (log.asansor == "1")
            {
                q = q.Where(x => x.asansor1 == "1" || x.asansor2 == "1" || x.asansor3 == "1");
            }
            if (log.ashpazkhane != "" && log.ashpazkhane != "0")
            {
                q = q.Where(x => x.ashpazkhane == log.ashpazkhane);
            }
            if (log.bed_from != "")
            {
                long needed = Convert.ToInt64(log.bed_from);
                q = q.Where(x => x.bed1 >= needed || x.bed2 >= needed || x.bed3 >= needed);
            }
            if (log.bed_to != "")
            {
                long needed = Convert.ToInt64(log.bed_to);
                q = q.Where(x => x.bed1 <= needed || x.bed2 <= needed || x.bed3 <= needed);
            }
            if (log.date_from != "")
            {
                DateTime needed = dateTimeConvert.ToGeorgianDateTime(log.date_from);
                q = q.Where(x => x.date_updated >= needed);
            }
            if (log.date_to != "")
            {
                DateTime needed = dateTimeConvert.ToGeorgianDateTime(log.date_to);
                q = q.Where(x => x.date_updated <= needed);
            }
            if (log.desc != "")
            {
                q = q.Where(x => x.desc.Contains(log.desc));
            }
            if (log.ejare_from != "")
            {
                long needed = Convert.ToInt64(log.ejare_from);
                q = q.Where(x => x.tabaghe_1_ejare >= needed || x.tabaghe_2_ejare >= needed || x.tabaghe_3_ejare >= needed);
            }
            if (log.ejare_to != "")
            {
                long needed = Convert.ToInt64(log.ejare_to);
                q = q.Where(x => x.tabaghe_1_ejare <= needed || x.tabaghe_2_ejare <= needed || x.tabaghe_3_ejare <= needed);
            }
            if (log.ertefa != "")
            {
                q = q.Where(x => x.ertefa == log.ertefa);
            }
            if (log.eslahi != "")
            {
                q = q.Where(x => x.eslahi == log.eslahi);
            }
            if (log.garmayesh_sarmayesh != "")
            {
                q = q.Where(x => x.garmayesh_sarmayesh == log.garmayesh_sarmayesh);
            }
            if (log.hasEstakhr != "")
            {
                q = q.Where(x => x.hasEstakhr == log.hasEstakhr);
            }
            if (log.hasGym != "")
            {
                q = q.Where(x => x.hasGym == log.hasGym);
            }
            if (log.hasHall != "")
            {
                q = q.Where(x => x.hasHall == log.hasHall);
            }
            if (log.hasJakoozi != "")
            {
                q = q.Where(x => x.hasJakoozi == log.hasJakoozi);
            }
            if (log.hasRoofGarden != "")
            {
                q = q.Where(x => x.hasRoofGarden == log.hasRoofGarden);
            }
            if (log.hasSauna != "")
            {
                q = q.Where(x => x.hasSauna == log.hasSauna);
            }
            if (log.hasSeraydar != "")
            {
                q = q.Where(x => x.hasSauna == log.hasSauna);
            }
            if (log.hasShooting != "")
            {
                q = q.Where(x => x.hasShooting == log.hasShooting);
            }
            if (log.hasShooting != "")
            {
                q = q.Where(x => x.hasShooting == log.hasShooting);
            }
            if (log.ID != "")
            {
                if (FUNS.IsDigitsOnly(log.ID))
                {
                    long needed = Convert.ToInt64(log.ID);
                    q = q.Where(x => x.number == needed);
                }

            }
            if (log.id_from != "")
            {
                if (FUNS.IsDigitsOnly(log.id_from))
                {
                    long needed = Convert.ToInt64(log.id_from);
                    q = q.Where(x => x.number >= needed);
                }

            }
            if (log.id_to != "")
            {
                if (FUNS.IsDigitsOnly(log.id_to))
                {
                    long needed = Convert.ToInt64(log.id_to);
                    q = q.Where(x => x.number >= needed);
                }

            }
            if (log.isEjare != "")
            {
                q = q.Where(x => x.isEjare == log.isEjare);

            }
            if (log.isForoosh != "")
            {
                q = q.Where(x => x.isForoosh == log.isForoosh);

            }
            if (log.isMoaveze != "")
            {
                q = q.Where(x => x.isMoaveze == log.isMoaveze);

            }
            if (log.isMoble != "")
            {
                q = q.Where(x => x.isMoble == log.isMoble);

            }
            if (log.isMosharekat != "")
            {
                q = q.Where(x => x.isMosharekat == log.isMosharekat);

            }
            if (log.isRahn != "")
            {
                q = q.Where(x => x.isRahn == log.isRahn);

            }
            if (log.kaf_type != "")
            {
                q = q.Where(x => x.kaf_type == log.kaf_type);
            }
            if (log.kind != "")
            {
                //{ "-", "آپارتمان", "دفتر کار", "کلنگی", "مستغلات", "ویلا","مغازه" };
                switch (log.kind)
                {
                    case "آپارتمان":
                        q = q.Where(x => x.apartment != "");
                        break;
                    case "ویلا":
                        q = q.Where(x => x.villa != "");
                        break;
                    case "مستغلات":
                        q = q.Where(x => x.mostaghellat != "");
                        break;
                    case "کلنگی":
                        q = q.Where(x => x.kolangi != "");
                        break;
                    case "دفتر کار":
                        q = q.Where(x => x.office != "");
                        break;
                    case "مغازه":
                        q = q.Where(x => x.maghaze != "");
                        break;
                }

            }
            if (log.malek != "")
            {
                q = q.Where(x => x.malek == log.malek);
            }
            if (log.mantaghe_id != "" && log.mantaghe_id != "0")
            {
                q = q.Where(x => x.mantaghe_id == log.mantaghe_id);
            }

            if (log.masahat_from != "")
            {
                long needed = Convert.ToInt64(log.masahat_from);
                q = q.Where(x => x.zirbana1 >= needed || x.zirbana2 >= needed || x.zirbana3 >= needed);
            }
            if (log.masahat_to != "")
            {
                long needed = Convert.ToInt64(log.masahat_to);
                q = q.Where(x => x.zirbana1 <= needed || x.zirbana2 <= needed || x.zirbana3 <= needed);
            }
            if (log.masahat_zamin != "")
            {
                long needed = Convert.ToInt64(log.masahat_zamin);
                q = q.Where(x => x.masahat_zamin == needed);
            }
            if (log.metri_from != "")
            {
                long needed = Convert.ToInt64(log.metri_from);
                q = q.Where(x => x.tabaghe_1_metri >= needed || x.tabaghe_2_metri >= needed || x.tabaghe_3_metri >= needed);
            }
            if (log.metri_to != "")
            {
                long needed = Convert.ToInt64(log.metri_to);
                q = q.Where(x => x.tabaghe_1_metri <= needed || x.tabaghe_1_metri <= needed || x.tabaghe_1_metri <= needed);
            }
            if (log.mostaghellat != "" && log.mostaghellat != "0")
            {

                q = q.Where(x => x.mostaghellat == log.mostaghellat);
            }
            if (log.office != "" && log.office != "0")
            {
                q = q.Where(x => x.office == log.office);
            }
            if (log.parking != "")
            {
                q = q.Where(x => x.parking3 == log.parking || x.parking3 == log.parking || x.parking3 == log.parking);
            }
            if (log.phones != "")
            {
                q = q.Where(x => x.phones.Contains(log.phones));
            }
            if (log.rahn_from != "")
            {
                long needed = Convert.ToInt64(log.rahn_from);
                q = q.Where(x => x.tabaghe_1_rahn >= needed || x.tabaghe_2_rahn >= needed || x.tabaghe_3_rahn >= needed);
            }
            if (log.rahn_to != "")
            {
                long needed = Convert.ToInt64(log.rahn_to);
                q = q.Where(x => x.tabaghe_1_rahn <= needed || x.tabaghe_2_rahn <= needed || x.tabaghe_3_rahn <= needed);
            }
            if (log.samt != "")
            {
                q = q.Where(x => x.samt == log.samt);
            }
            if (log.sell2khareji != "")
            {
                q = q.Where(x => x.sell2khareji == log.sell2khareji);
            }
            if (log.senn_from != "" && log.senn_to == "")
            {
                if (FUNS.IsDigitsOnly(log.senn_from))
                {
                    long needed = Convert.ToInt64(log.senn_from) - 2;
                    q = q.Where(x => x.senn >= needed || x.senn == 0);
                }

            }
            else if (log.senn_from == "" && log.senn_to != "")
            {
                if (FUNS.IsDigitsOnly(log.senn_to))
                {
                    long needed = Convert.ToInt64(log.senn_to) - 2;
                    q = q.Where(x => x.senn <= needed && x.senn != 1);
                }

            }
            else if (log.senn_from != "" && log.senn_to != "")
            {
                if (FUNS.IsDigitsOnly(log.senn_to) && FUNS.IsDigitsOnly(log.senn_from))
                {
                    long neededfrom = Convert.ToInt64(log.senn_from) - 2;
                    long neededto = Convert.ToInt64(log.senn_to) - 2;
                    q = q.Where(x => x.senn <= neededto && x.senn >= neededfrom);
                }

            }
            if (log.seraydar != "")
            {
                q = q.Where(x => x.seraydar == log.seraydar);
            }
            if (log.suit != "")
            {
                q = q.Where(x => x.suit == log.suit);
            }
            if (log.tabaghe != "")
            {
                if (FUNS.IsDigitsOnly(log.tabaghe))
                {
                    long needed = Convert.ToInt64(log.tabaghe_from);
                    q = q.Where(x => x.tabaghe1 == needed || x.tabaghe2 == needed || x.tabaghe3 == needed);

                }
            }
            if (log.tabaghe_from != "")
            {
                if (FUNS.IsDigitsOnly(log.tabaghe_from))
                {
                    long needed = Convert.ToInt64(log.tabaghe_from);
                    q = q.Where(x => x.total_floor >= needed);
                }

            }
            if (log.tabaghe_to != "")
            {
                if (FUNS.IsDigitsOnly(log.tabaghe_to))
                {
                    long needed = Convert.ToInt64(log.tabaghe_to);
                    q = q.Where(x => x.total_floor >= needed);
                }

            }
            if (log.takhlie != "")
            {
                q = q.Where(x => x.takhlie == log.takhlie);

            }
            if (log.tarakom != "")
            {
                q = q.Where(x => x.tarakom == log.tarakom);

            }
            if (log.title != "")
            {
                q = q.Where(x => x.title.Contains(log.title));

            }
            if (log.toole_bar != "")
            {
                q = q.Where(x => x.toole_bar == log.toole_bar);

            }
            if (log.total_price_from != "")
            {
                if (FUNS.IsDigitsOnly(log.total_price_from))
                {
                    long needed = Convert.ToInt64(log.total_price_from);
                    q = q.Where(x => x.tabaghe_1_total_price >= needed || x.tabaghe_2_total_price >= needed || x.tabaghe_3_total_price >= needed);

                }

            }
            if (log.total_price_to != "")
            {
                if (FUNS.IsDigitsOnly(log.total_price_to))
                {
                    long needed = Convert.ToInt64(log.total_price_to);
                    q = q.Where(x => x.tabaghe_1_total_price <= needed || x.tabaghe_2_total_price <= needed || x.tabaghe_3_total_price <= needed);

                }

            }
            if (log.total_vahed != "")
            {
                long needed = Convert.ToInt64(log.total_vahed);
                q = q.Where(x => x.total_vahed == needed);

            }
            if (log.villa != "" && log.villa != "0")
            {
                q = q.Where(x => x.villa == log.villa);
            }
            if (log.wc != "")
            {
                string srt = log.wc.Remove(0, 1).Remove(log.wc.Count() - 2, 1);
                List<string> list = srt.Split(',').ToList();
                if (list.Count() > 0)
                {
                    foreach (var item in list)
                    {
                        q = q.Where(x => x.wc.Contains(item + ","));

                    }
                }
            }
            if (log.zirbana_from != "")
            {
                if (FUNS.IsDigitsOnly(log.zirbana_from))
                {
                    long needed = Convert.ToInt64(log.zirbana_from);
                    q = q.Where(x => x.zirbana1 <= needed || x.zirbana2 <= needed || x.zirbana3 <= needed);

                }
            }
            if (log.zirbana_to != "")
            {
                if (FUNS.IsDigitsOnly(log.zirbana_to))
                {
                    long needed = Convert.ToInt64(log.zirbana_from);
                    q = q.Where(x => x.zirbana1 >= needed || x.zirbana2 >= needed || x.zirbana3 >= needed);

                }
            }
            if (log.zirzamin != "")
            {
                q = q.Where(x => x.zirzamin == log.zirzamin);
            }
            if (log.mantaghe_name != "")
            {
                string mnt = log.mantaghe_name.Substring(1, log.mantaghe_name.Length - 2);
                List<string> mantaghelst = mnt.Split(',').ToList();
                foreach (var mantaghe in mantaghelst)
                {

                    if (mantaghelst.IndexOf(mantaghe) == 0)
                    {
                        var first = q.Where(x => x.mantaghe_name == mantaghe);
                        final = first;
                    }
                    else
                    {
                        var seconde = q.Where(x => x.mantaghe_name == mantaghe);
                        final = final.Union(seconde);
                    }
                }

            }

            if (log.address1 != "")
            {
                final = q;
                List<string> add1List = null;
                add1List = log.address1.Split('-').ToList();
                if (log.address1.Contains("-"))
                {
                   
                    add1List.RemoveAt(add1List.Count - 1);

                }
                foreach (var add1 in add1List)
                {
                    if (add1List.IndexOf(add1) == 0)
                    {
                        var first = final.Where(x => x.address1 == add1);
                        final = first;
                        List<item> LIST = first.ToList();
                    }
                    else
                    {
                        var seconde = q.Where(x => x.address1 == add1);
                        final = final.Union(seconde);
                    }

                }
            }
            else
            {
                final = q;
            }
            if (log.address2.Replace("-","") != "")
            {
                List<string> add2List = null;
                add2List = log.address2.Split('-').ToList();
                if (log.address2.Contains("-"))
                {

                    add2List.RemoveAt(add2List.Count - 1);

                }
                foreach (var add2 in add2List)
                {
                    var seconde = q.Where(x => x.address2 == add2);
                    final = final.Union(seconde);

                }
            }

            //if (log.address2 != "")
            //{
            //    List<string> add2List = log.address2.Split('-').ToList();
            //    foreach (var add2 in add2List)
            //    {
            //        q = q.Where(x => x.address2.Contains(add2));
            //    }
            //}
            list = final.ToList();
            return list;
        }
        public item getitem(int id)
        {
            return context.items.Where(x => x.number == id).SingleOrDefault();
        }
        public void saveCats(string cates)
        {
            CatesAndAreas model = new CatesAndAreas();
            model.date = cates;
            var all = from c in context.catDatas select c;
            context.catDatas.RemoveRange(all);
            context.catDatas.Add(model);
            context.SaveChanges();
        }
        public string getCats()
        {
            string srt = "";
            try
            {
                srt = context.catDatas.First().date;
            }
            catch (Exception)
            {

            }
            return srt;
        }

    }
}

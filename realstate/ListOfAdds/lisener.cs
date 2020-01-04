using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using realstate.Classes;
namespace realstate
{
    class lisener
    {
        public queryModel queryModel { get; set; }
        public bool workercontinu { get; set; }
        public string loginDB { get; set; }
        public login loginmodel { get; set; }
        public Socket newsocket { get; set; }
        public byte[] b { get; set; }
        public int   RecievedByteCount { get; set; }
        public string  message { get; set; }
        public string  id { get; set; }
        public ListOfAdds.File datumselected { get; set; }
        public byte[] imagenum  { get; set; }

        public int imageNumberSent { get; set; }
        public string  imageurlForDownload { get; set; }
        public int counter { get; set; }

    }
    class queryModel
    {
        public queryModel()
           {
               relatedAddress = "";
               ID = "";
               title = "";
               isForoosh = "";
               isEjare = "";
               isRahn = "";
               isMosharekat = "";
               isMoaveze = "";
               hasEstakhr = "";
               hasSauna = "";
               hasJakoozi = "";
               sell2khareji = "";
               asansor = "";
               anbari = "";
               suit = "";
               maghaze = "";
               malek = "";
               mantaghe_name = "";
               mantaghe_id = "";
               address = "";
               address1 = "";
               address2 = "";
               address3 = "";
               samt = "";
               apartment = "";
               villa = "";
               mostaghellat = "";
               kolangi = "";
               office = "";
               seraydar = "";
              kaf_type= "";
            garmayesh_sarmayesh = "";
            total_floor = "";
            total_vahed = "";
            total_price_from = "";
            total_price_to = "";
            rahn_from = "";
            rahn_to = "";
            ejare_from = "";
            ejare_to = "";
            metri_from = "";
            metri_to = "";
            masahat_zamin = "";
            senn = "";
            ashpazkhane = "";
            tarakom = "";
            toole_bar = "";
            ertefa = "";
            eslahi = "";
            zirzamin = "";
            takhlie = "";
            desc = "";
            phones = "";
            wc = "";
            date_from = "";
            date_to = "";
            zirbana_from = "";
            zirbana_to = "";
            bed_from = "";
            bed_to = "";
            tabaghe_from= "";
            tabaghe_to = "";
            senn_from = "";
            senn_to = "";
            nama = "";
            masahat_from = "";
            masahat_to = "";
            id_from = "";
            id_to = "";
            hasGym = "";
            hasShooting = "";
            hasHall = "";
            hasSeraydar = "";
            hasRoofGarden = "";
            isMoble = "";
            tabaghe = "";
            parking = "";
            labi = "";
            kind = "";
            page = "1";
          

           }

        public  string page { get; set; }
        public string kind { get; set; }
        public string relatedAddress { get; set; }
        public string ID { get; set; }
        public string title { get; set; }
        public string isForoosh { get; set; }
        public string isEjare { get; set; }
        public string labi { get; set; }
        public string parking { get; set; }
        public string isRahn { get; set; }
        public string isMosharekat { get; set; }
        public string isMoaveze { get; set; }
        public string hasEstakhr { get; set; }
        public string hasSauna { get; set; }
        public string hasJakoozi { get; set; }
        public string sell2khareji { get; set; }
        public string asansor { get; set; }
        public string anbari { get; set; }
        public string maghaze { get; set; }
        public string suit { get; set; }

      
        public string malek { get; set; }
        public string mantaghe_name { get; set; }
        public string mantaghe_id { get; set; }
        public string address { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string samt { get; set; }
        public string apartment { get; set; }
        public string villa { get; set; }
        public string mostaghellat { get; set; }
        public string kolangi { get; set; }
        public string office { get; set; }
        public string seraydar { get; set; }
        public string kaf_type { get; set; }
        public string garmayesh_sarmayesh { get; set; }
        public string total_floor { get; set; }
        public string total_vahed { get; set; }

        public string total_price_from { get; set; }
        public string total_price_to { get; set; }
        public string rahn_from { get; set; }
        public string rahn_to { get; set; }
        public string ejare_from { get; set; }
        public string ejare_to { get; set; }
        public string metri_from { get; set; }
        public string metri_to { get; set; }
      
        public string masahat_zamin { get; set; }
        public string senn { get; set; }
        public string ashpazkhane { get; set; }
        public string tarakom { get; set; }
        public string toole_bar { get; set; }
        public string ertefa { get; set; }
        public string eslahi { get; set; }
        public string zirzamin { get; set; }
        public string takhlie { get; set; }
        public string desc { get; set; }


        public string phones { get; set; }
      
        public string wc { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
        public string zirbana_from { get; set; }
        public string zirbana_to { get; set; }
        public string bed_from { get; set; }
        public string bed_to { get; set; }
        public string tabaghe_from { get; set; }
        public string tabaghe_to { get; set; }
        public string senn_from { get; set; }
        public string senn_to { get; set; }
        public string nama { get; set; }
        public string masahat_from { get; set; }
        public string masahat_to { get; set; }
        public string id_from { get; set; }
        public string id_to { get; set; }
        public string hasGym { get; set; }
        public string hasShooting { get; set; }
        public string hasHall { get; set; }
        public string hasSeraydar { get; set; }
        public string hasRoofGarden { get; set; }
        public string isMoble { get; set; }
        public string tabaghe { get; set; }
        
       
     
       
       
    }
    class login 
    {
        public string  name { get; set; }
        public string port { get; set; }
        public string username { get; set; }
        public string  password { get; set; }
    }
    class loginback
    {
        public string status { get; set; }
        public string token { get; set; }
        public CatsAndAreasObject autocompleteObject { get; set; }
     
    }
    public class Apartment
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class GarmayeshSarmayesh
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class KafType
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Kolangi
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Mantaghe
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class MantagheId
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Mostaghellat
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Office
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Samt
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Senn
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Seraydar
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Villa
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Ashpazkhane
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Sanad
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class Behdashti
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string mantaghe_id { get; set; }
    }

    public class List
    {
        public List<Apartment> apartment { get; set; }
        public List<GarmayeshSarmayesh> garmayesh_sarmayesh { get; set; }
        public List<KafType> kaf_type { get; set; }
        public List<Kolangi> kolangi { get; set; }
        public List<Mantaghe> mantaghe { get; set; }
        public List<MantagheId> mantaghe_id { get; set; }
        public List<Mostaghellat> mostaghellat { get; set; }
        public List<Office> office { get; set; }
        public List<Samt> samt { get; set; }
        public List<Senn> senn { get; set; }
        public List<Seraydar> seraydar { get; set; }
        public List<Villa> villa { get; set; }
        public List<Ashpazkhane> ashpazkhane { get; set; }
        public List<Sanad> sanad { get; set; }
        public List<Behdashti> behdashti { get; set; }
    }

    public class Data
    {
        public List list { get; set; }
    }

    public class CatsAndAreasObject
    {
        public int status { get; set; }
        public Data data { get; set; }
        public bool show_dialog { get; set; }
        public string message { get; set; }
    }

    
}

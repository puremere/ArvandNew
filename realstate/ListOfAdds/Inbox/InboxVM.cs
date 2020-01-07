using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realstate.ListOfAdds.Inbox
{
    public class List
    {
        public string ID { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string to { get; set; }
        public string date { get; set; }
    }

    public class Data
    {
        public List<List> list { get; set; }
    }

   

    public class InboxVM
    {
        public int status { get; set; }
        public Data data { get; set; }
        public bool show_dialog { get; set; }
        public string message { get; set; }
    }
    
}

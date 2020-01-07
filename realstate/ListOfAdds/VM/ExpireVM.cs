using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realstate.VM
{
    public class Data
    {
        public string status { get; set; }
    }

    public class ExpireVM
    {

        public int status { get; set; }
        public Data data { get; set; }
        public bool show_dialog { get; set; }
        public string message { get; set; }
    }
   
}

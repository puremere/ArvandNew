using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace realstate.Classes
{
    public class Data
    {
        public bool is_valid { get; set; }
        public string expire_timestamp { get; set; }
        public string start_recieve_timestamp { get; set; }
        public string user_full_name { get; set; }
        public string valid_areas { get; set; }
        public string users_limit { get; set; }
    }
    class RegisterResponse
    {
        public int status { get; set; }
        public Data data { get; set; }
        public bool show_dialog { get; set; }
        public string message { get; set; }
    }
}

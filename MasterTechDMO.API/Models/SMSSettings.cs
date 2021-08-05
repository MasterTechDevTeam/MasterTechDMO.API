using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterTechDMO.API.Models
{
    public class SMSSettings
    {
        public string Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EndPoint { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace mtsDMO.Context.Utility
{
    public class SendSMSDataResponse
    {
        public string Phone
        {
            get; set;
        }
        public string Charge
        {
            get; set;
        }
        public string Message_id
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }
     }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace survey_core_ms_fulldotnet.Models
{
    public class EnterpriseEvent
    {
        public string role { get; set; }
        public string cmd { get; set; }
        public EventInfo eventinfo { get; set; }
    }

    public class EventInfo
    {
        public string eventid { get; set; }
        public string eventtype { get; set; }
        public string entitytype { get; set; }
        public string entityid { get; set; }
    }
}

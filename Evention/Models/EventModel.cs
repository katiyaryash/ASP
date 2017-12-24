using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Evention.Models
{
    public class EventModel
    {
        public string EName { get; set; }
        public string Category { get; set; }
        public string Feature { get; set; }
        public string Type { get; set; }
        public string ECategory { get; set; }
        public string Date { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Place { get; set; }
        public string Address { get; set; }
        public Decimal Lon { get; set; }
        public Decimal Lat { get; set; }
        public string Cost { get; set; }
        public string About { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
        public string ID { get; set; }
        public string BgImage { get; set; }
    }
    public class ViewEvents : EventModel
    {
        public ViewEvents()
        {
            lstEventCategory = new List<EventModel>();
            lstEventDetails = new List<EventModel>();
            lstAllEvents = new List<EventModel>();
        }
        public List<EventModel> lstEventCategory { get; set; }
        public List<EventModel> lstEventDetails { get; set; }
        public List<EventModel> lstAllEvents { get; set; }
    }
}
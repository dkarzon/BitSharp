using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Serializers;

namespace BITSharp.Models
{
    public class EventList : List<Event>
    {
    }

    [SerializeAs(Name = "event")]
    public class Event
    {
        public string ID { get; set; }
        public string Url { get; set; }

        [SerializeAs(Name = "datetime")]
        public DateTime StartDate { get; set; }

        [SerializeAs(Name = "ticket_url")]
        public string TicketUrl { get; set; }
        public string Status { get; set; }

        [SerializeAs(Name = "ticket_status")]
        public string TicketStatus { get; set; }

        [SerializeAs(Name = "on_sale_datetime")]
        public string OnSaleDate { get; set; }

        public List<Artist> Artists { get; set; }
        public Venue venue { get; set; }
    }
}

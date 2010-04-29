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

        public string Title
        {
            get
            {
                //TODO - Fix if No Artists or venue
                //return string.Format("{0} live in {1} {2}, {3}", Artists[0].Name, venue.City, venue.Region, venue.Country);
                return string.Format("{0} live in {1}", Artists[0].Name, venue.City);
            }
        }
    }
}

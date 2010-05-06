using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace BITSharp.Models
{
    public class VenueList : List<Venue>
    {
    }

    [DeserializeAs(Name = "venue")]
    public class Venue
    {
        public string ID { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
    }
}

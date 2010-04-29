using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Serializers;

namespace BITSharp.Models
{
    [SerializeAs(Name = "artist")]
    public class Artist
    {
        [SerializeAs(Name = "mbid")]
        public string MusicBrainzID { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
}

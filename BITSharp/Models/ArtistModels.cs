using RestSharp.Deserializers;

namespace BITSharp.Models
{
    [DeserializeAs(Name = "artist")]
    public class Artist
    {
        [DeserializeAs(Name = "mbid")]
        public string MusicBrainzID { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
    }
}

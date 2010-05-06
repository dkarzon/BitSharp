using RestSharp;
using RestSharp.Deserializers;

namespace BITSharp
{
    public partial class BitClient
    {
        private const string _baseUrl = "http://api.bandsintown.com";

        private string _apiKey;
        private RestClient _restClient;

        /// <summary>
        /// The number of requests that have been made by the current Client instance
        /// </summary>
        public int RequestCount { get; set; }
        /// <summary>
        /// The total Bytes returned from the requests made by the current Client instance
        /// </summary>
        public long DataCount { get; set; }

        /// <summary>
        /// Default Constructor for the BitClient
        /// </summary>
        /// <param name="apiKey">The Api Key to use for the BandsInTown Requests</param>
        public BitClient(string apiKey)
        {
            _apiKey = apiKey;
            _restClient = new RestClient(_baseUrl);
            _restClient.ClearHandlers();
            _restClient.AddHandler("application/xml", new XmlAttributeDeserializer());
            //probly not needed...
            RequestCount = 0;
            DataCount = 0;
        }

    }
}

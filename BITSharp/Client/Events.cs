using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using BITSharp.Exceptions;

namespace BITSharp
{
    public partial class BitClient
    {
        //This part of the class will handle the Events API requests

        /// <summary>
        /// Events/Search Request - Returns events matching search criteria (see below for available params). Useful in searching for local events or events within a specific time frame. (either artists or location is required)
        /// </summary>
        /// <param name="artists">A list or artist names or Musicbrainz ID's (mbid_[id])</param>
        /// <param name="location">A location option for searching {city,state (US or CA)} {city,country} {lat,lon} {ip address} {"use_geoip"}</param>
        /// <param name="radius">Radius around the location to search (Miles, Max 150) [Default: 25]</param>
        /// <param name="date">A date or date range to search [default: upcoming]</param> //TODO - Implement range
        /// <param name="page">The Page of results to get [Default: 1]</param>
        /// <param name="per_page">The number of items to get per page [Default: 50]</param>
        /// <returns>A list of Events</returns>
        public List<Models.Event> Events_Search(List<string> artists, string location, int? radius, DateTime? date, int? page, int? per_page)
        {
            //TODO - add some overloads for this funciton...?

            //Check parameter logic?
            if (artists == null && string.IsNullOrEmpty(location))
            {
                throw new NotSupportedException("Events_Search Requires either artists or location");
            }

            var request = new RestRequest();
            request.Resource = "events/search";

            request.AddParameter("app_id", _apiKey);
            request.AddParameter("format", "xml");
            if (artists != null)
            {
                foreach (string artist in artists)
                {
                    request.AddParameter("artists[]", artist);
                }
            }
            if (!string.IsNullOrEmpty(location))
            {
                request.AddParameter("location", location);
            }
            if (radius.HasValue)
            {
                request.AddParameter("radius", radius);
            }
            if (date.HasValue)
            {
                request.AddParameter("date", date.Value.ToString("yyyy-MM-dd"));
            }
            if (page.HasValue && page > 0)
            {
                request.AddParameter("page", page);
            }
            if (per_page.HasValue && per_page > 0)
            {
                request.AddParameter("per_page", per_page);
            }

            var response = _restClient.Execute<Models.BitResponse<Models.EventList>>(request);

            //Add to the data/requests
            RequestCount++;
            DataCount += response.RawBytes.Length;

            //TODO - Add error checking...?
            if (response.Data.Errors != null && response.Data.Errors.Count > 0)
            {
                throw new BitException(response.Data.Errors[0].Value);
            }

            return response.Data.Value;
        }

        /// <summary>
        /// Events/Daily request - Returns events that have been created, updated or deleted in the last day. Useful in syncing data with Bandsintown.
        /// The daily feed is updated each day at 12:00 PM EST.
        /// </summary>
        /// <returns>A list of Events</returns>
        public List<Models.Event> Events_Daily()
        {
            var request = new RestRequest();
            request.Resource = "events/daily";

            request.AddParameter("app_id", _apiKey);
            request.AddParameter("format", "xml");

            var response = _restClient.Execute<Models.BitResponse<Models.EventList>>(request);

            //Add to the data/requests
            RequestCount++;
            DataCount += response.RawBytes.Length;

            //TODO - Add error checking...?
            if (response.Data.Errors != null && response.Data.Errors.Count > 0)
            {
                throw new BitException(response.Data.Errors[0].Value);
            }

            return response.Data.Value;
        }

        /// <summary>
        /// Events/Recommended request - Returns recommended events given an artist or list of artists and a location
        /// </summary>
        /// <param name="artists">A list or artist names or Musicbrainz ID's (mbid_[id])</param>
        /// <param name="location">A location option for searching {city,state (US or CA)} {city,country} {lat,lon} {ip address} {"use_geoip"}</param>
        /// <param name="radius">Radius around the location to search (Miles, Max 150) [Default: 25]</param>
        /// <param name="date">A date or date range to search [default: upcoming]</param> //TODO - Implement range
        /// <param name="only_recs">Not too sure...?</param> //TODO - find out what this does
        /// <param name="page">The Page of results to get [Default: 1]</param>
        /// <param name="per_page">The number of items to get per page [Default: 50]</param>
        /// <returns></returns>
        public List<Models.Event> Events_Recommended(List<string> artists, string location, int? radius, DateTime? date, bool? only_recs, int? page, int? per_page)
        {
            //TODO - add some overloads for this funciton...?

            //Check parameter logic?
            if (artists == null && string.IsNullOrEmpty(location))
            {
                throw new NotSupportedException("Events_Search Requires either artists or location");
            }

            var request = new RestRequest();
            request.Resource = "events/recommended";

            request.AddParameter("app_id", _apiKey);
            request.AddParameter("format", "xml");
            if (artists != null)
            {
                foreach (string artist in artists)
                {
                    request.AddParameter("artists[]", artist);
                }
            }
            if (!string.IsNullOrEmpty(location))
            {
                request.AddParameter("location", location);
            }
            if (radius.HasValue)
            {
                request.AddParameter("radius", radius);
            }
            if (date.HasValue)
            {
                request.AddParameter("date", date.Value.ToString("yyyy-MM-dd"));
            }
            if (only_recs.HasValue)
            {
                request.AddParameter("only_recs", only_recs.Value ? "true" : "false");
            }
            if (page.HasValue && page > 0)
            {
                request.AddParameter("page", page);
            }
            if (per_page.HasValue && per_page > 0)
            {
                request.AddParameter("per_page", per_page);
            }

            var response = _restClient.Execute<Models.BitResponse<Models.EventList>>(request);

            //Add to the data/requests
            RequestCount++;
            DataCount += response.RawBytes.Length;

            //TODO - Add error checking...?
            if (response.Data.Errors != null && response.Data.Errors.Count > 0)
            {
                throw new BitException(response.Data.Errors[0].Value);
            }

            return response.Data.Value;
        }
    }
}

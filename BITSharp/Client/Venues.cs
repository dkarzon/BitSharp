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
        //This part of the class will handle the Venues API requests


        /// <summary>
        /// Venues/Search request - Returns venues matching a search query (supports location filtering).
        /// </summary>
        /// <param name="query">Search terms</param>
        /// <param name="location">A location option for searching {city,state (US or CA)} {city,country} {lat,lon} {ip address} {"use_geoip"}</param>
        /// <param name="radius">Radius around the location to search (Miles, Max 150) [Default: 25]</param>
        /// <param name="page">The Page of results to get [Default: 1]</param>
        /// <param name="per_page">The number of items to get per page [Default: 50]</param>
        /// <returns>A list of Venues</returns>
        public List<Models.Venue> Venues_Search(string query, string location, int? radius, int? page, int? per_page)
        {
            //Check parameter logic? (error checking, urlencode etc.)
            if (string.IsNullOrEmpty(query))
            {
                throw new NotSupportedException("Venues_Search Requires query parameter.");
            }

            var request = new RestRequest();
            request.Resource = "venues/search";

            request.AddParameter("app_id", _apiKey);
            request.AddParameter("format", "xml");
            request.AddParameter("query", query);
            if (!string.IsNullOrEmpty(location))
            {
                request.AddParameter("location", location);
            }
            if (radius.HasValue)
            {
                request.AddParameter("radius", radius);
            }
            if (page.HasValue && page > 0)
            {
                request.AddParameter("page", page);
            }
            if (per_page.HasValue && per_page > 0)
            {
                request.AddParameter("per_page", per_page);
            }

            var response = _restClient.Execute<Models.BitResponse<Models.VenueList>>(request);

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
        /// Venues/Events request - Returns all upcoming events for a single venue.
        /// </summary>
        /// <param name="venueID">The ID of the Venue to get events for</param>
        /// <returns>A list of Events</returns>
        public List<Models.Event> Venues_Events(int venueID)
        {
            //Check parameter logic? (error checking, urlencode etc.)

            var request = new RestRequest();
            request.Resource = string.Format("venues/{0}/events", venueID);

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

    }
}

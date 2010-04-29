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
        //This part of the class will handle the Artists API requests

        /// <summary>
        /// Artists/Events request - Returns all upcoming events for a single artist.
        /// </summary>
        /// <param name="musicBrainzID">The MusicBrainzID of the artist to get events for</param>
        /// <returns>A list of Events</returns>
        public List<Models.Event> Artists_Events(string musicBrainzID)
        {
            //TODO - Implement Artist name search as well

            //Check parameter logic? (error checking, urlencode etc.)

            var request = new RestRequest();
            request.Resource = string.Format("artists/{0}/events", musicBrainzID);

            request.AddParameter("app_id", _apiKey);
            request.AddParameter("format", "xml");

            var response = _restClient.Execute < Models.BitResponse<Models.EventList>>(request);

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
        /// Artists/Get request - Returns basic information for a single artist, including the number of upcoming events.
        /// </summary>
        /// <param name="musicBrainzID">The MusicBrainzID of the Artist to get info for</param>
        /// <returns></returns>
        public Models.Artist Artists_Get(string musicBrainzID)
        {
            //TODO - Implement Artist name search as well (dont really need it at yet)

            //Check parameter logic? (error checking, urlencode etc.)

            musicBrainzID = musicBrainzID.ToLower();
            musicBrainzID = musicBrainzID.StartsWith("mbid_") ? musicBrainzID : "mbid_" + musicBrainzID;

            var request = new RestRequest();
            request.Resource = string.Format("artists/{0}", musicBrainzID);

            request.AddParameter("app_id", _apiKey);
            request.AddParameter("format", "xml");

            var response = _restClient.Execute<Models.BitResponse<Models.Artist>>(request);

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

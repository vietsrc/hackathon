using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RCBot.Helpers.DTO.LineUp;
using Newtonsoft.Json;
using System.Net;

namespace RCBot.Helpers
{
    public class RcHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineUpID"></param>
        /// <returns></returns>
        public static LineUp GetLineUp(int lineUpID)
        {
            LineUp toReturn = null;

            string url = string.Format("http://services.radio-canada.ca/neuro/v1/future/lineups/{0}", lineUpID);
            using (WebClient client = new WebClient())
            {
                // Set le type d'encodage
                client.Encoding = System.Text.Encoding.UTF8;
                // Telecharge le json
                string json = client.DownloadString(new Uri(url));
                // Converti le json en format type
                toReturn = JsonConvert.DeserializeObject<LineUp>(json);
            }

            return toReturn;
        }
    }
}
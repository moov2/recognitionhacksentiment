using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace RecognitionHackSentiment.Twitter {
    public class TweetProvider {

        #region PublicMethods

        /// <summary>
        /// Fetches tweets that match the provid
        /// </summary>
        public IList<Tweet> Search(string query, string lastStatus) {
            var b64Bearer = Convert.ToBase64String(Encoding.Default.GetBytes(HttpContext.Current.Server.UrlEncode(ConfigurationManager.AppSettings["TwitterConsumerKey"]) + ":" + HttpContext.Current.Server.UrlEncode(ConfigurationManager.AppSettings["TwitterConsumerSecret"])));
            var response = string.Empty;

            if (lastStatus == null)
                lastStatus = string.Empty;

            using (var wc = new WebClient()) {
                wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
                wc.Headers.Add("Authorization", "Basic " + b64Bearer);
                var tokenPayload = wc.UploadString("https://api.twitter.com/oauth2/token", "grant_type=client_credentials");
                var rgx = new Regex("\"access_token\"\\s*:\\s*\"([^\"]*)\"");
                // you can store this accessToken and just do the next bit if you want
                var accessToken = rgx.Match(tokenPayload).Groups[1].Value;
                wc.Headers.Clear();
                wc.Headers.Add("Authorization", "Bearer " + accessToken);

                response = wc.DownloadString(string.Format("https://api.twitter.com/1.1/search/tweets.json?q={0}&count=100&since_id={1}", query, lastStatus));
            }
            
            return JsonConvert.DeserializeObject<TwitterStatuses>(response).Statuses;
        }

        #endregion

        #region PrivateClasses

        private class TwitterStatuses {
            [JsonProperty("statuses")]
            public IList<Tweet> Statuses { get; set; }
        }

        #endregion

    }
}
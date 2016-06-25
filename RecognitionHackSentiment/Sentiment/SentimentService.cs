using Newtonsoft.Json;
using RecognitionHackSentiment.Sentiment;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace RecognitionHackSentiment.Services {
    public class SentimentService {
        #region Constants

        private const string SentimentApiUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";

        #endregion

        #region PublicMethods

        public IList<SentimentDto> Get(string content) {
            var request = (HttpWebRequest)WebRequest.Create(SentimentApiUrl);
            request.AllowAutoRedirect = false;
            request.Proxy = null;
            request.Method = "POST";
            request.Headers.Add("Ocp-Apim-Subscription-Key", ConfigurationManager.AppSettings["TextApiKey"]);

            var sentimentDocuments = new Dictionary<string, IList<SentimentRequestDto>>();
            sentimentDocuments.Add("documents", new List<SentimentRequestDto> { new SentimentRequestDto { Id = "a", Text = content } });

            var json = JsonConvert.SerializeObject(sentimentDocuments);

            byte[] body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(sentimentDocuments));
            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.ContentLength = body.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(body, 0, body.Length);
            requestStream.Close();

            var response = (HttpWebResponse)request.GetResponse();
            string rawResponse = string.Empty;

            using (var reader = new StreamReader(response.GetResponseStream())) {
                rawResponse = reader.ReadToEnd();
            }

            response.Close();
            return JsonConvert.DeserializeObject<Dictionary<string, IList<SentimentDto>>>(rawResponse)["documents"];
        }

        #endregion
    }
}
using Newtonsoft.Json;

namespace RecognitionHackSentiment.Sentiment {
    public class SentimentDto {

        #region PublicProperties

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("score")]
        public float Score { get; set; }

        #endregion

    }
}
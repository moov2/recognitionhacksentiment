using Newtonsoft.Json;

namespace RecognitionHackSentiment.Sentiment {
    public class SentimentRequestDto {
        #region Constants

        private const string DefaultLanguage = "en";

        #endregion

        #region PublicProperties

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        #endregion

        #region Constructor

        public SentimentRequestDto() {
            Language = DefaultLanguage;
        }

        #endregion
    }
}
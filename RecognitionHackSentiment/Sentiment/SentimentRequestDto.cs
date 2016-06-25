using Newtonsoft.Json;
using RecognitionHackSentiment.Twitter;
using System.Collections.Generic;
using System.Linq;

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

        #region StaticMethods

        /// <summary>
        /// Creates sentiments from each tweet.
        /// </summary>
        public static IList<SentimentRequestDto> CreateFromTweets(IList<Tweet> tweets) {
            return tweets.Select(x => new SentimentRequestDto {
                Id = x.StatusId,
                Text = x.Text
            }).ToList();
        }

        #endregion
    }
}
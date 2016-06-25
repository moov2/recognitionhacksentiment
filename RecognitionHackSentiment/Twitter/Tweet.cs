using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RecognitionHackSentiment.Twitter {
    public class Tweet {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("id_str")]
        public string StatusId { get; set; }

        [JsonProperty("user")]
        public TwitterUser User { get; set; }

        [JsonProperty("entities")]
        public TweetEntities Entities { get; set; }
    }

    public class TwitterUser {
        [JsonProperty("id_str")]
        public string Id { get; set; }

        [JsonProperty("screen_name")]
        public string ScreenName { get; set; }
    }

    public class TweetEntities {
        [JsonProperty("hashtags")]
        public IList<TweetHashtag> Hashtags { get; set; }

        [JsonProperty("media")]
        public IList<TweetMedia> Media { get; set; }

        [JsonProperty("user_mentions")]
        public IList<TwitterUser> UserMentions { get; set; }
    }

    public class TweetHashtag {
        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class TweetMedia {
        [JsonProperty("media_url_https")]
        public string MediaUrl { get; set; }
    }
}
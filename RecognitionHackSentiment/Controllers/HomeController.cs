using RecognitionHackSentiment.Sentiment;
using RecognitionHackSentiment.Services;
using RecognitionHackSentiment.Twitter;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Mvc;

namespace RecognitionHackSentiment.Controllers {
    public class HomeController : Controller {

        #region StaticProperties

        private static MemoryCache _cache = new MemoryCache("SentimentCache");

        #endregion

        #region PrivateProperties

        private float _sentimentScore;
        private int _tweetCount;
        private string _lastStatus;

        #endregion

        #region Actions

        public ActionResult Index() {
            GetCache();

            // get tweets from twitter using hashtag.
            var tweets = new TweetProvider().Search("%23recognitionhack OR %23RecognitionHack -filter:retweets", _lastStatus);

            if (tweets.Count > 0) {
                // get sentiment scores for the tweets.
                var sentiments = new SentimentService().Get(SentimentRequestDto.CreateFromTweets(tweets));

                // get the average of all the scores
                _sentimentScore = (_sentimentScore == 0) ? sentiments.Select(x => x.Score).ToList().Average() : ((_sentimentScore * _tweetCount) + sentiments.Select(x => x.Score).ToList().Average()) / (tweets.Count + _tweetCount);

                _tweetCount = _tweetCount == 0 ? tweets.Count : tweets.Count + _tweetCount;

                SetCache(_sentimentScore, _tweetCount, tweets.First().StatusId);
            }

            return View(_sentimentScore);
        }

        #endregion

        #region PrivateMethods

        private void GetCache() {
            _lastStatus = (string)_cache.Get("LastStatus");

            if (_cache.Get("TweetCount") != null)
                _tweetCount = int.Parse(_cache.Get("TweetCount").ToString());

            if (_cache.Get("SentimentScore") != null)
                _sentimentScore = float.Parse(_cache.Get("SentimentScore").ToString());
        }

        private void SetCache(float sentimentScore, int tweetCount, string lastStatusId) {
            _cache.Set("SentimentScore", sentimentScore, new CacheItemPolicy());
            _cache.Set("TweetCount", tweetCount, new CacheItemPolicy());
            _cache.Set("LastStatus", lastStatusId, new CacheItemPolicy());
        }

        #endregion

    }
}
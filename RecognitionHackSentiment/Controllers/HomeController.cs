using RecognitionHackSentiment.Sentiment;
using RecognitionHackSentiment.Services;
using RecognitionHackSentiment.Twitter;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace RecognitionHackSentiment.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            // get tweets from twitter using hashtag.
            var tweets = new TweetProvider().Search("%23recognitionhack OR %23RecognitionHack -filter:retweets");

            foreach (var tweet in tweets) {
                Debug.WriteLine(tweet.Text);
            }

            // get sentiment scores for the tweets.
            var sentiments = new SentimentService().Get(SentimentRequestDto.CreateFromTweets(tweets));

            // get the average of all the scores
            var sentimentScores = sentiments.Select(x => x.Score).ToList().Average();

            return View(sentimentScores);
        }
    }
}
using RecognitionHackSentiment.Services;
using System.Web.Mvc;

namespace RecognitionHackSentiment.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            var sentimentService = new SentimentService();
            var sentiments = sentimentService.Get("Having fun at #RecognitionHack with @Moov2");
            return View();
        }
    }
}
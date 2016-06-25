using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecognitionHackSentiment.Startup))]
namespace RecognitionHackSentiment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}

using System.Linq;
using TweetPull;
using Xunit;

namespace MultiMicroServicesUnitTests
{
	public class TwitterTests
    {
        [Fact]
        public void TestEnvironmentVariables()
        {
            DotNetEnv.Env.Load();
            Assert.False(string.IsNullOrWhiteSpace(HelperMethods.GetEnvironmentVariable<string>("twitterconsumerpublic")));
            Assert.False(string.IsNullOrWhiteSpace(HelperMethods.GetEnvironmentVariable<string>("twitterconsumerprivate")));
            Assert.False(string.IsNullOrWhiteSpace(HelperMethods.GetEnvironmentVariable<string>("twitteraccesstoken")));
            Assert.False(string.IsNullOrWhiteSpace(HelperMethods.GetEnvironmentVariable<string>("twitteraccesssecret")));
        }

        [Fact]
        public void GetLatestTweets()
        {
            DotNetEnv.Env.Load();
            ITweetReader tweetReader = new TweetReader(
                HelperMethods.GetEnvironmentVariable<string>("twitterconsumerpublic"),
                HelperMethods.GetEnvironmentVariable<string>("twitterconsumerprivate"),
                HelperMethods.GetEnvironmentVariable<string>("twitteraccesstoken"),
                HelperMethods.GetEnvironmentVariable<string>("twitteraccesssecret"));

            var tweets = tweetReader.GetLatestTweets("jbschwi", 10);
            
            Assert.True(tweets.Any());
        }
	}
}

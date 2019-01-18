using System;
using System.Threading.Tasks;
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
            Assert.False(string.IsNullOrWhiteSpace("twitterconsumerpublic"));
            Assert.False(string.IsNullOrWhiteSpace("twitterconsumerprivate"));
            Assert.False(string.IsNullOrWhiteSpace("twitteraccesstoken"));
            Assert.False(string.IsNullOrWhiteSpace("twitteraccesssecret"));
        }

        [Fact]
        public void TestHasRateLimit()
        {
            DotNetEnv.Env.Load();
            ITweetReader tweetReader = new TweetReader();
            var rateLimit = tweetReader.GetCurrentRateLimit().Result;
            Assert.NotNull(rateLimit);
        }
    }
}

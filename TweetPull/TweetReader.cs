using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TweetPull;
using TweetSharp;

namespace TweetPull
{
    public class TweetReader : ITweetReader
    {
        private readonly TwitterKeys _twitterKeys;
        private TwitterService _twitterService;
        private OAuthRequestToken _oAuthRequestToken;

        public TweetReader()
        {
            _twitterKeys = new TwitterKeys();
            InitTwitter();
        }

        /// <summary>
        /// Keys are the environment variable names
        /// </summary>
        /// <param name="consumerPublicKey"></param>
        /// <param name="consumerSecretKey"></param>
        /// <param name="accessTokenKey"></param>
        /// <param name="accessSecretKey"></param>
        public TweetReader(string consumerPublicKey, string consumerSecretKey, string accessTokenKey, string accessSecretKey)
        {
            _twitterKeys = new TwitterKeys(consumerPublicKey, consumerSecretKey, accessTokenKey, accessSecretKey);
            InitTwitter();
        }
        
        private void InitTwitter()
        {
            _twitterService = new TwitterService(_twitterKeys.ConsumerPublic, _twitterKeys.ConsumerSecret);
            _twitterService.AuthenticateWith(_twitterKeys.AccessToken, _twitterKeys.AccessSecret);
        }

        public async Task<TwitterAsyncResult<IEnumerable<TwitterStatus>>> GetTweets(string screenName, bool includeRetweets, bool includeReplies)
        {
            return await _twitterService.ListTweetsOnUserTimelineAsync(new ListTweetsOnUserTimelineOptions {ScreenName = screenName, IncludeRts = includeRetweets, ExcludeReplies = !includeReplies});
        }

        public async Task<TwitterAsyncResult<TwitterRateLimitStatusSummary>> GetCurrentRateLimit()
        {
            return await _twitterService.GetRateLimitStatusAsync(new GetRateLimitStatusOptions());
        }
    }
}

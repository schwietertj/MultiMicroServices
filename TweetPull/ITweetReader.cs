using System.Collections.Generic;
using System.Threading.Tasks;
using TweetSharp;

namespace TweetPull
{
    public interface ITweetReader
    {
        Task<TwitterAsyncResult<TwitterRateLimitStatusSummary>> GetCurrentRateLimit();
        Task<TwitterAsyncResult<IEnumerable<TwitterStatus>>> GetTweets(string screenName, bool includeRetweets, bool includeReplies);
    }
}

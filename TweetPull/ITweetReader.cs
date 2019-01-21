using System.Collections.Generic;
using Tweetinvi.Models;

namespace TweetPull
{
    public interface ITweetReader
    {
        List<ITweet> GetAllUserTweets(string userHandle);
        List<ITweet> GetLatestTweets(string userHandle, int maxTweets = 200);
    }
}

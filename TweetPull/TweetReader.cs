using System;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace TweetPull
{
    public class TweetReader : ITweetReader
    {
        private static string _consumerPublic;
        private static string _consumerSecret;
        private static string _accessToken;
        private static string _accessSecret;

        /// <summary>
        /// Keys are the environment variable names
        /// </summary>
        /// <param name="consumerPublic"></param>
        /// <param name="consumerSecret"></param>
        /// <param name="accessToken"></param>
        /// <param name="accessSecret"></param>
        public TweetReader(string consumerPublic, string consumerSecret, string accessToken, string accessSecret)
        {
            _consumerPublic = consumerPublic;
            _consumerSecret = consumerSecret;
            _accessSecret = accessSecret;
            _accessToken = accessToken;
        }

        /// <summary>
        /// Get the latest number of tweets. A max of 200 can be pulled.
        /// </summary>
        /// <param name="userHandle"></param>
        /// <param name="maxTweets"></param>
        /// <returns></returns>
        public List<ITweet> GetLatestTweets(string userHandle, int maxTweets = 200)
        {
            // Set Auth
            Auth.SetUserCredentials(_consumerPublic, _consumerSecret, _accessToken, _accessSecret);
            RateLimit.QueryAwaitingForRateLimit += (sender, args) =>
            {
                Console.WriteLine($"Query : {args.Query} is awaiting for rate limits!");
            };

            return Timeline.GetUserTimeline(userHandle, maxTweets > 200 ? 200 : maxTweets).ToList();
        }

        public List<ITweet> GetAllUserTweets(string userHandle)
        {
            // Set Auth
            Auth.SetUserCredentials(_consumerPublic, _consumerSecret, _accessToken, _accessSecret);

            RateLimit.RateLimitTrackerMode = RateLimitTrackerMode.TrackAndAwait;

            RateLimit.QueryAwaitingForRateLimit += (sender, args) =>
            {
                Console.WriteLine($"Query : {args.Query} is awaiting for rate limits!");
            };

            var lastTweets = Timeline.GetUserTimeline(userHandle, 200).ToArray();

            var allTweets = new List<ITweet>(lastTweets);

            while (lastTweets.Length > 0 && allTweets.Count <= 3200)
            {
                var idOfOldestTweet = lastTweets.Select(x => x.Id).Min();
                Console.WriteLine($"Oldest Tweet Id = {idOfOldestTweet}");

                var numberOfTweetsToRetrieve = allTweets.Count > 3000 ? 3200 - allTweets.Count : 200;
                var timelineRequestParameters = new UserTimelineParameters
                {
                    // MaxId ensures that we only get tweets that have been posted 
                    // BEFORE the oldest tweet we received
                    MaxId = idOfOldestTweet - 1,
                    MaximumNumberOfTweetsToRetrieve = numberOfTweetsToRetrieve
                };

                lastTweets = Timeline.GetUserTimeline(userHandle, timelineRequestParameters).ToArray();
                allTweets.AddRange(lastTweets);
            }

            return allTweets;
        }
    }
}

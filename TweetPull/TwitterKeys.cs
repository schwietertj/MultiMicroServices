namespace TweetPull
{
    internal class TwitterKeys
    {
        private readonly string _consumerPublicKey = "twitterconsumerpublic";
        private readonly string _consumerSecretKey = "twitterconsumerprivate";
        private readonly string _accessTokenKey = "twitteraccesstoken";
        private readonly string _accessSecretKey = "twitteraccesssecret";

        public string ConsumerPublic => HelperMethods.GetEnvironmentVariable<string>(_consumerPublicKey);
        public string ConsumerSecret => HelperMethods.GetEnvironmentVariable<string>(_consumerSecretKey);
        public string AccessToken => HelperMethods.GetEnvironmentVariable<string>(_accessTokenKey);
        public string AccessSecret => HelperMethods.GetEnvironmentVariable<string>(_accessSecretKey);

        public TwitterKeys()
        {

        }

        public TwitterKeys(string consumerPublicKey, string consumerSecretKey, string accessTokenKey, string accessSecretKey)
        {
            _consumerPublicKey = consumerPublicKey;
            _consumerSecretKey = consumerSecretKey;
            _accessTokenKey = accessTokenKey;
            _accessSecretKey = accessSecretKey;
        }
    }
}

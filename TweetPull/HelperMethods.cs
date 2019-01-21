using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MultiMicroServicesUnitTests")]
namespace TweetPull
{
    public class HelperMethods
    {
        public static T GetEnvironmentVariable<T>(string variableName)
        {
            if (Environment.GetEnvironmentVariable(variableName) is null)
            {
                throw new Exception($"The environment variable '{variableName}' was not found.");
            }

            if (string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(variableName)))
            {
                return default(T);
            }

            try
            {
                return (T)Convert.ChangeType(Environment.GetEnvironmentVariable(variableName), typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

    }
}

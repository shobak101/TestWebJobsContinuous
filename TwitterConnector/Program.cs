using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using System.Configuration;

namespace TwitterConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up your credentials (https://apps.twitter.com)
            Auth.SetUserCredentials(Environment.GetEnvironmentVariable("CONSUMER_KEY"), Environment.GetEnvironmentVariable("CONSUMER_SECRET"),
                                    Environment.GetEnvironmentVariable("ACCESS_TOKEN"), Environment.GetEnvironmentVariable("ACCESS_TOKEN_SECRET"));

            // Publish the Tweet "Hello World" on your Timeline
            //Tweet.PublishTweet("Hello World!");

            var stream = Tweetinvi.Stream.CreateFilteredStream();

            var keyWordString = File.ReadAllText("KeyWords.txt");
            var keyWords = keyWordString.Split(',');

            foreach (var word in keyWords)
            {
                stream.AddTrack(word);
            }
            if (!File.Exists("out.txt"))
            {
                File.Create("out.txt");
            }
            var outputFile = new StreamWriter("out.txt", true);
            stream.MatchingTweetReceived += (sender, arguments) =>
            {
                string message = "A tweet containing '" + arguments.MatchingTracks[0] + "' has been found; the tweet is '" + arguments.Tweet + "' created by " + arguments.Tweet.CreatedBy;
                outputFile.WriteLine(message);
                outputFile.Flush();
                Console.WriteLine(message);
            };
            stream.StartStreamMatchingAllConditions();
        }
    }
}

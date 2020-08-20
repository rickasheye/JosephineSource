using JosephineCore;
using Octokit;
using System;
using System.Text.RegularExpressions;

namespace ChatBotProject
{
    public class Updater
    {
        private GitHubClient client;

        //More like a self patcher!
        public Updater()
        {
            //The basic update client
            Console.WriteLine("Checking for updates!");
            try
            {
                //If the client is null make a new client
                if (client == null)
                {
                    //Provide the client with acess
                    client = new GitHubClient(new ProductHeaderValue("JosephineSource"));
                }

                //Get it started
                var releases = client.Repository.Release.GetAll("rickasheye", "JosephineSource");
                var latest = releases.GetAwaiter().GetResult()[0];

                //If the release is not null
                if (latest != null)
                {
                    //If the release greater than the one shown
                    //Convert the build number to integer to compare
                    string storedBuild = Program.BUILDID.Replace("B", "");
                    storedBuild = storedBuild.Replace("A", "");
                    float converted = float.Parse(storedBuild);

                    //Now convert the build number in the name of the release
                    string convertedname = Regex.Replace(latest.Name, "[^0-9.]", "");
                    float parsedName = float.Parse(convertedname);

                    if (converted < parsedName)
                    {
                        //if the release is debug or release download specifics. Need to refine this as this will check if the latest is DEBUG or RELEASE
                        if (latest.TagName == "DEBUG" && Program.debugMode == true)
                        {
                            //Download the debug branch
                            Console.WriteLine("Found update debug!");
                        }
                        else if (latest.TagName == "RELEASE" && Program.debugMode == false)
                        {
                            //Download the latest branch!
                            Console.WriteLine("Found update release!");
                        }
                    }
                    else
                    {
                        Debug.Log("You already have a higher version installed!");
                    }
                }
                else
                {
                    //If the latest is null then there is no updates avaliable!
                    Console.WriteLine("No known updates avaliable!");
                }
            }
            catch (Exception e)
            {
                Debug.Log("Updater failed!");
                Debug.Log("Error: " + e);
            }
        }
    }
}
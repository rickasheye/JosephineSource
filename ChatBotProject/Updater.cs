using System;

namespace ChatBotProject
{
    public class Updater
    {
        //More like a self patcher!
        public Updater()
        {
            Console.WriteLine("Checking for updates updater not enabled!");
            //var client = new GitHubClient(new ProductHeaderValue("JosephineSource"));
            //client.Git.Commit.Get()
            //Check for updates on whenever the current repo is in state.
            /*var repoType = JosephineBot.debugMode;
            var githubToken = "";
            var devBranchURL = "https://github.com/rickasheye/JosephineSource/archive/devbranch.zip";
            var masterBranchURL = "https://github.com/rickasheye/JosephineSource/archive/master.zip";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "downloadbuild.zip");

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using (var client = new System.Net.Http.HttpClient())
            {
                var credentials = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0}:", githubToken);
                credentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(credentials));
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", credentials);
                var contents = client.GetByteArrayAsync(devBranchURL).Result;
                if(repoType == false) { Console.WriteLine("Not in debug mode downloading release build!"); contents = client.GetByteArrayAsync(masterBranchURL).Result; }
                Console.WriteLine("Downloaded build");
                File.WriteAllBytes(path, contents);
            }

            if (File.Exists(path))
            {
                //File has downloaded successfully!
                //Unzip and check the build string if not correct delete the build and save it!
            }*/
        }
    }
}

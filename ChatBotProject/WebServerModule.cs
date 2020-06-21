using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotProject
{
    public class WebServerModule : Module
    {
        //Create a link based on where it should be on the webserver or give a post request to the server to create or fill in a webpage!
        public WebServerModule(IReadOnlyCollection<string> prefixes, Func<HttpListenerRequest>):base("Web Server")
        {
            //Load the web server module into here!
            Debug.Log("Made contact with the Web Server Module!");
            Start();
        }

        public void Start()
        {
            //Start the module!

        }
    }
}

using System;

namespace MyWebServer
{
    using MyWebServer.Server;
    using MyWebServer.Server.Results;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        => await new HttpServer(
            routes => routes
            .GetMap("/", new TextResponse("Hello from Georgi! :)"))
            .GetMap("/Cats", new TextResponse("<h1>Meayy from the cat</h1>", "text/html"))
            .GetMap("/Dogs", new TextResponse("<h1>Bay from the dog</h1>", "text/html")))
            .Start();
        
    }
}

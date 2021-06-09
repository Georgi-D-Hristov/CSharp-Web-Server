namespace MyWebServer
{
    using System.Threading.Tasks;

    using MyWebServer.Server;
    using MyWebServer.Server.Results;

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

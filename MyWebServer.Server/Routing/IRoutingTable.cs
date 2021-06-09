namespace MyWebServer.Server.Routing
{
    using MyWebServer.Server.Http;

    public interface IRoutingTable
    {
        IRoutingTable Map(string url, HttpRequestMethod method, HttpResponse response);

        IRoutingTable GetMap(string url, HttpResponse response);
    }
}

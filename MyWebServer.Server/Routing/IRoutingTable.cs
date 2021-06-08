using MyWebServer.Server.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Routing
{
    public interface IRoutingTable
    {
     

        IRoutingTable Map(string url, HttpRequestMethod method, HttpResponse response);

        IRoutingTable GetMap(string url, HttpResponse response);

    }
}

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
        void Map(string url, HttpResponse respone);

        void Map(string url, HttpRequestMethod method, HttpResponse response);

        void GetMap(string url, HttpResponse response);

    }
}

﻿using System;

namespace MyWebServer
{
    using MyWebServer.Server;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        public static async Task Main()
        => await new HttpServer(
            "127.0.0.1",
            9090,
            routes => routes.)
            .Start();
        }
    }
}

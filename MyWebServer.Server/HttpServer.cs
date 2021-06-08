using MyWebServer.Server.Http;
using MyWebServer.Server.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly TcpListener listener;
        private readonly int port;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTable)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);
            this.port = port;

            listener = new TcpListener(this.ipAddress, this.port);
        }
        public HttpServer(int port, Action<IRoutingTable> routingTable) :this("127.0.0.1", port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            :this(9090, routingTable)
        {

        }

        public async Task Start()
        {

            this.listener.Start();

            Console.WriteLine($"Server started on port {port}...");
            Console.WriteLine("Listening for requests...");

            do
            {

                var connection = await this.listener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();

                var requestText = await ReadRequest(networkStream);

                Console.WriteLine(requestText);

                //var request = HttpRequest.Parse(requestText);

                await WriteResponse(networkStream);

                connection.Close();

            } while (true);


        }

        private static async Task WriteResponse(NetworkStream networkStream)
        {
            var content = @"
<html>
    <head>
    </head>
    <body>
        <h2> Hello from my server! </h2>
    </body>
</html>";
            var contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1 200 OK
Server: My Web Server
Date: {DateTime.UtcNow:r}
Content-Length: {contentLength}
Content-Type: text/html; charset=utf-8

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            await networkStream.WriteAsync(responseBytes);
        }

        private static async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalByts = 0;

            var requestBuilder = new StringBuilder();

            while (networkStream.DataAvailable)
            {
                var byteRead = await networkStream.ReadAsync(buffer.AsMemory(0, bufferLength));

                totalByts += byteRead;

                if (totalByts>10*1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, byteRead));
            }

            return requestBuilder.ToString();
        }
    }
}

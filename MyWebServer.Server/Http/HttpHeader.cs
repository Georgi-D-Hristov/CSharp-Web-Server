using MyWebServer.Server.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Http
{
    public class HttpHeader
    {
        public HttpHeader(string name, string value)
        {
            Gard.AgainstNull(name, nameof(name));
            Gard.AgainstNull(value, nameof(value));
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; init; }

        public string Value { get; init; }
    }
}

using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer.Server.Results
{
    public class TextResponse : HttpResponse
    {
        public TextResponse(HttpStatusCode statusCode, string text)
            : base(HttpStatusCode.OK)
        {
            Gard.AgainstNull(text);
        }
    }
}

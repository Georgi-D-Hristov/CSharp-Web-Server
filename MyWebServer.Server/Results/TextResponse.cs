namespace MyWebServer.Server.Results
{
    using System.Text;
    using MyWebServer.Server.Common;
    using MyWebServer.Server.Http;

    public class TextResponse : HttpResponse
    {
        public TextResponse(string text, string contentType)
            : base(HttpStatusCode.OK)
        {
            Gard.AgainstNull(text);

            var contentLength = Encoding.UTF8.GetByteCount(text).ToString();

            this.Headers.Add("Content-Type", contentType);
            this.Headers.Add("Content-Length", contentLength);

            this.Content = text;
        }

        public TextResponse(string text)
           : this(text, "text/html; charset = utf - 8")
        {
        }
    }
}

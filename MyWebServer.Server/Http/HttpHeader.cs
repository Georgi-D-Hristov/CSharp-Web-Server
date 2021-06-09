namespace MyWebServer.Server.Http
{
    using MyWebServer.Server.Common;

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

        public override string ToString()
            => $"{this.Name}: {this.Value}";
    }
}

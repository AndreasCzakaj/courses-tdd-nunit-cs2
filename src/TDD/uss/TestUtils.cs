namespace TDD.Tests.Uss
{
    public static class TestUtils
    {
        public static ResponseFake CreateResponseFake()
        {
            return new ResponseFake();
        }
    }

    public class ResponseFake
    {
        public class CollectorData
        {
            public string ContentType { get; set; } = string.Empty;
            public string Content { get; set; } = string.Empty;
            public int? Status { get; set; }
            public bool Sent { get; set; }
        }

        public CollectorData Collector { get; } = new CollectorData();

        public ResponseFake ContentType(string value)
        {
            Collector.ContentType = value;
            return this;
        }

        public ResponseFake Send(string value)
        {
            Collector.Content = value;
            Collector.Sent = true;
            return this;
        }

        public ResponseFake Status(int value)
        {
            Collector.Status = value;
            return this;
        }
    }
}

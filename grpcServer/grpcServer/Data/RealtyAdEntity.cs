namespace grpcServer.Data
{
    public class RealtyAdEntity
    {
        public class nstring { public string Value { get; set; } };
        public int Id { get; set; }
        public RealtyTypeEntity Type { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public string Photo { get; set; }
        public nstring Address { get; set; }
    }
}

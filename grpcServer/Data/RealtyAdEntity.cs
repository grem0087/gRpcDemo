namespace grpcServer.Data
{
    public class RealtyAdEntity
    {
        public int Id { get; set; }
        public RealtyTypeEntity Type { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
    }
}

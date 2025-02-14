namespace BaseExchange.OrderGenerator.Infrastructure.Fix
{
    public class FixSettings
    {
        public string FixVersion { get; set; } = "FIX.4.4";
        public string SenderCompId { get; set; }
        public string TargetCompId { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string DataDictionary { get; set; }
    }
}

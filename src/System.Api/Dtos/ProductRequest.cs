namespace System.Api.Dtos
{
    public class ProductRequest
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public double? MinValue {  get; set; }
        public double? MaxValue { get; set; }
        public string? Supplier { get; set; }
        public string? Category { get; set; }
        public bool? Displonible { get; set; }
    }
}

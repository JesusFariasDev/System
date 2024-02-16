namespace System.Api.Dtos
{
    public class GetProductRequest
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public decimal? MinValue {  get; set; }
        public decimal? MaxValue { get; set; }
        public string? Category { get; set; }
        public bool? Disponible { get; set; }
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
    }
}

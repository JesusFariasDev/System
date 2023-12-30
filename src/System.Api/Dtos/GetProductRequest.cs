﻿namespace System.Api.Dtos
{
    public class GetProductRequest
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public double? MinValue {  get; set; }
        public double? MaxValue { get; set; }
        public string? Category { get; set; }
        public bool? Disponible { get; set; }
    }
}

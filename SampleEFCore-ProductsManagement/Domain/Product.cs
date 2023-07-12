using SampleEFCore_ProductsManagement.ValueObjects;

namespace SampleEFCore_ProductsManagement.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string BarCode { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Value { get; set; }
        public ProductType ProductType { get; set; }
        public bool Active { get; set; }
    }
}

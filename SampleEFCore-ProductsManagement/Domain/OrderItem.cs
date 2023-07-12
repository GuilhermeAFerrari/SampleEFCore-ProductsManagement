namespace SampleEFCore_ProductsManagement.Domain
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Amount { get; set; }
        public decimal Value { get; set; }
        public decimal Discount { get; set; }

    }
}

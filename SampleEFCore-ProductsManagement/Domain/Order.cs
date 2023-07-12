using SampleEFCore_ProductsManagement.ValueObjects;

namespace SampleEFCore_ProductsManagement.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string Note { get; set; } = null!;
        public ICollection<OrderItem> OrderItems { get; set; } = null!;
    }
}

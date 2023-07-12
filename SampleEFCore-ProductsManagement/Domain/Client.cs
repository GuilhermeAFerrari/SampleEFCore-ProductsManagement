namespace SampleEFCore_ProductsManagement.Domain
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}

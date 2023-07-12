using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleEFCore_ProductsManagement.Domain;

namespace SampleEFCore_ProductsManagement.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Amount).HasDefaultValue(0).IsRequired();
            builder.Property(p => p.Value).HasDefaultValue(0).IsRequired();
            builder.Property(p => p.Discount).HasDefaultValue(0).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SampleEFCore_ProductsManagement.Domain;

namespace SampleEFCore_ProductsManagement.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Started).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.OrderStatus).HasConversion<string>();
            builder.Property(p => p.DeliveryType).HasConversion<int>();
            builder.Property(p => p.Note).HasColumnType("VARCHAR(512)");

            builder.HasMany(p => p.OrderItems)
                .WithOne(p => p.Order)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

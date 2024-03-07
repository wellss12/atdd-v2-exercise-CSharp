using ATDD.V2.Exercise.CSharp.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATDD.V2.Exercise.CSharp.ORM.Configurations;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("orders");
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.DeliverNo).HasColumnName("deliver_no").HasMaxLength(255);
        builder.Property(t => t.DeliveredAt).HasColumnName("delivered_at");
        builder.Property(t => t.ProductName).HasColumnName("product_name").HasMaxLength(255);
        builder.Property(t => t.RecipientAddress).HasColumnName("recipient_address").HasMaxLength(255);
        builder.Property(t => t.RecipientMobile).HasColumnName("recipient_mobile").HasMaxLength(255);
        builder.Property(t => t.RecipientName).HasColumnName("recipient_name").HasMaxLength(255).IsRequired();
        builder.Property(t => t.Status).HasMaxLength(255);
        builder.Property(t => t.Total).HasPrecision(19, 2);
    }
}
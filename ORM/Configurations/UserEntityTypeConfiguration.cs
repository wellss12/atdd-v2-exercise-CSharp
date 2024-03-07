using ATDD.V2.Exercise.CSharp.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATDD.V2.Exercise.CSharp.ORM.Configurations;

public class UserEntityTypeConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.UserName).HasColumnName("user_name");
    }
}
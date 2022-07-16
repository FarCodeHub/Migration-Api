using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
   public class UserMapping : IEntityTypeConfiguration<User>
   {
       public void Configure(EntityTypeBuilder<User> builder)
       {
           builder.ToTable("Users");
           builder.HasKey(f => f.Id);


           builder.HasMany(f => f.Attachments)
               .WithOne(f => f.User)
               .HasForeignKey(f => f.UserId);
        }
   }
}

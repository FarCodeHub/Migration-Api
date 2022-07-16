using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
   public class LawyerMapping:IEntityTypeConfiguration<Lawyer>
    {
        public void Configure(EntityTypeBuilder<Lawyer> builder)
        {
            builder.ToTable("Lawyer");
            builder.HasKey(x => x.Id);


            builder.HasMany(f => f.PersonLawyers)
                .WithOne(x => x.Lawyer)
                .HasForeignKey(f => f.LawyerId);

            builder.HasMany(f => f.LawyerCondition)
                .WithOne(f => f.Lawyer)
                .HasForeignKey(f => f.LawyerId);
        }
    }
}

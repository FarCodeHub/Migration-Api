using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    class VisaMapping : IEntityTypeConfiguration<Visa>
    {
        public void Configure(EntityTypeBuilder<Visa> builder)
        {
            builder.ToTable("Visas");
            builder.HasKey(f => f.Id);


       
        }
    }
}

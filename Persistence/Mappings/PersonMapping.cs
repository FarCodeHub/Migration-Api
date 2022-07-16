using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons");
            builder.HasKey(f => f.Id);
            

            builder.HasOne(f => f.User)
                .WithOne(f => f.Person)
                .HasForeignKey<User>(f => f.PersonId);

            builder.HasOne(f => f.Visa)
                .WithOne(f => f.Person)
                .HasForeignKey<Visa>(f => f.PersonId);

            builder.HasMany(f => f.PersonLawyers)
                .WithOne(x => x.Person)
                .HasForeignKey(f => f.PersonId);

            builder.HasMany(f => f.PersonConditions)
                .WithOne(x => x.Person)
                .HasForeignKey(f => f.PersonId);

        }
    }
}

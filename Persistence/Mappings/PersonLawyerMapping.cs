using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class PersonLawyerMapping : IEntityTypeConfiguration<PersonLawyer>
    {
        public void Configure(EntityTypeBuilder<PersonLawyer> builder)
        {
            builder.ToTable("PersonLawyer");
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.Person)
                .WithMany(f => f.PersonLawyers)
                .HasForeignKey(f => f.PersonId);

            builder.HasOne(f => f.Lawyer)
                .WithMany(f => f.PersonLawyers)
                .HasForeignKey(f => f.LawyerId);
        }
    }
}

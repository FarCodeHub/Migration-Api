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
    public class PersonConditionMapping : IEntityTypeConfiguration<PersonCondition>
    {
        public void Configure(EntityTypeBuilder<PersonCondition> builder)
        {
            builder.ToTable("PersonCondition");
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.Person)
                .WithMany(f => f.PersonConditions)
                .HasForeignKey(f => f.PersonId);

            builder.HasOne(f => f.LawyerCondition)
                .WithMany(f => f.PersonConditions)
                .HasForeignKey(f => f.ConditionId);
        }
    }
    
}

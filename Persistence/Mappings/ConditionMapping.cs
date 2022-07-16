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
    public class ConditionMapping:IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.ToTable("Condition");
            builder.HasKey(x => x.Id);

            builder.HasMany(f => f.LawyerCondition)
                .WithOne(f => f.Condition)
                .HasForeignKey(f => f.ConditionId);


            builder.HasMany(f => f.PersonConditions)
                .WithOne(x => x.Condition)
                .HasForeignKey(f => f.ConditionId);
        }
    }
}

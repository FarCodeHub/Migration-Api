using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class LawyerConditionMapping : IEntityTypeConfiguration<LawyerCondition>
    {
        public void Configure(EntityTypeBuilder<LawyerCondition> builder)
        {
            builder.ToTable("LawyerCondition");
            builder.HasKey(f => f.Id);

            builder.HasOne(f => f.Lawyer)
                .WithMany(f => f.LawyerCondition)
                .HasForeignKey(f => f.LawyerId);

            builder.HasOne(f => f.Condition)
                .WithMany(f => f.LawyerCondition)
                .HasForeignKey(f => f.ConditionId);
        }
    }
}

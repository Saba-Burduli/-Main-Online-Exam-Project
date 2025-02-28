using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.DATA.Entites;

namespace OnlineExam.DATA.Configurations;

public class OptionConfiguration : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.ToTable("Option");
        builder.HasOne(q=>q.Question)
            .WithMany(o => o.Options)
            .HasForeignKey(q => q.QuestionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
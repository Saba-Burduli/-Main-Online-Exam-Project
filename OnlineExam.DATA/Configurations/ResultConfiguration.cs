using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.DATA.Entites;

namespace OnlineExam.DATA.Configurations;

public class ResultConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.ToTable("Result");
        builder.HasMany(r=>r.Exam)
            .WithMany(e=>e.Results)
            .UsingEntity<Dictionary<string, object>>(
                "ResultExam", // join table name
                left => left.HasOne<Exam>()
                    .WithMany()
                    .HasForeignKey("ExamId")
                    .OnDelete(DeleteBehavior.Cascade),
                right => right.HasOne<Result>()
                    .WithMany()
                    .HasForeignKey("ResultId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}
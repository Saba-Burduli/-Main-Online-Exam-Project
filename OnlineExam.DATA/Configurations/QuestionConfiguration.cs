using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.DATA.Entites;

namespace OnlineExam.DATA.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("Question");
        builder.HasOne(e => e.Exam)
            .WithMany(q => q.Questions)
            .HasForeignKey("ExamId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
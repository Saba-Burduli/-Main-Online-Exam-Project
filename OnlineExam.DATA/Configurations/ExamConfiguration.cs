using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.DATA.Entites;

namespace OnlineExam.DATA.Configurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable("Exam");
        builder.HasMany(U => U.Users)
            .WithMany(E => E.Exam)
            .UsingEntity<Dictionary<string, object>>(
                "ExamUser",//join table name
                left =>left.HasOne<User>()
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade),
                right =>right.HasOne<Exam>()
                    .WithMany()
                    .HasForeignKey("ExamId")
                .OnDelete(DeleteBehavior.Cascade));
        
    }
}
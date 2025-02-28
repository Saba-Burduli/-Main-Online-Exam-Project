using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineExam.DATA.Entites;

namespace OnlineExam.DATA.Configurations;

public class ExamParticpantConfiguration : IEntityTypeConfiguration<ExamParticpant>
{
    public void Configure(EntityTypeBuilder<ExamParticpant> builder)
    {
        builder.ToTable("ExamParticpant");
    }
}
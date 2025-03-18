using Microsoft.EntityFrameworkCore;
using OnlineExam.DATA.Configurations;
using OnlineExam.DATA.Entites;

namespace OnlineExam.DATA
{
    public class OnlineExamDbContext : DbContext
    {
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<Option>? Options { get; set; }
        public DbSet<Person>? Persons { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Result>? Results { get; set; }
        public DbSet<Role>? Roles { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<ExamParticpant>? ExamParticpants { get; set; }

        //conststructor for context class
        public OnlineExamDbContext()
        {

        }

        public OnlineExamDbContext(DbContextOptions<OnlineExamDbContext> context) : base(context)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(); //add migration in there ..
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleId = 1,
                    RoleName = "Admin",
                },
                new Role
                {
                    RoleId = 2,
                    RoleName = "Teacher",
                },
                new Role
                {
                    RoleId = 3,
                    RoleName = "Student",
                }

                );

            //ადმინის სიდინგი მაქვს დასამატებელი 



            modelBuilder.ApplyConfiguration(new ExamConfiguration());
            modelBuilder.ApplyConfiguration(new OptionConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new ResultConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new ExamParticpantConfiguration());


           modelBuilder.Entity<Person>().HasData(
           new Person()
            {
                PersonId = 1,
                FirstName = "Saba",
                LastName = "Burduli",
                Address = "Some Address",
                Phone = "+995 12 34 56",
            });        

        modelBuilder.Entity<User>().HasData(

            new User()
            {
                UserId = 1,
                Email = "s.burduli.com",
                RegistrationDate = new DateTime(2025, 02, 14),
                UserName = "Admin",
                PasswordHash = "JAvlGPq9JyTdtvBO6x2llnRI1+gxwIyPqCKAn3THIKk=",  // admin123
                PersonId = 1
            }
            );

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .UsingEntity<Dictionary<string, object>>(
                "RoleUser",

         left => left.HasOne<Role>()
                .WithMany()
                .HasForeignKey("RoleId")
                .OnDelete(DeleteBehavior.Cascade),

            right => right.HasOne<User>()
                .WithMany()
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.Cascade),

             r => r.HasData(new { UserId = 1, RoleId = 1 }));
        }
      }
        
    }



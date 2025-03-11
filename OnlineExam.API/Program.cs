using Microsoft.EntityFrameworkCore;
using OnlineExam.DAL.Repositories;
using OnlineExam.SERVICE;
using OnlineExam.SERVICE.InterFaces;
using OnlineExam.DATA;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using OnlineExam.SERVICE.Mapping;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Db Connection
builder.Services.AddDbContext<OnlineExamDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineExamDbConnection"));
});

// Load JWT secret key from configuration safely
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfig:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                if (context.Request.Cookies.ContainsKey("Token"))
                {
                    context.Token = context.Request.Cookies["Token"];
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.
builder.Services.AddControllers();

// add Services for Repositories
builder.Services.AddScoped<IResultRepository, ResultRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
//<<<<<<< HEAD
builder.Services.AddScoped<IExamRepository, ExamRepository>();
//=======
//>>>>>>> fc58457a961c910f06adee792ef49f115863902d

// add services for Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IAdminService, AdminService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//this is all for JWT Tokens
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


using Microsoft.EntityFrameworkCore;
using OnlineExam.DATA;
using OnlineExam.DATA.Entites;
using OnlineExam.DATA.Infrastructures;

namespace OnlineExam.DAL.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetUserByEmailAsync(string email);
    Task<User> GetUserByIdAsync(int userId);
    Task<User> GetUserWithRolesByIdAsync(int userId);
    Task<User> AssignRoleUserAsync(int userId, List<int> roleIds);
    
}

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly OnlineExamDbContext _context;

    public UserRepository(OnlineExamDbContext context):base(context)
    {
        _context = context; 
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        if (_context == null || _context.Users == null)
        {
            throw new NullReferenceException("The context is null");    
        }
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByIdAsync(int userId)
    {
        return  _context.Users
            .Include(u => u.Roles)
            .FirstOrDefault(u=>u.UserId == userId);
    }

    public async Task<User> GetUserWithRolesByIdAsync(int userId)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u=>u.UserId == userId);   
    }

    public async Task<User> AssignRoleUserAsync(int userId, List<int> roleIds)
    {
        var user = await _context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.UserId == userId);

        if (user == null) throw new Exception("User Not Found");

        var roles = await _context.Roles
            .Where(r => roleIds.Contains(r.RoleId))
            .ToListAsync();

        if (roles.Count != roleIds.Count)
            throw new Exception("Some role was not found");

        user.Roles = roles;

        await _context.SaveChangesAsync();
        return user;
    }
    
    
}
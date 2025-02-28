using OnlineExam.DATA;
using OnlineExam.DATA.Entites;
using OnlineExam.DATA.Infrastructures;

namespace OnlineExam.DAL.Repositories;

public interface IRoleRepository : IBaseRepository<Role>
{
    
}

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    private readonly OnlineExamDbContext _context;
    public RoleRepository(OnlineExamDbContext context) : base(context)
    {
        _context = context;
    }
}
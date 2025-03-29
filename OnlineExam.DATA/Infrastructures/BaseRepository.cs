using Microsoft.EntityFrameworkCore;


namespace OnlineExam.DATA.Infrastructures
{

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly OnlineExamDbContext _context;
        private readonly DbSet<T> _dbSet;

        

        public BaseRepository(OnlineExamDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>() ??
                     throw new ArgumentNullException($"DBSet for Type: {typeof(T)} could not initialize");
        }

        
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if (_context == null || _dbSet == null)
                throw new InvalidOperationException("Database context is not initilized");

            return await _dbSet.ToListAsync();
        }
        

        public async Task<T> GetByIdAsync(int id)
        {
            if (_context == null || _dbSet == null)
                throw new InvalidOperationException("Database context is not initilized");

            return await _dbSet.FindAsync(id);
        }

        
        public async Task AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity) + "can not be null");

            if (_context == null || _dbSet == null)
                throw new InvalidOperationException("Database context is not initilized");

            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity) + "can not be null");

                if (_context == null || _dbSet == null)
                    throw new InvalidOperationException("Database context is not initilized");

                    _dbSet.Update(entity);
                    await _context.SaveChangesAsync();
        }
        

        public async Task DeleteAsync(int id)
        {
            if (_context == null || _dbSet == null)
                throw new InvalidOperationException("Database context is not initilized");

            var user = await _dbSet.FindAsync(id);
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
        
    }
    
}

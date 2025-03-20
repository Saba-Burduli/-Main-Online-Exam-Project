using Microsoft.EntityFrameworkCore;
using OnlineExam.DATA;
using OnlineExam.DATA.Entites;
using OnlineExam.DATA.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.DAL.Repositories
{
        public interface IPersonRepository : IBaseRepository<Person>
        {
            Task<Person> GetLastPersonAsync(Person person);
        }

        public class PersonRepository : BaseRepository<Person>, Repositories.IPersonRepository
        {
            private readonly OnlineExamDbContext _context;
            public PersonRepository(OnlineExamDbContext context) : base(context)
            {
                _context = context;
            }

            public async Task<Person> GetLastPersonAsync(Person person)
            {
                await _context.Persons.AddAsync(person);
                await _context.SaveChangesAsync();

                return await _context.Persons
                    .OrderBy(e => e.PersonId)
                    .LastOrDefaultAsync();
            }
        }
    }

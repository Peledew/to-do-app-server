using Microsoft.EntityFrameworkCore;
using ToDoAppServer.Domain.Entities;
using ToDoAppServer.Domain.Repositories;
using ToDoAppServer.Persistence.Database;
using ToDoAppServer.Persistence.Repositories.Abstracts;

namespace ToDoAppServer.Persistence.Repositories.Models
{
    public sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Set<User>()
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}

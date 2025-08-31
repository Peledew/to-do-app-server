using ToDoAppServer.Domain.Entities;

namespace ToDoAppServer.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}

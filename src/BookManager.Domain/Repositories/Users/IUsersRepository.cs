using BookManager.Domain.Entities;

namespace BookManager.Domain.Repositories.Users;

public interface IUsersRepository
{
    Task<List<User>> GetAll();
    Task<User?> GetById(Guid id);
    Task Add(User user);
    Task Update(User user);
    Task Delete(Guid id);
}
using BookManager.Domain.Entities;
using BookManager.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.DataAccess.Repositories;

internal class UsersRepository : IUsersRepository
{
    private readonly BookManagerDbContext _dbContext;

    public UsersRepository(BookManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetById(Guid id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task Update(User user)
    {
        _dbContext.Users.Update(user);
        await Task.CompletedTask;
    }

    public async Task Delete(Guid id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user != null)
        {
            _dbContext.Users.Remove(user);
        }
    }
}
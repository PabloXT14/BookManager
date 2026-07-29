using BookManager.Domain.Repositories;

namespace BookManager.Infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly BookManagerDbContext _dbContext;

    public UnitOfWork(BookManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}
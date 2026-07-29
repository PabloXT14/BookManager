using BookManager.Domain.Entities;
using BookManager.Domain.Repositories.Books;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.DataAccess.Repositories;

internal class BooksRepository : IBooksRepository
{
    private readonly BookManagerDbContext _dbContext;

    public BooksRepository(BookManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetAll()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<Book?> GetById(Guid id)
    {
        return await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task Add(Book book)
    {
        await _dbContext.Books.AddAsync(book);
    }

    public async Task Update(Book book)
    {
        _dbContext.Books.Update(book);
        await Task.CompletedTask;
    }

    public async Task Delete(Guid id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(b => b.Id == id);

        if (book != null)
        {
            _dbContext.Books.Remove(book);
        }
    }
}
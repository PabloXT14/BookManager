using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infrastructure.DataAccess;

internal class BookManagerDbContext : DbContext
{
    public BookManagerDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;
}
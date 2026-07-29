using BookManager.Domain.Repositories;
using BookManager.Domain.Repositories.Books;
using BookManager.Domain.Repositories.Users;
using BookManager.Infrastructure.DataAccess;
using BookManager.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookManager.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IBooksRepository, BooksRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<BookManagerDbContext>(config =>
            config.UseSqlite(connectionString));
    }
}
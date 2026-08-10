using BookManager.Application.AutoMapper;
using BookManager.Application.UseCases.Books.Register;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper();
        services.AddUseCases();
    }

    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<AutoMapping>();
        });
    }

    private static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IRegisterBookUseCase, RegisterBookUseCase>();
    }
}
namespace BookManager.Web.States;

public static class DependencyInjectionExtension
{
    public static void AddStates(this IServiceCollection services)
    {
        services.AddScoped<BookState>();
        services.AddScoped<UserState>();
    }
}
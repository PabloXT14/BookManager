using BookManager.Web.Components.Pages.Home.Components.BookForm;
using FluentValidation;

namespace BookManager.Web;

public static class DependencyInjectionExtension
{
    public static void AddWeb(this IServiceCollection services)
    {
        services.AddFormValidators();
    }

    public static void AddFormValidators(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<BookFormModel>, BookFormValidator>();
    }
}
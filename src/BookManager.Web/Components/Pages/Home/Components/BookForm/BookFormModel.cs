using BookManager.Domain.Enums;

namespace BookManager.Web.Components.Pages.Home.Components.BookForm;

public class BookFormModel
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public ReadStatus ReadStatus { get; set; } = ReadStatus.Default;
    public int Rating { get; set; }
    public string CoverImageUrl { get; set; } = string.Empty;
}
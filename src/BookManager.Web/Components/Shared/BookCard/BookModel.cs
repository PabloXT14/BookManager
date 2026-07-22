using BookManager.Web.Components.Shared.Badge;

namespace BookManager.Web.Components.Shared.BookCard;

public class BookModel
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public BadgeType BadgeType { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
}

using BookManager.Communication.Enums;

namespace BookManager.Communication.Requests;

public class RequestBookJson
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public ReadStatus ReadStatus { get; set; } = ReadStatus.Default;
    public int Rating { get; set; } = 0;
    public string CoverImageUrl { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Guid UserId { get; set; }
}
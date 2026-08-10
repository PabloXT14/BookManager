using BookManager.Domain.Entities;
using BookManager.Domain.Enums;

namespace BookManager.Web.States;

public class BookState
{
    // This event is triggered whenever the state changes, allowing components to react to the change.
    public event Action? OnChange;
    public void NotifyStateChanged() => OnChange?.Invoke();

    private List<Book> ALL_BOOKS = [
        new Book
        {
            Title = "O Senhor dos Anéis",
            Author = "J.R.R. Tolkien",
            CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/91b0C2YNSrL.jpg",
            ReadStatus = ReadStatus.Done,
            Rating = 5,
            Description = "Uma obra-prima da literatura fantástica."
        },
        new Book
        {
            Title = "1984",
            Author = "George Orwell",
            CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/71kxa1-0mfL.jpg",
            ReadStatus = ReadStatus.InProgress,
            Rating = 4,
            Description = "Um livro perturbador e visionário sobre o totalitarismo."
        },
        new Book
        {
            Title = "O Pequeno Príncipe",
            Author = "Antoine de Saint-Exupéry",
            CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/81eB+7+CkUL.jpg",
            ReadStatus = ReadStatus.Default,
            Rating = 0,
            Description = "Uma história encantadora que nos lembra da importância da imaginação e da amizade."
        },
        new Book
        {
            Title = "A Revolução dos Bichos",
            Author = "George Orwell",
            CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/71kxa1-0mfL.jpg",
            ReadStatus = ReadStatus.Done,
            Rating = 5,
            Description = "Uma fábula política que critica o totalitarismo e a corrupção do poder."
        },
        new Book
        {
            Title = "O Hobbit",
            Author = "J.R.R. Tolkien",
            CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/91b0C2YNSrL.jpg",
            ReadStatus = ReadStatus.InProgress,
            Rating = 3,
            Description = "Uma aventura épica que antecede O Senhor dos Anéis."
        },
        new Book
        {
            Title = "Fahrenheit 451",
            Author = "Ray Bradbury",
            CoverImageUrl = "https://images-na.ssl-images-amazon.com/images/I/71kxa1-0mfL.jpg",
            ReadStatus = ReadStatus.Default,
            Rating = 0,
            Description = "Um romance distópico que explora a censura e a repressão da liberdade de expressão."
        }
    ];

    public List<Book> books = [];

    public void AddBook(Book book)
    {
        books.Add(book);

        NotifyStateChanged();
    }

    public void GetBooks()
    {
        NotifyStateChanged();
    }

    public void FilterBooks(string searchQuery, ReadStatus? readStatus = null)
    {
        var filteredBooks = ALL_BOOKS
            .Where(book =>
                book.Title.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                book.Author.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)
            )
            .Where(book =>
                readStatus == null || book.ReadStatus == readStatus
            )
            .ToList();

        books = filteredBooks;

        NotifyStateChanged();
    }

    public void RemoveBook(Guid bookId)
    {
        var bookToRemove = books.FirstOrDefault(b => b.Id == bookId);

        if (bookToRemove == null) return;

        books.Remove(bookToRemove);

        NotifyStateChanged();
    }

    public void UpdateBook(Book book)
    {
        var existingBook = books.FirstOrDefault(b => b.Id == book.Id);

        if (existingBook == null) return;

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.CoverImageUrl = book.CoverImageUrl;
        existingBook.ReadStatus = book.ReadStatus;
        existingBook.Rating = book.Rating;
        existingBook.Description = book.Description;

        NotifyStateChanged();
    }
}
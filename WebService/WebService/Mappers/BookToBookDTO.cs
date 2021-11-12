using WebService.Models;

namespace WebService.Mappers
{
    public class BookToBookDTO : IMapper<Book, BookDTO>
    {
        public BookDTO Map(Book book)
        {
            if (book is null)
            {
                return null;
            }
            else
            {
                return new BookDTO { Name = book.Name, Author = book.Author };
            }
        }
    }
}

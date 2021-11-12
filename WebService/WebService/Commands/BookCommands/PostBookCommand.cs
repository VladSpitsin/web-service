using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;

namespace WebService.Commands.BookCommands
{
    public class PostBookCommand : IPostCommand<Book>
    {
        private readonly BookRepo _repository;

        public PostBookCommand(BookRepo repository)
        {
            _repository = repository;
        }

        public void Execute(Book book)
        {
            _repository.Post(book);
        }
    }
}

using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;

namespace WebService.Commands.BookCommands
{
    public class PutBookCommand : IPutCommand<Book>
    {
        private readonly BookRepo _repository;

        public PutBookCommand(BookRepo repository)
        {
            _repository = repository;
        }

        public void Execute(Book book)
        {
            _repository.Put(book);
        }
    }
}

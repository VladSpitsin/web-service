using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;

namespace WebService.Commands.BookCommands
{
    public class DeleteBookCommand : IDeleteCommand<Book>
    {
        private readonly BookRepo _repository;

        public DeleteBookCommand(BookRepo repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.Delete(id);
        }
    }
}

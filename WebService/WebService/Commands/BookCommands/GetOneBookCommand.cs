using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;
using WebService.Mappers;

namespace WebService.Commands.BookCommands
{
    public class GetOneBookCommand : IGetOneCommand<BookDTO>
    {
        private readonly BookRepo _repository;
        private readonly BookToBookDTO _mapper;

        public GetOneBookCommand(BookRepo repository, BookToBookDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BookDTO Execute(int id)
        {
            Book result = _repository.GetOne(id).Item1;
            BookDTO book = _mapper.Map(result);
            return book;
        }
    }
}

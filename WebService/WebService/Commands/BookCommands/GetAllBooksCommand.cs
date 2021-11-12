using System.Collections.Generic;
using System.Linq;
using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;
using WebService.Mappers;

namespace WebService.Commands.BookCommands
{
    public class GetAllBooksCommand : IGetAllCommand<BookDTO>
    {
        private readonly BookRepo _repository;
        private readonly BookToBookDTO _mapper;

        public GetAllBooksCommand(BookRepo repository, BookToBookDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<BookDTO> Execute()
        {
            IEnumerable<BookDTO> result = (IEnumerable<BookDTO>)_repository.Get().Item1.ToList().Select(x => _mapper.Map(x));
            return result;
        }
    }
}

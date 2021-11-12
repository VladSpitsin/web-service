using System.Collections.Generic;
using System.Linq;
using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;
using WebService.Mappers;

namespace WebService.Commands.ProductCommands
{
    public class GetAllProductsCommand : IGetAllCommand<ProductDTO>
    {
        private readonly ProductRepo _repository;
        private readonly ProductToProductDTO _mapper;

        public GetAllProductsCommand(ProductRepo repository, ProductToProductDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDTO> Execute()
        {
            IEnumerable<ProductDTO> result = (IEnumerable<ProductDTO>)_repository.Get().Item1.ToList().Select(x => _mapper.Map(x));
            return result;
        }
    }
}

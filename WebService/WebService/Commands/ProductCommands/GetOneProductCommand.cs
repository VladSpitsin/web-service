using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;
using WebService.Mappers;

namespace WebService.Commands.ProductCommands
{
    public class GetOneProductCommand : IGetOneCommand<ProductDTO>
    {
        private readonly ProductRepo _repository;
        private readonly ProductToProductDTO _mapper;

        public GetOneProductCommand(ProductRepo repository, ProductToProductDTO mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ProductDTO Execute(int id)
        {
            Product result = _repository.GetOne(id).Item1;
            ProductDTO book = _mapper.Map(result);
            return book;
        }
    }
}

using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;

namespace WebService.Commands.ProductCommands
{
    public class PutProductCommand : IPutCommand<Product>
    {
        private readonly ProductRepo _repository;

        public PutProductCommand(ProductRepo repository)
        {
            _repository = repository;
        }

        public void Execute(Product product)
        {
            _repository.Put(product);
        }
    }
}

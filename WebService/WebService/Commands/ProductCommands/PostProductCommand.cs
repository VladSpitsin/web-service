using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;

namespace WebService.Commands.ProductCommands
{
    public class PostProductCommand : IPostCommand<Product>
    {
        private readonly ProductRepo _repository;

        public PostProductCommand(ProductRepo repository)
        {
            _repository = repository;
        }

        public void Execute(Product product)
        {
            _repository.Post(product);
        }
    }
}

using WebService.Commands.Interfaces;
using WebService.Models;
using WebService.Repositories;
namespace WebService.Commands.GoodCommands
{
    public class DeleteProductCommand : IDeleteCommand<Product>
    {
        private readonly ProductRepo _repository;

        public DeleteProductCommand(ProductRepo repository)
        {
            _repository = repository;
        }

        public void Execute(int id)
        {
            _repository.Delete(id);
        }
    }
}

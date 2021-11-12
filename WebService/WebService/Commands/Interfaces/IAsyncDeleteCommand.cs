using System.Threading.Tasks;

namespace WebService.Commands.Interfaces
{
    public interface IAsyncDeleteCommand<T>
    {
        Task Execute(int i);
    }
}

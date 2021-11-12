using System.Threading.Tasks;

namespace WebService.Commands.Interfaces
{
    public interface IAsyncPostCommand<T>
    {
        Task Execute(T t);
    }
}

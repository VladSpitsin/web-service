using System.Threading.Tasks;

namespace WebService.Commands.Interfaces
{
    public interface IAsyncPutCommand<T>
    {
        Task Execute(T t);
    }
}

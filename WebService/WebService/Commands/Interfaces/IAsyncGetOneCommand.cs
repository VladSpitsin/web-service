using System.Threading.Tasks;

namespace WebService.Commands.Interfaces
{
    public interface IAsyncGetByIDCommand<T>
    {
        Task<T> Execute(int i);
    }
}

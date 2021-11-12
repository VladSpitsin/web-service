using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebService.Commands.Interfaces
{
    public interface IAsyncGetAllCommand<T>
    {
        Task<IEnumerable<T>> Execute();
    }
}

using System.Collections.Generic;

namespace WebService.Commands.Interfaces
{
    public interface IGetAllCommand<T>
    {
        IEnumerable<T> Execute();
    }
}

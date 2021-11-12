using System.Collections.Generic;

namespace WebService.Repositories
{
    public interface IRepository<T>
    {
        string Delete(int id);
        string Post(T t);
        string Put(T t);
        (IEnumerable<T>, string) Get();
        (T, string) GetOne(int id);
    }
}

namespace WebService.Commands.Interfaces
{
    public interface IGetOneCommand<T>
    {
        T Execute(int i);
    }
}

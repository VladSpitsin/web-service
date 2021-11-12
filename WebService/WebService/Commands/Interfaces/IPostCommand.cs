namespace WebService.Commands.Interfaces
{
    public interface IPostCommand<T>
    {
        void Execute(T t);
    }
}

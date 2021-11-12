namespace WebService.Commands.Interfaces
{
    public interface IPutCommand<T>
    {
        void Execute(T t);
    }
}

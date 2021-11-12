namespace WebService.Mappers
{
    public interface IMapper<in i, out o>
    {
        o Map(i item);
    }
}

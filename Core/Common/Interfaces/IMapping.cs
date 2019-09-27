namespace Common.Interfaces
{
    public interface IMapping<T, TU>
    {
        TU Map(T source, TU destination);

        T Map(TU source, T destination);
    }
}

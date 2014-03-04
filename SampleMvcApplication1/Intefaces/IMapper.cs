namespace SampleMvcApplication1.Intefaces
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource dataModel);
    }
}

namespace SampleMvc.Web.Mappers
{
    using System.Collections.Generic;

    public interface IMapper<TSource, TDestination>
    {
        TDestination MapFrom(TSource source);
        IEnumerable<TDestination> MapFrom(IEnumerable<TSource> source);
    }
}
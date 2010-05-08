namespace SampleMvc.Web.Mappers
{
    using System.Collections.Generic;

    public abstract class BaseBidirectionalMapper<TSource, TDest> : IMapper<TSource, TDest>
    {
        public abstract TDest MapFrom(TSource source);
        public abstract IEnumerable<TDest> MapFrom(IEnumerable<TSource> source);
        public abstract TSource MapFrom(TDest source);
        public abstract IEnumerable<TSource> MapFrom(IEnumerable<TDest> source);
    }
}
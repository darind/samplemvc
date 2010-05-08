namespace SampleMvc.Web.Mappers
{
    using System;

    public interface IMapper
    {
        object Map(object source, Type sourceType, Type destinationType);
    }
}
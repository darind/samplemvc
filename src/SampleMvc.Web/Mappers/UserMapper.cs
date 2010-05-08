namespace SampleMvc.Web.Mappers
{
    using System;
    using AutoMapper;
    using SampleMvc.Business.Domain;
    using SampleMvc.Web.Models;

    public class UserMapper : IMapper
    {
        static UserMapper()
        {
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>();
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}
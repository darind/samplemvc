namespace SampleMvc.Web.Mappers
{
    using System.Collections.Generic;
    using AutoMapper;
    using SampleMvc.Business.Domain;
    using SampleMvc.Web.Models;

    public class UserMapper : BaseBidirectionalMapper<User, UserViewModel>
    {
        static UserMapper()
        {
            Mapper.CreateMap<User, UserViewModel>();
            Mapper.CreateMap<UserViewModel, User>();
        }

        public override UserViewModel MapFrom(User source)
        {
            return Mapper.Map<User, UserViewModel>(source);
        }

        public override IEnumerable<UserViewModel> MapFrom(IEnumerable<User> source)
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(source);
        }

        public override User MapFrom(UserViewModel source)
        {
            return Mapper.Map<UserViewModel, User>(source);
        }

        public override IEnumerable<User> MapFrom(IEnumerable<UserViewModel> source)
        {
            return Mapper.Map<IEnumerable<UserViewModel>, IEnumerable<User>>(source);
        }
    }
}
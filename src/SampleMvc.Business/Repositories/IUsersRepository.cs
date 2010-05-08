namespace SampleMvc.Business.Repositories
{
    using System.Collections.Generic;
    using SampleMvc.Business.Domain;

    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User Get(int id);
        void Delete(int id);
        int Save(User user);
        void Update(User user);
    }
}

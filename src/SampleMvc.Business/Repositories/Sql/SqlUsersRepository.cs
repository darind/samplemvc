namespace SampleMvc.Business.Repositories.Sql
{
    using System.Collections.Generic;
    using SampleMvc.Business.Domain;
    using Spring.Data.NHibernate.Generic.Support;

    public class SqlUsersRepository : HibernateDaoSupport, IUsersRepository
    {
        public IEnumerable<User> GetUsers()
        {
            return HibernateTemplate.LoadAll<User>();
        }

        public User Get(int id)
        {
            return HibernateTemplate.Get<User>(id);
        }

        public void Delete(int id)
        {
            HibernateTemplate.Delete(new User { Id = id });
        }

        public int Save(User user)
        {
            return ((User)HibernateTemplate.Save(user)).Id;
        }

        public void Update(User user)
        {
            HibernateTemplate.Update(user);
        }
    }
}

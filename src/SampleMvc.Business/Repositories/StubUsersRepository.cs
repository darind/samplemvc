namespace SampleMvc.Business.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SampleMvc.Business.Domain;

    public class StubUsersRepository : IUsersRepository
    {
        public IEnumerable<User> GetUsers()
        {
            return new[]
            {
                new User
                {
                    Id = 1,
                    FirstName = "first 1",
                    LastName = "last 1",
                    Age = 39
                },
                new User
                {
                    Id = 2,
                    FirstName = "first 2",
                    LastName = "last 2",
                },
            };
        }

        public User Get(int id)
        {
            return new User
            {
                Id = id,
                FirstName = "first 1",
                LastName = "last 1",
                Age = 56
            };
        }

        public void Delete(int id)
        {
            
        }

        public int Save(User user)
        {
            return 1;
        }

        public void Update(User user)
        {
            
        }
    }
}

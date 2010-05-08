namespace SampleMvc.Business.Repositories.Sql
{
    using FluentNHibernate.Mapping;
    using SampleMvc.Business.Domain;

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("users");
            Id(x => x.Id, "usr_id");
            Map(x => x.FirstName, "usr_firstname");
            Map(x => x.LastName, "usr_lastname");
            Map(x => x.Age, "usr_age");
        }
    }
}

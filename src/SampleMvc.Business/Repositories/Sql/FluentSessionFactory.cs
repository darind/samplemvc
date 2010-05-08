namespace SampleMvc.Business.Repositories.Sql
{
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.ByteCode.Castle;
    using NHibernate.Cfg;
    using Spring.Data.NHibernate;

    public class FluentSessionFactory : LocalSessionFactoryObject
    {
        private readonly string _dataFile;
        public FluentSessionFactory(string dataFile)
        {
            _dataFile = dataFile;
        }

        protected override ISessionFactory NewSessionFactory(Configuration config)
        {
            return Fluently
                .Configure()
                .Database(
                    SQLiteConfiguration
                        .Standard
                        .UsingFile(_dataFile)
                        .ProxyFactoryFactory<ProxyFactoryFactory>()
                ).Mappings(
                    m => m.FluentMappings.AddFromAssemblyOf<UserMap>()
                ).BuildSessionFactory();
        }
    }
}

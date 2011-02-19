namespace SampleMvc.Business.Tests.Repositories.Sql
{
    using System.IO;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NHibernate;
    using SampleMvc.Business.Domain;
    using SampleMvc.Business.Repositories.Sql;

    /// <summary>
    /// Summary description for SqlUsersRepositoryTests
    /// </summary>
    [TestClass]
    public class SqlUsersRepositoryTests
    {
        private SqlUsersRepository _sut;
        private const string DataFile = "data.db3";

        public SqlUsersRepositoryTests()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            if (File.Exists(DataFile))
            {
                File.Delete(DataFile);
            }
            _sut = new SqlUsersRepository();
            var sessionFactory = new FluentSessionFactory(DataFile);
            sessionFactory.AfterPropertiesSet();
            _sut.SessionFactory = (ISessionFactory)sessionFactory.GetObject();
            File.ReadAllLines(@"CreateDbSchema.sql").ToList().ForEach(ExecuteCommand);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private void ExecuteCommand(string command)
        {
            using (var conn = _sut.SessionFactory.OpenSession().Connection)
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
            }
        }

        [TestMethod]
        [DeploymentItem(@"Repositories\Sql\CreateDbSchema.sql")]
        public void SqlUsersRepository_GetUsers()
        {
            // act
            var actual = _sut.GetUsers();

            // assert
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(1, actual.ElementAt(0).Id);
            Assert.AreEqual("first name 1", actual.ElementAt(0).FirstName);
            Assert.AreEqual("last name 1", actual.ElementAt(0).LastName);
            Assert.AreEqual(30, actual.ElementAt(0).Age);
            Assert.AreEqual(2, actual.ElementAt(1).Id);
            Assert.AreEqual("first name 2", actual.ElementAt(1).FirstName);
            Assert.AreEqual("last name 2", actual.ElementAt(1).LastName);
            Assert.IsNull(actual.ElementAt(1).Age);
        }

        [TestMethod]
        [DeploymentItem(@"Repositories\Sql\CreateDbSchema.sql")]
        public void SqlUsersRepository_Get()
        {
            // arrange
            var id = 2;

            // act
            var actual = _sut.Get(id);

            // assert
            Assert.AreEqual("first name 2", actual.FirstName);
            Assert.AreEqual("last name 2", actual.LastName);
            Assert.AreEqual(50, actual.Age);
        }

        [TestMethod]
        [DeploymentItem(@"Repositories\Sql\CreateDbSchema.sql")]
        public void SqlUsersRepository_Delete()
        {
            // arrange
            var id = 1;

            // act
            _sut.Delete(id);

            // assert
            using (var conn = _sut.SessionFactory.OpenSession().Connection)
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select count(usr_id) from users";
                var count = (long)cmd.ExecuteScalar();
                Assert.AreEqual(1, count);
            }
        }

        [TestMethod]
        [DeploymentItem(@"Repositories\Sql\CreateDbSchema.sql")]
        public void SqlUsersRepository_Save()
        {
            // arrange
            var user = new User
            {
                FirstName = "first name 3",
                LastName = "last name 3",
                Age = 35
            };

            // act
            var actual = _sut.Save(user);

            // assert
            Assert.AreEqual(3, actual);
            using (var conn = _sut.SessionFactory.OpenSession().Connection)
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select count(usr_id) from users";
                var count = (long)cmd.ExecuteScalar();
                Assert.AreEqual(3, count);
            }
        }

        [TestMethod]
        [DeploymentItem(@"Repositories\Sql\CreateDbSchema.sql")]
        public void SqlUsersRepository_Update()
        {
            // arrange
            var user = new User
            {
                Id = 2,
                FirstName = "new first name 2",
                LastName = "new last name 2",
                Age = 35
            };

            // act
            _sut.Update(user);

            // assert
            using (var conn = _sut.SessionFactory.OpenSession().Connection)
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "select usr_firstname, usr_lastname, usr_age from users where usr_id = ?";
                var parameter = cmd.CreateParameter();
                parameter.Value = user.Id;
                cmd.Parameters.Add(parameter);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Assert.AreEqual(user.FirstName, reader.GetString(0));
                        Assert.AreEqual(user.LastName, reader.GetString(1));
                        Assert.AreEqual(user.Age, reader.GetInt32(2));
                    }
                }
            }

        }

    }
}

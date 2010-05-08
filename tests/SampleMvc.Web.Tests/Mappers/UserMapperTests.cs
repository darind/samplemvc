namespace SampleMvc.Web.Tests.Mappers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SampleMvc.Web.Mappers;
    using SampleMvc.Business.Domain;
    using SampleMvc.Web.Models;
    using MvcContrib.TestHelper;

    /// <summary>
    /// Summary description for UserMapperTests
    /// </summary>
    [TestClass]
    public class UserMapperTests
    {
        private UserMapper _sut;

        public UserMapperTests()
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
            _sut = new UserMapper();
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void UserMapper_Map_From_User_to_UserViewModel()
        {
            // arrange
            var user = new User
            {
                Id = 10,
                FirstName = "John",
                LastName = "Smith",
                Age = 56
            };

            // act
            var actual = (UserViewModel)_sut.Map(user, typeof(User), typeof(UserViewModel));

            // assert
            actual.Id.ShouldBe(user.Id);
            actual.FirstName.ShouldBe(user.FirstName);
            actual.LastName.ShouldBe(user.LastName);
            actual.Age.ShouldBe(user.Age);
        }

        [TestMethod]
        public void UserMapper_Map_From_UserViewModel_to_User()
        {
            // arrange
            var user = new UserViewModel
            {
                Id = 10,
                FirstName = "John",
                LastName = "Smith",
                Age = 56
            };

            // act
            var actual = (User)_sut.Map(user, typeof(UserViewModel), typeof(User));

            // assert
            actual.Id.ShouldBe(user.Id);
            actual.FirstName.ShouldBe(user.FirstName);
            actual.LastName.ShouldBe(user.LastName);
            actual.Age.ShouldBe(user.Age);
        }
    }
}

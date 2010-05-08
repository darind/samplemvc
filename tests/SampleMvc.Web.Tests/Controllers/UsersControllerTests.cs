namespace SampleMvc.Web.Tests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcContrib.TestHelper;
    using Rhino.Mocks;
    using SampleMvc.Business.Domain;
    using SampleMvc.Business.Repositories;
    using SampleMvc.Web.Controllers;
    using SampleMvc.Web.Mappers;
    using SampleMvc.Web.Models;

    /// <summary>
    /// Summary description for UsersControllerTests
    /// </summary>
    [TestClass]
    public class UsersControllerTests : TestControllerBuilder
    {
        private UsersController _sut;
        private IUsersRepository _repositoryStub;
        private BaseBidirectionalMapper<User, UserViewModel> _userMapperStub;

        public UsersControllerTests()
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
            _repositoryStub = MockRepository.GenerateStub<IUsersRepository>();
            _userMapperStub = MockRepository.GenerateStub<BaseBidirectionalMapper<User, UserViewModel>>();
            _sut = new UsersController(_repositoryStub, _userMapperStub);
            InitializeController(_sut);
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void UsersController_Index()
        {
            // arrange
            var users = new User[0];
            _repositoryStub.Stub(x => x.GetUsers()).Return(users);

            // act
            var actual = _sut.Index();

            // assert
            actual
                .AssertViewRendered()
                .WithViewData<User[]>()
                .ShouldBe(users);
        }

        [TestMethod]
        public void UsersController_New()
        {
            // act
            var actual = _sut.New();

            // assert
            actual
                .AssertViewRendered();
        }

        [TestMethod]
        public void UsersController_Create_Invalid_Model_State()
        {
            // arrange
            _sut.ModelState.AddModelError("FirstName", "First name is required");
            var userView = new UserViewModel();

            // act
            var actual = _sut.Create(userView);

            // assert
            actual
                .AssertViewRendered()
                .ForView("New")
                .WithViewData<UserViewModel>()
                .ShouldBe(userView);
        }

        [TestMethod]
        public void UsersController_Create_Success()
        {
            // arrange
            var userView = new UserViewModel();
            var user = new User();
            _userMapperStub.Stub(x => x.MapFrom(userView)).Return(user);

            // act
            var actual = _sut.Create(userView);

            // assert
            actual
                .AssertActionRedirect()
                .ToAction<UsersController>(c => c.Index());
            _repositoryStub.AssertWasCalled(x => x.Save(user));
        }

        [TestMethod]
        public void UsersController_Show()
        {
            // arrange
            var id = 1;
            var user = new User();
            _repositoryStub.Stub(x => x.Get(id)).Return(user);

            // act
            var actual = _sut.Show(id);

            // assert
            actual
                .AssertViewRendered()
                .WithViewData<User>()
                .ShouldBe(user);
        }

        [TestMethod]
        public void UsersController_Edit()
        {
            // arrange
            var id = 1;
            var user = new User();
            _repositoryStub.Stub(x => x.Get(id)).Return(user);

            // act
            var actual = _sut.Edit(id);

            // assert
            actual
                .AssertViewRendered()
                .WithViewData<User>()
                .ShouldBe(user);
        }

        [TestMethod]
        public void UsersController_Update_Invalid_Model_State()
        {
            // arrange
            _sut.ModelState.AddModelError("FirstName", "First name is required");
            var userView = new UserViewModel();

            // act
            var actual = _sut.Update(userView);

            // assert
            actual
                .AssertViewRendered()
                .ForView("Edit")
                .WithViewData<UserViewModel>()
                .ShouldBe(userView);
        }

        [TestMethod]
        public void UsersController_Update_Success()
        {
            // arrange
            var userView = new UserViewModel();
            var user = new User();
            _userMapperStub.Stub(x => x.MapFrom(userView)).Return(user);

            // act
            var actual = _sut.Update(userView);

            // assert
            actual
                .AssertActionRedirect()
                .ToAction<UsersController>(c => c.Index());
            _repositoryStub.AssertWasCalled(x => x.Update(user));
        }

        [TestMethod]
        public void UsersController_Destroy()
        {
            // arrange
            var id = 1;

            // act
            var actual = _sut.Destroy(id);

            // assert
            actual
                .AssertActionRedirect()
                .ToAction<UsersController>(c => c.Index());
            _repositoryStub.AssertWasCalled(x => x.Delete(id));
        }


    }
}

namespace SampleMvc.Web.Tests.Mvc
{
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MvcContrib.TestHelper;
    using Rhino.Mocks;
    using SampleMvc.Business.Domain;
    using SampleMvc.Web.Controllers;
    using SampleMvc.Web.Mappers;
    using SampleMvc.Web.Models;
    using SampleMvc.Web.Mvc;

    /// <summary>
    /// Summary description for AutoMapAttributeTests
    /// </summary>
    [TestClass]
    public class AutoMapAttributeTests : TestControllerBuilder
    {
        private IMapper _mapperStub;
        private TestController _controller;
        private AutoMapAttribute _sut;

        private class TestController : Controller, IModelMapperController
        {
            public TestController(IMapper mapper)
            {
                ModelMapper = mapper;
            }

            public IMapper ModelMapper { get; private set; }
        }

        public AutoMapAttributeTests()
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
            _mapperStub = MockRepository.GenerateStub<IMapper>();
            _controller = new TestController(_mapperStub);
            InitializeController(_controller);
            _sut = new AutoMapAttribute(typeof(User), typeof(UserViewModel));
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AutoMapAttribute_OnActionExecuted()
        {
            // arrange
            var user = new User();
            var userView = new UserViewModel();
            var filterContext = new ActionExecutedContext();
            _controller.ViewData.Model = user;
            filterContext.Controller = _controller;
            _mapperStub
                .Stub(x => x.Map(user, typeof(User), typeof(UserViewModel)))
                .Return(userView);

            // act
            _sut.OnActionExecuted(filterContext);

            // assert
            _controller.ViewData.Model.ShouldBe(userView);
        }

        [TestMethod]
        public void AutoMapAttribute_OnActionExecuted_Controller_Not_Implementing_IModelMapperController()
        {
            // arrange
            var user = new User();
            var userView = new UserViewModel();
            var filterContext = new ActionExecutedContext();

            // act
            _sut.OnActionExecuted(filterContext);

            // assert
            _mapperStub.AssertWasNotCalled(
                x => x.Map(null, null, null),
                x => x.IgnoreArguments()
            );

        }
    }
}

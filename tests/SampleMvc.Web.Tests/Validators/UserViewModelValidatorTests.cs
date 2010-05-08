namespace SampleMvc.Web.Tests.Validators
{
    using FluentValidation.TestHelper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SampleMvc.Web.Validators;

    /// <summary>
    /// Summary description for UserViewModelValidatorTests
    /// </summary>
    [TestClass]
    public class UserViewModelValidatorTests
    {
        private UserViewModelValidator _sut;

        public UserViewModelValidatorTests()
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
            _sut = new UserViewModelValidator();
        }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void UserViewModelValidator_FirstName_Required()
        {
            _sut.ShouldHaveValidationErrorFor(x => x.FirstName, string.Empty);
        }

        [TestMethod]
        public void UserViewModelValidator_LastName_Required()
        {
            _sut.ShouldHaveValidationErrorFor(x => x.LastName, string.Empty);
        }

        [TestMethod]
        public void UserViewModelValidator_Success()
        {
            _sut.ShouldNotHaveValidationErrorFor(x => x.FirstName, "John");
            _sut.ShouldNotHaveValidationErrorFor(x => x.LastName, "Smith");
            _sut.ShouldNotHaveValidationErrorFor(x => x.Age, 56);
        }
    }
}

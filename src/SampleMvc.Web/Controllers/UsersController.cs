namespace SampleMvc.Web.Controllers
{
    using System.Web.Mvc;
    using SampleMvc.Business.Domain;
    using SampleMvc.Business.Repositories;
    using SampleMvc.Web.Mappers;
    using SampleMvc.Web.Models;
    using SampleMvc.Web.Mvc;

    [HandleError]
    public class UsersController : Controller
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _userMapper;

        public UsersController(
            IUsersRepository repository,
            IMapper userMapper)
        {
            _repository = repository;
            _userMapper = userMapper;
        }

        [AutoMap(typeof(User[]), typeof(UserViewModel[]))]
        public ActionResult Index()
        {
            // return all users
            var users = _repository.GetUsers();
            return View(users);

        }

        public ActionResult New()
        {
            // return an HTML form for describing a new user
            return View();
        }

        [HttpPost]
        [AutoMap(typeof(User), typeof(UserViewModel))]
        public ActionResult Create(UserViewModel userView)
        {
            // create a new user
            if (!ModelState.IsValid)
            {
                return View("New", userView);
            }
            var user = (User)_userMapper.Map(userView, typeof(UserViewModel), typeof(User));
            _repository.Save(user);
            return RedirectToAction("Index", "Users");
        }

        [AutoMap(typeof(User), typeof(UserViewModel))]
        public ActionResult Show(int id)
        {
            // find and return a specific user
            var user = _repository.Get(id);
            return View(user);
        }

        [AutoMap(typeof(User), typeof(UserViewModel))]
        public ActionResult Edit(int id)
        {
            // return an HTML form for editing a specific user
            var user = _repository.Get(id);
            return View(user);
        }

        [HttpPut]
        public ActionResult Update(UserViewModel userView)
        {
            // find and update a specific user
            if (!ModelState.IsValid)
            {
                return View("Edit", userView);
            }
            var user = (User)_userMapper.Map(userView, typeof(UserViewModel), typeof(User));
            _repository.Update(user);
            return RedirectToAction("Index", "Users");
        }

        [HttpDelete]
        public ActionResult Destroy(int id)
        {
            // delete a specific user
            _repository.Delete(id);
            return RedirectToAction("Index", "Users");
        }

    }
}

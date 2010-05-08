namespace SampleMvc.Web.Controllers
{
    using System.Web.Mvc;
    using SampleMvc.Web.Models;
    using System.Linq;

    [HandleError]
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            // return all users
            var users = new[]
            {
                new UserViewModel
                {
                    Id = 1,
                    FirstName = "first 1",
                    LastName = "last 1",
                    Age = 39
                }

            };
            return View(users);
        }

        public ActionResult New()
        {
            // return an HTML form for describing a new user
            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {
            // create a new user
            return View();
        }

        public ActionResult Show(int id)
        {
            // find and return a specific user
            var user = new UserViewModel
            {
                Id = id,
                FirstName = "first 1",
                LastName = "last 1",
                Age = 56
            };
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            // return an HTML form for editing a specific user
            return View();
        }

        [HttpPut]
        public ActionResult Update()
        {
            // find and update a specific user
            return View();
        }

        [HttpDelete]
        public ActionResult Destroy()
        {
            // delete a specific user
            return View();
        }

    }
}

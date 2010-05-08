namespace SampleMvc.Web.Controllers
{
    using System.Web.Mvc;
    using SampleMvc.Web.Models;

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
        public ActionResult Create(UserViewModel user)
        {
            // create a new user
            if (!ModelState.IsValid)
            {
                return View("New", user);
            }
            return RedirectToAction("Index");
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
            var user = new UserViewModel
            {
                Id = id,
                FirstName = "first 1",
                LastName = "last 1",
                Age = 56
            };
            return View(user);
        }

        [HttpPut]
        public ActionResult Update(UserViewModel user)
        {
            // find and update a specific user
            if (!ModelState.IsValid)
            {
                return View("Edit", user);
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Destroy(int id)
        {
            // delete a specific user
            return RedirectToAction("Index");
        }

    }
}

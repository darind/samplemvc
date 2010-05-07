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
            return View(Enumerable.Empty<UserViewModel>());
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
            return View();
        }

        public ActionResult Edit()
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

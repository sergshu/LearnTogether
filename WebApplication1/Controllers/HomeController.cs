using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View(new Models.TestModel());
        }

        [HttpPost]
        public ActionResult Test(Models.TestModel model)
        {
            model.Result = $"You entered text `{model.Text}`. Selected `{model.Selected}`";
            model.MyItems = new List<Models.MyItemModel> { new Models.MyItemModel { Id = 1, Name = "First", UserName = "User1" }, new Models.MyItemModel { Id = 2, Name = "Second", UserName = "User11" }, };
            return View(model);
        }

        public ActionResult TestItemView(int id)
        {
            return View(new Models.MyItemModel { Id = id, Name = "Model" + id, UserName = "User" + id });
        }

    }
}
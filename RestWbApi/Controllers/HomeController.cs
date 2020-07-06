using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api;
using api.Interfaces;
using model.Db;
using model.ViewModels;

namespace RestWbApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        

        public HomeController(IUserService userService)
        {
            _userService = userService;
            
            //_userService.AddUsers(_userService.FinalUsersInetList());   // add new users in table
        }

        //public HomeController() { }
        public ActionResult Index()
        {
            var model = _userService.GetUserInfo();
            return View("Index", model);
        }

        



        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}
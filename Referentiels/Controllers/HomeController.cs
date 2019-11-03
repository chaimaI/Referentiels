using BusinessContracts.Business.Contracts;
using BusinessDomain.Business.Domain.Models;
using Referentiels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Referentiels.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoginService _loginService;

        public HomeController(ILoginService loginService)
        {
            _loginService = loginService;



        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult loginPage()
        {
            return View();
        }
        [HttpPost]

        public ActionResult loginPage(LoginModel obj)
        {
            if(obj.username== null || obj.password== null)
            {
                ViewBag.Message = "";
            }
            else
            {
                
                List<Login> login = _loginService.Identification(obj.username, obj.password).ToList();
                Login lg = login.FirstOrDefault(x => x.username.Equals(obj.username) && x.password.Equals(obj.password));

                if (lg!=null)
                {
                    ViewBag.Message = "correct";

                }

                else
                {
                    ViewBag.Message = "incorrect";
                }
            }
            return View();
        }
    }
}
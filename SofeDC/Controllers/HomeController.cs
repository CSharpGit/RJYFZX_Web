using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SofeDC.Models;
using SoftDC.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SofeDC.Controllers
{
    public class HomeController : Controller
    {
        private readonly RjyfzxDbContext _context;

        public HomeController(RjyfzxDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string UserNum,string PassWord)
        {
            try
            {
                List<User> UserList= (from u in _context.Users where u.UserNum == UserNum select u).ToList();
                if (UserList.Count>0)
                {
                    if (UserList[0].PassWord!=PassWord)
                    {
                        var info = "用户密码错误，请重新输入！";
                        ViewData["info"] = info;
                    }
                    else
                    {
                        HttpContext.Session.SetString("UserID", UserList[0].UserNum);
                        return RedirectToRoute(new {area = "Adm",controller = "PersonalInformationManage", action = "Index",id= UserList[0].ID, num= UserList[0].UserNum });
                    }
                }
                else
                {
                    var info = "该用户不存在，请输入正确的学号！";
                    ViewData["info"] = info;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

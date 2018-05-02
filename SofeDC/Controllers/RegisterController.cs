using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SofeDC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SofeDC.Controllers
{
    public class RegisterController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            Registration model = new Registration();
            var roles = new[]
            {
                new SelectListItem { Value = "UI设计", Text="UI设计", Selected = false },
                new SelectListItem { Value = "CSharp", Text="CSharp",Selected = false },
                new SelectListItem { Value = "Android", Text="Android",Selected = false },
                new SelectListItem { Value = "PHP", Text="PHP", Selected = false },
                new SelectListItem { Value = "JSP", Text="JSP",Selected = false },
                new SelectListItem { Value = "Python", Text="Python",Selected = false },
                new SelectListItem { Value = "IOS", Text="IOS",Selected = false }
            };
            model.Intersts = roles;
            List<SelectListItem> UserLablelistItem = new List<SelectListItem>{
                new SelectListItem{Text="第一届",Value="第一届"},
                new SelectListItem{Text="第二届",Value="第二届"},
                new SelectListItem{Text="第三届",Value="第三届"},
                new SelectListItem{Text="第四届",Value="第四届"},
                new SelectListItem{Text="第五届",Value="第五届"},
                new SelectListItem{Text="第六届",Value="第六届"},
                new SelectListItem{Text="第七届",Value="第七届"},
                new SelectListItem{Text="第八届",Value="第八届"},
                new SelectListItem{Text="第九届",Value="第九届"},
                new SelectListItem{Text="第十届",Value="第十届"},
                new SelectListItem{Text="第十一届",Value="第十一届"},
                new SelectListItem{Text="第十二届",Value="第十二届"},
                new SelectListItem{Text="第十三届",Value="第十三届"},
            };
            ViewBag.List = new SelectList(UserLablelistItem, "Value", "Text", "");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(string[] Hobbies)
        {
            ViewBag.Hobbies = Hobbies;
            return View();
        }

        // GET: /HelloWorld/Welcome/ 
        //HtmlEncoder.Default.Encode防止恶意攻击，如JavaScript等
        public IActionResult Welcome(string Information, string RegisterName)
        {
            ViewData.Add("Information", Information);
            ViewData.Add("RegisterName", RegisterName);
            return View();
        }
    }
}

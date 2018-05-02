using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SoftDC.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SofeDC.Models;
using System.IO;
using System;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SofeDC.Areas.Adm.Controllers
{
    [Area("Adm")]
    public class PersonalInformationManageController : Controller
    {
        private readonly RjyfzxDbContext _context;

        public PersonalInformationManageController(RjyfzxDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(int id, string num)
        {
            if (!string.IsNullOrEmpty(num))
            {
                if (HttpContext.Session.GetString("UserID") != num)
                {
                    return RedirectToRoute(new { area = "", controller = "Home", action = "Login" });
                }
                try
                {
                    List<User> UserList1 = (from u in _context.Users where u.UserNum == num select u).ToList();
                    if (UserList1.Count > 0)
                    {
                        string usStatus = UserList1[0].UserStatus;
                        ViewBag.usStatus = usStatus;
                        string SeniorWorkType = UserList1[0].WorkType;
                        ViewBag.SeniorWorkType = SeniorWorkType;
                        if (UserList1[0].ID != id)
                        {
                            return RedirectToRoute(new { area = "", controller = "Home", action = "Login" });
                        }
                    }
                    else
                    {
                        return RedirectToRoute(new { area = "", controller = "Home", action = "Error" });
                    }
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
            else
            {
                return RedirectToRoute(new { area = "", controller = "Home", action = "Login" });
            }
            var UserList = from u in _context.Users where u.ID == id select u;
            return View(await UserList.ToListAsync());
        }

        public JsonResult UploadFile()
        {
            UploadResult result = new UploadResult();
            try
            {
                var oFile = Request.Form.Files["txt_file"];
                Stream sm = oFile.OpenReadStream();
                result.FileName = oFile.FileName;
                if (!Directory.Exists(AppContext.BaseDirectory + "/Image/"))
                {
                    Directory.CreateDirectory(AppContext.BaseDirectory + "/Image/");
                }
                string filename = AppContext.BaseDirectory + "/Image/" + DateTime.Now.ToString("yyyymmddhhMMssss") + Guid.NewGuid().ToString() + ".png";
                FileStream fs = new FileStream(filename, FileMode.Create);
                byte[] buffer = new byte[sm.Length];
                sm.Read(buffer, 0, buffer.Length);
                fs.Write(buffer, 0, buffer.Length);
                fs.Dispose();
            }
            catch (Exception ex)
            {
                result.Error = ex.Message;
            }
            return Json(result);
        }
        public class UploadResult
        {
            public string FileName { get; set; }
            public string Error { get; set; }
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }
    }
}

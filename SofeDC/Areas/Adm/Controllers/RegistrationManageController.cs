using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SofeDC.Models;
using SoftDC.Data;

namespace SofeDC.Areas.Adm.Controllers
{
    [Area("Adm")]
    public class RegistrationManageController : Controller
    {
        private readonly RjyfzxDbContext _context;

        public RegistrationManageController(RjyfzxDbContext context)
        {
            _context = context;
        }

        // GET: Adm/Registrations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registrations.ToListAsync());
        }

        // GET: Adm/Registrations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .SingleOrDefaultAsync(m => m.ID == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // GET: Adm/Registrations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adm/Registrations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserNum,UserName,UserSex,UserAcademy,UserClass,UserPhone,QQ,WeChat,UserEmail,UserLable")] Registration registration, string[] InterstAnrry)
        {
            if (ModelState.IsValid)
            {
                if (InterstAnrry != null)
                {
                    for (int i = 0; i < InterstAnrry.Length; i++)
                    {
                        registration.Interest+=InterstAnrry[i]+"|";
                    }
                }
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToRoute(new { controller = "Register", action = "Welcome", area = "", Information = "您的注册信息已提交，请耐心等待管理员审核！", RegisterName = registration.UserName });
            }
            return View(registration);
        }

        // GET: Adm/Registrations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations.SingleOrDefaultAsync(m => m.ID == id);
            if (registration == null)
            {
                return NotFound();
            }
            User model = new User
            {
                UserName = registration.UserName,
                PassWord = registration.UserNum,
                UserSex = registration.UserSex,
                UserNum = registration.UserNum,
                UserAcademy = registration.UserAcademy,
                UserClass = registration.UserClass,
                UserGroup = registration.Interest,
                UserEmail = registration.UserEmail,
                UserPhone = registration.UserPhone,
                QQ = registration.QQ,
                UserLable = registration.UserLable,
                WeChat = registration.WeChat
            };
            List<SelectListItem> UserPositionlistItem = new List<SelectListItem>{
                new SelectListItem{Text="无职位",Value="无职位"},
                new SelectListItem{Text="行政主管",Value="行政主管"},
                new SelectListItem{Text="技术主管",Value="技术主管"},
                new SelectListItem{Text="外联主管",Value="外联主管"},
                new SelectListItem{Text="项目经理",Value="项目经理"},
                new SelectListItem{Text="培训主管",Value="培训主管"},
                new SelectListItem{Text="行政部长",Value="行政部长"},
                new SelectListItem{Text="运维部长",Value="运维部长"},
                new SelectListItem{Text="外联部长",Value="外联部长"},
                new SelectListItem{Text="培训部长",Value="培训部长"},
                new SelectListItem{Text="研发部长",Value="研发部长"},
                new SelectListItem{Text="监察部长",Value="监察部长"},
                new SelectListItem{Text="CSharp组长",Value="CSharp组长"},
                new SelectListItem{Text="美工组长",Value="美工组长"},
                new SelectListItem{Text="Android组长",Value="Android组长"},
                new SelectListItem{Text="IOS组长",Value="IOS组长"},
                new SelectListItem{Text="Python组长",Value="Pyhton组长"},
                new SelectListItem{Text="PHP组长",Value="PHP组长"},
                new SelectListItem{Text="JSP组长",Value="JSP组长"}

            };
            ViewBag.UserPosition = new SelectList(UserPositionlistItem, "Value", "Text", "");

            List<SelectListItem> UserPositionType = new List<SelectListItem>{
                new SelectListItem{Text="无",Value="无"},
                new SelectListItem{Text="主管",Value="主管"},
                new SelectListItem{Text="部长",Value="部长"},
                new SelectListItem{Text="组长",Value="组长"}
            };
            ViewBag.UserPositionType = new SelectList(UserPositionType, "Value", "Text", "");

            List<SelectListItem> UserStatus = new List<SelectListItem>{
                new SelectListItem{Text="新生",Value="新生"},
                new SelectListItem{Text="核心成员",Value="核心成员"},
                new SelectListItem{Text="工作室成员",Value="工作室成员"},
                new SelectListItem{Text="毕业生",Value="毕业生"},
                new SelectListItem{Text="其它",Value="其它"}
            };
            ViewBag.UserStatus = new SelectList(UserStatus, "Value", "Text", "");
            return View(model);
        }


        // POST: Adm/Registrations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserNum,UserName,UserSex,UserAcademy,UserClass,UserPhone,QQ,WeChat,UserEmail,Interest,UserLable")] Registration registration)
        {
            if (id != registration.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrationExists(registration.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registration);
        }

        // GET: Adm/Registrations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registration = await _context.Registrations
                .SingleOrDefaultAsync(m => m.ID == id);
            if (registration == null)
            {
                return NotFound();
            }

            return View(registration);
        }

        // POST: Adm/Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registration = await _context.Registrations.SingleOrDefaultAsync(m => m.ID == id);
            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registrations.Any(e => e.ID == id);
        }
    }
}

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
    public class UserManageController : Controller
    {
        private readonly RjyfzxDbContext _context;

        public UserManageController(RjyfzxDbContext context)
        {
            _context = context;
        }

        // GET: Adm/UserManage
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Adm/UserManage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Adm/UserManage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adm/UserManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserNum,UserName,UserSex,PassWord,UserClass,UserAcademy,UserGroup,UserPhone,QQ,WeChat,UserEmail,UserPositionType,UserPosition,UserStatus,UserMaster,UserApprentice,UserLable")] User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var checkUserNum = await _context.Users.SingleOrDefaultAsync(m => m.UserNum == user.UserNum);
                    if (checkUserNum == null)
                    {
                        user.University = "北京大学";
                        user.Professional = "信息与计算科学";
                        user.WorkType = "工作";
                        user.WorkPlace = "北京XXX公司";
                        user.WorkPosition = "前端开发工程师";
                        user.Message = "高度发达放大飞洒似的士大夫首发式地方似的似的发射点发射点发发生发生地方是大师傅大师傅的非法上访的地方第三方的对方的感受地方公共给微软而体贴温柔额热热热二如题如题热热额二人台让人头人二人让他认为人人。而同为额。";


                        user.AddDate = DateTime.Now.Date;
                        _context.Add(user);
                        await _context.SaveChangesAsync();
                        return RedirectToRoute(new { controller = "RegistrationManage", action = "Delete", area = "Adm", id=user.ID });
                    }
                    else
                    {
                        
                    }
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return View(user);
        }

        // GET: Adm/UserManage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.SingleOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Adm/UserManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserNum,UserName,UserSex,PassWord,UserClass,UserAcademy,UserGroup,UserPhone,QQ,WeChat,UserEmail,UserPositionType,UserPosition,UserStatus,UserMaster,UserApprentice,UserLable")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID))
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
            return View(user);
        }

        // GET: Adm/UserManage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .SingleOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Adm/UserManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(m => m.ID == id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}

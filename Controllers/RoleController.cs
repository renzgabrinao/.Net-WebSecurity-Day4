using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication1.Data;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class RoleController : Controller
    {
        ApplicationDbContext _context;

        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Role
        public ActionResult Index(string msg)
        {
            if(msg == null)
            {
                msg = "";
            }

            ViewData["Message"] = msg;  

            RoleRepo roleRepo = new RoleRepo(_context);
            return View(roleRepo.GetAllRoles());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleVM newRole)
        {
            var token = HttpContext.Request.Form["__RequestVerificationToken"];
            string msg;
            RoleRepo roleRepo = new RoleRepo(_context);
            var results = roleRepo.CreateRole(newRole.RoleName);

            if (!results)
            {
                msg = "Creating role failed.";
            } else
            {
                msg = "Create role success!";
            }

            return RedirectToAction("Index", "Role", msg);
        }
    }

}

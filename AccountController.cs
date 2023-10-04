using Eshop.Data;
using Eshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class AccountController : Controller
    {
        private EshopContext _context;
        public AccountController(EshopContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            return View(_context.Accounts.ToList());
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = _context.Accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Username,Password,Email,Phone,Address,FullName,IsAdmin,Status")] Account account)
        {
            if (_context.Accounts.Any(a => a.Username == account.Username))
            {
                ViewBag.Error = "Tên đăng nhập đã tồn tại.";
                return View();
            }
            else
            {
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}

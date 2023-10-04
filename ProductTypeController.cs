using Eshop.Data;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Controllers
{
    public class ProductTypeController : Controller
    {
        private EshopContext _context;
        public ProductTypeController(EshopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lstPType = _context.ProductTypes.ToList();
            return View(lstPType);
        }
    }
}

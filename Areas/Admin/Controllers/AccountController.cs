using Microsoft.AspNetCore.Mvc;

namespace ShoppFood.Areas.Admin.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Mvc;

namespace BuildCompany.Contollers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
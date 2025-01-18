using BuildCompany.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildCompany.Contollers.Admin;

[Authorize(Roles = "admin")]
public partial class AdminController : Controller
{
    private readonly DataManager _dataManager;

    public AdminController(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    public IActionResult Index()
    {
        return View();
    }
}
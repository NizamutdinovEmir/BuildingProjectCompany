using BuildCompany.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildCompany.Contollers.Admin;

[Authorize(Roles = "admin")]
public partial class AdminController : Controller
{
    private readonly DataManager _dataManager;
    private readonly ILogger<AdminController> _logger;

    public AdminController(DataManager dataManager, IWebHostEnvironment hostEnvironment, ILogger<AdminController> logger)
    {
        _dataManager = dataManager;
        _hostEnvironment = hostEnvironment;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.ServiceCategories = await _dataManager.ServiceCategoriesRepository.GetServiceCategoriesAsync();
        ViewBag.Services = await _dataManager.ServicesRepository.GetServicesAsync();
        return View();
    }
}
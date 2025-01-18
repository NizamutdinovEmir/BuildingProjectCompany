using BuildCompany.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildCompany.Contollers.Admin;

[Authorize(Roles = "admin")]
public partial class AdminController : Controller
{
    private readonly DataManager _dataManager;

    public AdminController(DataManager dataManager, IWebHostEnvironment hostEnvironment)
    {
        _dataManager = dataManager;
        _hostEnvironment = hostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.ServiceCategories = await _dataManager.ServiceCategoriesRepository.GetServiceCategoriesAsync();
        ViewBag.Services = await _dataManager.ServicesRepository.GetServicesAsync();
        return View();
    }
}
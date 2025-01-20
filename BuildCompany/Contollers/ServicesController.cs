using BuildCompany.Domain;
using BuildCompany.Domain.Entities;
using BuildCompany.Infrastructure;
using BuildCompany.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildCompany.Contollers;

public class ServicesController : Controller
{
    private readonly DataManager _dataManager;

    public ServicesController(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    public async Task<IActionResult> Index()
    {
        IEnumerable<Service> list = await _dataManager.ServicesRepository.GetServicesAsync();

        IEnumerable<ServiceDTO> listDTO = HelperDTO.TransformServices(list);
        return View(listDTO);
    }

    public async Task<IActionResult> Show(int id)
    {
        Service? entity = await _dataManager.ServicesRepository.GetServicesByIdAsync(id);
        if (entity is null)
        {
            return NotFound();
        }

        ServiceDTO model = HelperDTO.TransformService(entity);

        return View(model);
    }
}
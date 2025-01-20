using BuildCompany.Domain;
using BuildCompany.Domain.Entities;
using BuildCompany.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BuildCompany.Models.Components;

public class MenuViewComponent : ViewComponent
{
    private readonly DataManager _dataManager;

    public MenuViewComponent(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        IEnumerable<Service> list = await _dataManager.ServicesRepository.GetServicesAsync();

        IEnumerable<ServiceDTO> listDTO = HelperDTO.TransformServices(list);

        return await Task.FromResult((IViewComponentResult)View("Default", listDTO));
    }
}
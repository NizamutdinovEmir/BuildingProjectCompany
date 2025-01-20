using BuildCompany.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildCompany.Contollers.Admin;

public partial class AdminController
{
    public async Task<IActionResult> ServicesEdit(int id)
    {
        Service? entity = id == default
            ? new Service()
            : await _dataManager.ServicesRepository.GetServicesByIdAsync(id);

        ViewBag.ServiceCategories = await _dataManager.ServiceCategoriesRepository.GetServiceCategoriesAsync();

        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> ServicesEdit(Service entity, IFormFile? titleImageFile)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.ServiceCategories = await _dataManager.ServiceCategoriesRepository.GetServiceCategoriesAsync();
            return View(entity);
        }

        if (titleImageFile != null)
        {
            entity.Photo = titleImageFile.FileName;
            await SaveImgAsync(titleImageFile);
        }

        await _dataManager.ServicesRepository.SaveServicesAsync(entity);
        _logger.LogInformation($"Добавлена/обновлена услуга с ID: {entity.Id}");

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ServicesDelete(int id)
    {
        await _dataManager.ServicesRepository.DeleteServicesByIdAsync(id);
        _logger.LogInformation($"Удалена услуга с ID: {id}");

        return RedirectToAction("Index");
    }
}
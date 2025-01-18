using BuildCompany.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildCompany.Contollers.Admin;

public partial class AdminController
{
    public async Task<IActionResult> ServiceCategoriesEdit(int id)
    {
        ServiceCategory? entity = id == default
            ? new ServiceCategory()
            : await _dataManager.ServiceCategoriesRepository.GetServiceCategoryByIdAsync(id);

        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> ServiceCategoriesEdit(ServiceCategory entity)
    {
        if (!ModelState.IsValid)
        {
            return View(entity);
        }

        await _dataManager.ServiceCategoriesRepository.SaveServiceCategoryAsync(entity);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ServiceCategoriesDelete(int id)
    {
        await _dataManager.ServiceCategoriesRepository.DeleteServiceCategoryByIdAsync(id);
        return RedirectToAction("Index");
    }
}
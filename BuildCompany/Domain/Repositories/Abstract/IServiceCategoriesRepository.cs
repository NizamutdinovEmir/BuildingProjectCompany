using BuildCompany.Domain.Entities;

namespace BuildCompany.Domain.Repositories.Abstract;

public interface IServiceCategoriesRepository
{
    Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync();

    Task<ServiceCategory?> GetServiceCategoryByIdAsync(int id);

    Task SaveServiceCategoryAsync(ServiceCategory entity);

    Task DeleteServiceCategoryByIdAsync(int id);
}
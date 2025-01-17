using BuildCompany.Domain.Entities;

namespace BuildCompany.Domain.Repositories.Abstract;

public interface IServicesRepository
{
    Task<IEnumerable<Service>> GetServicesAsync();

    Task<Service?> GetServicesByIdAsync(int id);

    Task SaveServicesAsync(Service entity);

    Task DeleteServicesByIdAsync(int id);
}

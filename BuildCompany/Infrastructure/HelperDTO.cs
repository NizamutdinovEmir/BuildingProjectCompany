using BuildCompany.Domain.Entities;
using BuildCompany.Models;

namespace BuildCompany.Infrastructure;

public static class HelperDTO
{
    // Service => ServiceDTO
    public static ServiceDTO TransformService(Service entity)
    {
        ServiceDTO entityDTO = new ServiceDTO();
        entityDTO.Id = entity.Id;
        entityDTO.CategoryName = entity.ServiceCategory?.Name;
        entityDTO.Title = entity.Name;
        entityDTO.DescriptionShort = entity.DescriptionShort;
        entityDTO.Description = entity.Description;
        entityDTO.PhotoFileName = entity.Photo;
        entityDTO.Type = entity.ServiceType.ToString();

        return entityDTO;
    }

    public static IEnumerable<ServiceDTO> TransformServices(IEnumerable<Service> services)
    {
        List<ServiceDTO> result = new List<ServiceDTO>();

        foreach (Service entity in services)
        {
            result.Add(TransformService(entity));
        }

        return result;
    }
}
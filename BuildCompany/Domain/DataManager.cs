using BuildCompany.Domain.Repositories.Abstract;

namespace BuildCompany.Domain;

public class DataManager
{
    public IServiceCategoriesRepository ServiceCategoriesRepository { get; set; }

    public IServicesRepository ServicesRepository { get; set; }

    public DataManager(IServiceCategoriesRepository serviceCategoriesRepository, IServicesRepository servicesRepository)
    {
        ServiceCategoriesRepository = serviceCategoriesRepository;
        ServicesRepository = servicesRepository;
    }
}
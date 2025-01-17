using BuildCompany.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BuildCompany.Domain.Entities;

public class Service : EntityBase
{
    [Display(Name = "Выберите категорию")]
    public int? ServiceCategoryId { get; set; }

    public ServiceCategory? ServiceCategory { get; set; }

    [Display(Name = "Краткое описание")]
    [MaxLength(3_000)]
    public string? DescriptionShort { get; set; }

    [Display(Name = "Описание")]
    [MaxLength(100_000)]
    public string? Description { get; set; }

    [Display(Name = "Титульная картина")]
    [MaxLength(100_000)]
    public string? Photo { get; set; }

    [Display(Name = "Тип услуги")]
    public ServiceTypeEnum? ServiceType { get; set; }
}
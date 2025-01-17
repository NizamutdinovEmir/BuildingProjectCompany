using System.ComponentModel.DataAnnotations;

namespace BuildCompany.Domain.Entities;

public abstract class EntityBase
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Заполните название")]
    [Display(Name = "Название")]
    [MaxLength(200)]
    public string? Name { get; set; }

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
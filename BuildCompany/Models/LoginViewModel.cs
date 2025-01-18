using System.ComponentModel.DataAnnotations;

namespace BuildCompany.Models;

public class LoginViewModel
{
    [Required]
    [Display(Name = "Login")]
    public string? UserName { get; set; }

    [Required]
    [UIHint("password")]
    [Display(Name = "Password")]
    public string? Password { get; set; }

    [Display(Name = "Запомнить пароль?")]
    public bool RememberMe { get; set; }
}
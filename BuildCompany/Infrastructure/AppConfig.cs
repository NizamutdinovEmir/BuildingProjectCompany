namespace BuildCompany.Infrastructure;

internal class AppConfig
{
    public TinyMCE TinyMCE { get; set; } = new TinyMCE();

    public Company Company { get; set; } = new Company();
}
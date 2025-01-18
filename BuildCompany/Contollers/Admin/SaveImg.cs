using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace BuildCompany.Contollers.Admin;

[Authorize(Roles = "admin")]
public partial class AdminController
{
    private readonly IWebHostEnvironment _hostEnvironment;

    public async Task<string> SaveImgAsync(IFormFile img)
    {
        string path = Path.Combine(_hostEnvironment.WebRootPath, "img/", img.FileName);
        await using FileStream stream = new FileStream(path, FileMode.Create);
        await img.CopyToAsync(stream);

        return path;
    }

    public async Task<string> SaveEditorImg()
    {
        IFormFile img = Request.Form.Files[0];
        await SaveImgAsync(img);

        return JsonSerializer.Serialize(new { location = Path.Combine("/img/", img.FileName) });
    }
}
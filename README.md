<div align="center">
   <h1>AspNetCore.FileService</h1>
    <p>An Asp.net core service for manage file and directory. 🗂️</p
    <p>
        <a href="https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-3.1" target="_blank"><img src="https://badgen.net/badge/.net core/v3.1/purple"/></a>
        <a href="https://www.nuget.org/packages/AspNetCore.FileService" target="_blank"><img src="https://badgen.net/nuget/v/AspNetCore.FileService/latest"/></a>
        <a href="https://www.nuget.org/packages/AspNetCore.FileService" target="_blank"><img src="https://img.shields.io/nuget/dt/AspNetCore.FileService"/></a>
   </p>
</div>

## How to use?
At first you must add this service on `Startup.cs -> ConfigureServices()`
```
using AspNetCore.FileServices;
```
```
services.AddFileServices();
```

Then inject `IFileService`
```
private readonly IFileService fileService;
```
Use CopyToPath method:
```
fileService.CopyToPath(FILE , PATH);
```

e.g. On your controller:
```
[HttpGet]
public IActionResult Test([FromForm] IFormFile file)
{
    if (file != null)
    {
        fileService.CopyToPath(file, Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"));
        return Ok();
    }
    return BadRequest();
}
```
## Latest version changes?
```
3.1.0 -> CopyToPath(FILE, PATH)
```
```
3.1.1 -> DeleteFromPath(FULL_PATH)
```

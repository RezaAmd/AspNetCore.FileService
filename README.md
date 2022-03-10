# AspNetCore.FileService
An Asp.net core service for manage file on directory.

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

using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Migration.Models;
using Application.Commands;

namespace Migration.Controllers
{
    public class FileController : BaseApiController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] Models.FileModel file)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string path = "";
            path = Path.Combine(webRootPath, "Images", "UploadedFile");

            var guid = Guid.NewGuid().ToString();
            string fileName = guid + Path.GetExtension(file.File.FileName);
            var fileFullPath = Path.Combine(path, fileName);
            using var output = System.IO.File.Create(fileFullPath);
            await file.File.CopyToAsync(output);

            CreateFileCommand command = new CreateFileCommand();
            command.UserId = file.UserId;
            command.FileName = fileName;
            var result =  await mediator.Send(command);

             return Ok(result);

        }

    }
}

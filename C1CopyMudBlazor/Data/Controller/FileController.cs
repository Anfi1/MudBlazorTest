using System.Net;
using C1CopyMudBlazor.Data.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace C1CopyMudBlazor.Pages.Controller;

    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly FileService _fileService;
        private IWebHostEnvironment Environment;

        public FileController(FileService fileService)
        {
            _fileService = fileService;
        }

        // download file(s) to client according path: rootDirectory/subDirectory with single zip file
        [HttpGet("Download/{subDirectory}/{fileName}")]
        public IActionResult DownloadFiles(string subDirectory, string fileName)
        {
            try
            {
                //var (fileType, archiveData, archiveName) = _fileService.FetechFiles(subDirectory);
                //return File(archiveData, fileType, archiveName);
                string localFilePath;

                localFilePath = Path.Combine("wwwroot/Legal", subDirectory, fileName);

                byte[] data;
                MemoryStream content;
                using (var net = new WebClient())
                {
                    net.DownloadFileCompleted   += (s, e) => Console.WriteLine("Download file completed.");
                    net.DownloadProgressChanged += (s, e) => Console.WriteLine($"Downloading {e.ProgressPercentage}%");
                    data = net.DownloadData(localFilePath);
                    content = new MemoryStream(data);
                }
                var contentType = "APPLICATION/octet-stream";
                Console.WriteLine("Файл скачан " + localFilePath);
                return File(content, contentType, fileName);
            }
            catch (Exception exception)
            {
                //return BadRequest($"Error: {exception.Message}");
                return null;
            }
        }
        
        // upload file(s) to server that palce under path: rootDirectory/subDirectory
        [HttpPost("upload")]
        public IActionResult UploadFile([FromForm(Name = "files")] List<IFormFile> files, string subDirectory)
        {
            try
            {
                _fileService.SaveFile(files, subDirectory);

                return Ok(new { files.Count, Size = FileService.SizeConverter(files.Sum(f => f.Length)) });
            }
            catch (Exception exception)
            {
                return BadRequest($"Error: {exception.Message}");
            }
        }
    }


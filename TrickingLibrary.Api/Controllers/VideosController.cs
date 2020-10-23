using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace TrickingLibrary.Api.Controllers
{
    [Route("api/videos")]
    public class VideosController:ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public VideosController(IWebHostEnvironment env)
        {
            _env=env;
        }

        [HttpPost]
        public async Task<IActionResult> UploadVideo(IFormFile video)
        {
            var mime = video.FileName.Split('.').Last();
            var FileName = string.Concat(Path.GetRandomFileName(),".",mime);
            var savePath = Path.Combine(_env.WebRootPath,Path.GetRandomFileName());

            await using (var fileStream = new FileStream(savePath,FileMode.Create,FileAccess.Write))
            {
                await video.CopyToAsync(fileStream);
            }


            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetApi.Controllers
{
    [EnableCors("allowsAll")]
    [Route("[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] ImageType data)
        {
            return Ok();
        }
    }

    public class ImageType
    {
        public IFormFile Image { get; set; }
    }
}
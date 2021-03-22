using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GravityCodeChallenge.Models;
using GravityCodeChallenge.Services.FileService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GravityCodeChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileservice) {
            _fileService = fileservice;
        }

        [Route("ProcessFile")]
        [HttpPost, DisableRequestSizeLimit]
        public List<DriverReport> ProcessFile( List<IFormFile> files)
        {
            try {
                var file = Request.Form.Files[0];
                var res = _fileService.ProcessFile(file);
                return res;
            }
            catch(Exception ex)
            {
                //log exception
                return null;
            }
        }
    }
}

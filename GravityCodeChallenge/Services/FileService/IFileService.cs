using GravityCodeChallenge.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityCodeChallenge.Services.FileService
{
    public interface IFileService
    {
        List<DriverReport> ProcessFile(IFormFile file);
    }
}

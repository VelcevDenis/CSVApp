using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CSVApp.Application.Contexts.Upload.Queries.UploadCSVFile;
using CSVApp.Contract.Entity;
using CSVApp.DAL;
using EFCore.BulkExtensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace CSVApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase {

        private readonly ApplicationDbContext _context;

        public UploadController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 4294967295)]
        [RequestSizeLimit(4294967295)]
        [Route("UploadCSVFile")]

        //POST : /api/Upload/UploadCSVFile
        public IActionResult UploadCSVFile([FromQuery] IFormFile file) {
            var uploadCSVFil = new UploadCSVFileQuery(_context);
            return Ok(uploadCSVFil.UploadCSVFile(file));
        }
    }
}
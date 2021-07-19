using System;
using System.IO;
using System.Linq;
using BLL;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Server.Controllers
{
    [Route("api/backups")]
    [ApiController]
    public class BackupController : ControllerBase
    {
        private readonly BackupService _adminService;

        public BackupController(BackupService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult GetBackups()
        {
            return Ok(_adminService.GetBackups());
        }

        [HttpPost]
        public IActionResult Backup()
        {
            _adminService.CreateBackupDatabase();

            return Ok();
        }

        [HttpPost("restore/{backupName}")]
        public IActionResult Restore(string backupName)
        {
            _adminService.RestoreDatabase(backupName);

            return Ok();
        }
    }
}

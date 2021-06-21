using System;
using System.IO;
using System.Linq;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace Server.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly Lazy<ApplicationDbContext> _context;
        private readonly IHostEnvironment _environment;

        private readonly string _backupsPath;

        public AdminsController(Lazy<ApplicationDbContext> context,
            IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _backupsPath = Path.Combine(_environment.ContentRootPath, "backups");
        }

        [HttpGet("backups")]
        public IActionResult GetBackups()
        {
            var a = Directory.GetFiles(_backupsPath, "*.bak").Select(Path.GetFileName);
            return Ok(a);
        }

        [HttpPost("backup")]
        public IActionResult Backup()
        {
            var bkpDbFull = new Backup
            {
                Database = _context.Value.Database.GetDbConnection().Database,
                Action = BackupActionType.Database,
                ExpirationDate = DateTime.Today.AddDays(10),
                Initialize = false,
                NoRecovery = false
            };
            bkpDbFull.Devices.AddDevice(Path.Combine(_backupsPath, $"{bkpDbFull.Database}-{DateTime.Now.Ticks}.bak"), DeviceType.File);

            bkpDbFull.SqlBackup(new Microsoft.SqlServer.Management.Smo.Server(new ServerConnection(new SqlConnection(_context.Value.Database.GetConnectionString()))));

            return Ok();
        }

        [HttpPost("restore/{backupName}")]
        public IActionResult Restore(string backupName)
        {
            var server = new Microsoft.SqlServer.Management.Smo.Server("localhost");
            server.ConnectionContext.LoginSecure = true;
            server.ConnectionContext.Connect();

            var restoreDB = new Restore
            {
                Database = "PayAndGive",
                Action = RestoreActionType.Database,
                ReplaceDatabase = true,
                NoRecovery = false
            };
            restoreDB.Devices.AddDevice(Path.Combine(_backupsPath, backupName), DeviceType.File);

            restoreDB.Information += (sender, args) => Console.WriteLine($"Information: {args.Error}");
            restoreDB.PercentComplete += (sender, args) => Console.WriteLine($"Complete: {args.Percent}. Message: {args.Message}");
            restoreDB.Complete += (sender, args) =>
            {
                Console.WriteLine($"Completed! Error: {args.Error}");
                server.ConnectionContext.Disconnect();
            };

            restoreDB.SqlRestore(server);

            return Ok();
        }

        [HttpGet("backup-database")]
        public IActionResult BackupDatabase()
        {
            var connectionString = "Server=localhost;Database=PayAndGive;Trusted_Connection=True;";
            var backupScript = @"backup database PayAndGive to disk = 'C:\Users\DuckKick\Desktop\SQLBackUpFolder\PayAndGiveFile.bak'";

            string backupDestination = @"C:\Users\DuckKick\Desktop\SQLBackUpFolder";
            // check if backup folder exist, otherwise create it.
            if (!System.IO.Directory.Exists(backupDestination))
            {
                System.IO.Directory.CreateDirectory(@"C:\Users\DuckKick\Desktop\SQLBackUpFolder");
            }

            using (var connection = new SqlConnection(connectionString))
            {
                var cmd = new SqlCommand(backupScript, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

            return Ok();
        }
    }
}

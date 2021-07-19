using DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL
{
    public class BackupService
    {
        private readonly string _backupsPath;
        private readonly Lazy<ApplicationDbContext> _context;

        public BackupService(IHostEnvironment environment,
            Lazy<ApplicationDbContext> contex)
        {
            _backupsPath = Path.Combine(environment.ContentRootPath, "backups");
            _context = contex;
        }
        public IEnumerable<string> GetBackups()
        {
            return Directory.GetFiles(_backupsPath, "*.bak").Select(Path.GetFileName);
        }
        public void CreateBackupDatabase()
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

            bkpDbFull.SqlBackup(new Server(new ServerConnection(new SqlConnection(_context.Value.Database.GetConnectionString()))));
        }
        public void RestoreDatabase(string backupName)
        {
            var server = new Server("localhost");
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
        }
    }
}

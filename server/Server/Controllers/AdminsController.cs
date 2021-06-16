using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
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

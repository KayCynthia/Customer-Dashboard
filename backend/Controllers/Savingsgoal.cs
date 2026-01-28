using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceBackend.Data;
using System.Linq;

namespace FinanceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SavingsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Progress")]
        public ActionResult GetSavingsProgress()
        {
            
            var sql = @"
                SELECT 
                    (SELECT TOP 1 aim FROM Savingsgoals) AS Goal,
                    (SELECT TOP 1 savingstarget FROM Savingsgoals) AS target,
                    (SELECT ISNULL(SUM(savings), 0) FROM Transactions) AS current,
                    (
                        SELECT CASE 
                            WHEN (SELECT TOP 1 savingstarget FROM Savingsgoals) > 0 
                            THEN ( (SELECT ISNULL(SUM(savings), 0) FROM Transactions) / (SELECT TOP 1 savingstarget FROM Savingsgoals) ) * 100
                            ELSE 0 
                        END
                    ) AS percentage";

            var result = _context.Database
                .SqlQueryRaw<SavingsProgressResult>(sql)
                .ToList()
                .FirstOrDefault();

            if (result == null)
            {
                return Ok(new { Message = "No savings goal found." });
            }

            return Ok(result);
        }
    }

    // This class maps the SQL result to your frontend-friendly names
    public class SavingsProgressResult
    {
        public string Goal { get; set; }=string.Empty;
        public decimal target { get; set; }
        public decimal current { get; set; }
        public decimal percentage { get; set; }
    }
}
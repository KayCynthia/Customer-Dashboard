using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceBackend.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace FinanceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("DonutData")]
        public ActionResult GetDonutData()
        {
            var sql = "SELECT category AS Label, SUM(Amount) AS Total FROM Transactions GROUP BY Category";
            
            var result = _context.Database
                .SqlQueryRaw<DonutResult>(sql)
                .ToList();

            return Ok(result);
        }
        [HttpGet("Summarycards")]
        public ActionResult GetSummarycards()
        {
            var sql =@"SELECT 
            Sum(CASE WHEN type='Income' THEN Amount Else 0 End) as Income,
            SUM(CASE WHEN type='Expense'THEN Amount Else 0 End)as Expense
            From Transaction";

            var resultcard = _context.Database
            .SqlQueryRaw<CardResult>(sql)
            .ToList();
            return Ok(resultcard);
        }

        [HttpGet("Linechart")]

        public ActionResult GETLinechart()
        {
            var sql =@"select
            Month As Month,
            Sum (Case when type='Income' Then Amount else 0 End) As TotalIncome,
            Sum (Case when type='Expense' Then Amount else 0 End) As totalExpense,
            Groupby Month,
            Orderby Month asc";

            var lineresults = _context.Database
            .SqlQueryRaw<LinechartResult>(sql)
            .ToList();
            return Ok(lineresults);
        }
    }

    public class LinechartResult
    {
        public string Month {get;set;} =string.Empty;
        public decimal TotalIncome {get; set;}
        public decimal totalExpense {get; set;}
    }
    public class CardResult
    {
        public decimal Income {get; set;}
        public decimal Expense{get; set;}
    }
    public class DonutResult
    {
        public string Label { get; set; }=string.Empty;
        public decimal Total { get; set; }
    }
}
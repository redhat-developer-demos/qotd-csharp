using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace qotd_csharp.Controllers
{
    [ApiController]
    [Route("/")]
    public class QuoteController : ControllerBase
    {

        private readonly ILogger<QuoteController> _logger;


        public QuoteController(ILogger<QuoteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Index() {
            return "qotd microservice. Check out the code at: https://github.com/donschenck/qotd-csharp";
        }

        [HttpGet("quotes")]
        public List<Quote> AllQuotes() {
            // Get all quotes from database

            return GetQuotesAsync().Result;
        }
                

        [HttpGet("quotes/{quoteId}")]
        public Quote OneQuote(int quoteId) {
            return GetQuoteByIdAsync(quoteId).Result;
        }

        [HttpGet("quotes/random")]
        public Quote Random() {
            return GetRandomQuoteAsync().Result;
        }

        [HttpGet("version")]
        public string Version() {
            return "4.0.0";
        }

        [HttpGet("writtenin")]
        public string WrittenIn() {
            return "C#";
        }

        private async Task<List<Quote>> GetQuotesAsync() {
            // Get all quotes from database
            string sqlStatement = "SELECT id, quotation, author FROM quotes ORDER BY id";
            string MySqlConnectionString = "Server=mysql;User ID=root;Password=admin;Database=quotesdb;";

            using var connection = new MySqlConnection(MySqlConnectionString);
            await connection.OpenAsync();

            var quoteList = new List<Quote>();

            using var command = new MySqlCommand(sqlStatement, connection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var q = new Quote();
                q.Quotation = reader["quotation"].ToString();
                q.Author = reader["author"].ToString();
                q.Id = Convert.ToInt32(reader["Id"]);

                quoteList.Add(q);           
             }
            return quoteList;
        }

        private async Task<Quote> GetQuoteByIdAsync(int theId) {
            // Get one quote from database
            string sqlStatement = String.Format("SELECT id, quotation, author FROM quotes WHERE id = {0}",theId);
            string MySqlConnectionString = "Server=mysql;User ID=root;Password=admin;Database=quotesdb;";

            using var connection = new MySqlConnection(MySqlConnectionString);
            await connection.OpenAsync();

            var quoteList = new List<Quote>();

            using var command = new MySqlCommand(sqlStatement, connection);
            using var reader = await command.ExecuteReaderAsync();
            var q = new Quote();
            while (await reader.ReadAsync())
            {
                q.Quotation = reader["quotation"].ToString();
                q.Author = reader["author"].ToString();
                q.Id = Convert.ToInt32(reader["Id"]);
             }
            return q;
        }

        private async Task<Quote> GetRandomQuoteAsync() {
            // Get one RANDOM quote from database
            string sqlStatement = String.Format("SELECT id, quotation, author FROM quotes ORDER BY RAND() LIMIT 1");
            string MySqlConnectionString = "Server=mysql;User ID=root;Password=admin;Database=quotesdb;";

            using var connection = new MySqlConnection(MySqlConnectionString);
            await connection.OpenAsync();

            var quoteList = new List<Quote>();

            using var command = new MySqlCommand(sqlStatement, connection);
            using var reader = await command.ExecuteReaderAsync();
            var q = new Quote();
            while (await reader.ReadAsync())
            {
                q.Quotation = reader["quotation"].ToString();
                q.Author = reader["author"].ToString();
                q.Id = Convert.ToInt32(reader["Id"]);
             }
            return q;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace qotd_csharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly ILogger<QuoteController> _logger;

        public QuoteController(ILogger<QuoteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Quote Get()
        {
            //var rng = new Random();
            return new Quote
            {
                QuoteText = "FOO",
                Author = "I. Said This"
            };
        }
    }
}

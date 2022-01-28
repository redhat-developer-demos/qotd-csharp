using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace qotd_csharp.Controllers
{
    [ApiController]
    [Route("/")]
    public class QuoteController : ControllerBase
    {

        private readonly ILogger<QuoteController> _logger;


        private Quote[] _quotes() {
            Quote[] q = new Quote[12];
            q[0] = new Quote {Id = 0, Quotation = "I got a fever, and the only prescription is more cowbell!", Author = "Will Ferrell"};
            q[1] = new Quote{Id = 1, Quotation ="Knowledge is power.", Author ="Francis Bacon"};
            q[2] = new Quote{Id = 2, Quotation = "Life is really simple, but we insist on making it complicated.", Author = "Confucius"};
	        q[3] = new Quote{Id = 3, Quotation = "This above all, to thine own self be true.", Author = "William Shakespeare"};
	        q[4] = new Quote{Id = 4, Quotation = "Never complain. Never explain.", Author = "Katharine Hepburn"};
	        q[5] = new Quote{Id = 5, Quotation = "Do be do be dooo.", Author = "Frank Sinatra"};
            q[6] = new Quote {Id = 0, Quotation = "It's time to start living the life you've imagined.", Author = "Henry James"};
            q[7] = new Quote{Id = 1, Quotation ="Courage is grace under pressure.", Author ="Ernest Hemingway"};
            q[8] = new Quote{Id = 2, Quotation = "Either you run the day or the day runs you.", Author = "Jim Rohn"};
	        q[9] = new Quote{Id = 3, Quotation = "Exercise is to the body as reading is to your mind.", Author = "Joseph Addison"};
	        q[10] = new Quote{Id = 4, Quotation = "The universe rearranges itself to accommodate your picture of reality.", Author = "Unknown"};
	        q[11] = new Quote{Id = 5, Quotation = "All our dreams can come true, if we have the courage to pursue them.", Author = "Walt Disney"};

            return q;
        }

        public QuoteController(ILogger<QuoteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Index() {
            return "qotd microservice. Check out the code at: https://github.com/donschenck/qotd-csharp";
        }

        [HttpGet("quotes")]
        public Quote[] AllQuotes() {
            return _quotes();
        }

        [HttpGet("quotes/{quoteId}")]
        public Quote OneQuote(int quoteId) {
            return _quotes()[quoteId];
        }

        [HttpGet("quotes/random")]
        public Quote Random() {
            Random r = new Random();
            int i = r.Next(_quotes().Length);
            return _quotes()[i];
        }

        [HttpGet("version")]
        public string Version() {
            return "2.0.0";
        }

        [HttpGet("writtenin")]
        public string WrittenIn() {
            return "C#";
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SerilogDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("You Requested the Index Page");

            try
            {
                for (int i = 0; i <= 10; i++)
                {
                    if (i == 5)
                    {
                        throw new Exception("Demo Exception");
                    }
                    else
                    {
                        _logger.LogInformation("Value of i {LoopCounterValue}", i);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, " Custom Exception Caught");
            }
        }
    }
}

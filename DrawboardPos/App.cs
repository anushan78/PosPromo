using DrawboardPos.Services;
using Microsoft.Extensions.Logging;
using System;

namespace DrawboardPos
{
    /// <summary>
    /// This class defines the entry point to the Pos price processing application.
    /// </summary>
    public class App
    {
        private readonly IPosService _posService;
        private readonly ILogger _logger;

        public App(IPosService posService, ILogger<App> logger)
        {
            _posService = posService;
            _logger = logger;
        }

        public void Run(string products)
        {
            try
            {
                var totalPrice = _posService.Process(products);

                if (totalPrice != null)
                {
                    Console.WriteLine($"The total is: ${totalPrice}");
                    _logger.LogInformation($"Successfully process products {products}");
                }
                else
                {
                    Console.WriteLine("Please enter valid product list");
                }

                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in processing products. Please try again later");
                _logger.LogError($"Error Details: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}

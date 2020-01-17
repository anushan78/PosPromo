using DrawboardPos.Interfaces;
using DrawboardPos.Processors;
using DrawboardPos.Services;
using DrawboardPos.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DrawboardPos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure Pos Terminal
            // Create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            Console.WriteLine("Please Enter the codes of the requested products");
            var productString = Console.ReadLine();

            // Entry to run our csv processor service
            serviceProvider.GetService<App>().Run(productString);
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Setup prices
            var productSet = new Tuple<Apple, Biscuit, Cheese, DairyMilk>(
                ProductHelper.AppleProduct, ProductHelper.BiscuitProduct, 
                ProductHelper.CheeseProduct, ProductHelper.DairyMilkProduct);
            var portfolio = new ProductPortfolio<Tuple<Apple, Biscuit, Cheese, DairyMilk>>();
            portfolio.Grocery = productSet;

            // Inserts services into service collection
            serviceCollection.AddSingleton<IPosService>(service => new PosService(portfolio,
                service.GetService<IPromoProcessor<Apple>>(), service.GetService<IPromoProcessor<Biscuit>>(),
                service.GetService<IPromoProcessor<Cheese>>(), service.GetService<IPromoProcessor<DairyMilk>>()));
            serviceCollection.AddSingleton<IPromoProcessor<Apple>, ApplePromoProcessor>();
            serviceCollection.AddSingleton<IPromoProcessor<Biscuit>, BiscuitPromoProcessor>();
            serviceCollection.AddSingleton<IPromoProcessor<Cheese>, CheesePromoProcessor>();
            serviceCollection.AddSingleton<IPromoProcessor<DairyMilk>, DairyMilkPromoProcessor>();

            // Register logging for the app
            serviceCollection.AddLogging(configure => configure.AddConsole())
                .AddTransient<PosService>();

            // Includes the app.
            serviceCollection.AddTransient<App>();
        }
    }
}

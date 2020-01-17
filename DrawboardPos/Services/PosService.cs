using DrawboardPos.Interfaces;
using DrawboardPos.Types;
using System;
using System.Linq;

namespace DrawboardPos.Services
{
    /// <summary>
    /// Implements processing routines for generating Pos price related information. 
    /// </summary>
    public class PosService : IPosService
    {
        private ProductPortfolio<Tuple<Apple, Biscuit, Cheese, DairyMilk>> _portfolio;
        private IPromoProcessor<Apple> _applePromoProcessor;
        private IPromoProcessor<Biscuit> _biscuitPromoProcessor;
        private IPromoProcessor<Cheese> _cheesePromoProcessor;
        private IPromoProcessor<DairyMilk> _dairyPromoProcessor;

        /// <summary>
        /// Constructor for Pos service.
        /// </summary>
        /// <param name="portfolio">Prodcut portfolio.</param>
        /// <param name="applePromoProcessor">Apple promo processor.</param>
        /// <param name="biscuitPromoProcessor">Biscuit promo processor.</param>
        /// <param name="cheesePromoProcessor">Cheese promo processor.</param>
        /// <param name="dairyPromoProcessor">DairyMilk promo processor.</param>
        public PosService(ProductPortfolio<Tuple<Apple, Biscuit, Cheese, DairyMilk>> portfolio,
            IPromoProcessor<Apple> applePromoProcessor, IPromoProcessor<Biscuit> biscuitPromoProcessor,
            IPromoProcessor<Cheese> cheesePromoProcessor, IPromoProcessor<DairyMilk> dairyPromoProcessor)
        {
            _portfolio = portfolio;
            _applePromoProcessor = applePromoProcessor;
            _biscuitPromoProcessor = biscuitPromoProcessor;
            _cheesePromoProcessor = cheesePromoProcessor;
            _dairyPromoProcessor = dairyPromoProcessor;
        }
        
        /// <summary>
        /// Process the products in the specified products input and return the total of them
        /// with promo applied.
        /// </summary>
        /// <param name="products">Products codes combined string.</param>
        /// <returns>Total Price for the specified products.</returns>
        public double? Process(string products)
        {
            var productCount = 0;
            double grandTotal = 0;

            // Return nothing for invalid products string.
            if (string.IsNullOrWhiteSpace(products)) return null;

            var productCodesList = products.ToCharArray().OrderBy(code => code).ToList();

            productCodesList.Distinct().ToList().ForEach((code) =>
            {
                productCount = productCodesList.FindAll(item => item == code).Count;
                grandTotal += GetProductTotalPrice(code, productCount);
            });

            return grandTotal;
        }

        /// <summary>
        /// Process the promotion for the specified product code.
        /// </summary>
        /// <param name="productCode">Product Code.</param>
        /// <param name="productCount">Number of items for this product code.</param>
        /// <returns>Total price for specified product code.</returns>
        private double GetProductTotalPrice(char productCode, int productCount)
        {
            double productTotal = 0;

            switch (productCode)
            {
                case 'A':
                    productTotal = _portfolio.Grocery.Item1.HasPromoApplied
                        ? _applePromoProcessor.Apply(productCount, _portfolio.Grocery.Item1.UnitPrice)
                        : productCount * _portfolio.Grocery.Item1.UnitPrice;
                    break;
                case 'B':
                    productTotal = _portfolio.Grocery.Item2.HasPromoApplied
                        ? _biscuitPromoProcessor.Apply(productCount, _portfolio.Grocery.Item2.UnitPrice)
                        : productCount * _portfolio.Grocery.Item2.UnitPrice;
                    break;
                case 'C':
                    productTotal = _portfolio.Grocery.Item3.HasPromoApplied
                        ? _cheesePromoProcessor.Apply(productCount, _portfolio.Grocery.Item3.UnitPrice)
                        : productCount * _portfolio.Grocery.Item3.UnitPrice;
                    break;
                case 'D':
                    productTotal = _portfolio.Grocery.Item4.HasPromoApplied
                        ? _dairyPromoProcessor.Apply(productCount, _portfolio.Grocery.Item4.UnitPrice)
                        : productCount * _portfolio.Grocery.Item4.UnitPrice;
                    break;
            }

            return productTotal;
        }
    }
}

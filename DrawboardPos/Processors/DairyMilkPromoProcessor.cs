using DrawboardPos.Interfaces;
using DrawboardPos.Types;
using System;

namespace DrawboardPos.Processors
{
    /// <summary>
    /// Promotion processor for dairy milk product.
    /// </summary>
    public class DairyMilkPromoProcessor : IPromoProcessor<DairyMilk>
    {
        /// <summary>
        /// Calculates the total price by applying the specified price over the count.
        /// This will define the logics for the specific promotion.
        /// </summary>
        /// <param name="unitCount">Number of items.</param>
        /// <param name="unitPrice">Price per unit.</param>
        /// <returns>Total for the product specified.</returns>
        public double Apply(int unitCount, double unitPrice)
        {
            throw new NotImplementedException();
        }
    }
}

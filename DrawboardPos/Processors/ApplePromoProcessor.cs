using DrawboardPos.Interfaces;
using DrawboardPos.Types;

namespace DrawboardPos.Processors
{
    /// <summary>
    /// Promotion processor for apple product.
    /// </summary>
    public class ApplePromoProcessor : IPromoProcessor<Apple>
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
            return (unitCount >= 3)
                ? ((unitCount / 3) * 3) + ((unitCount % 3) * unitPrice)
                : unitCount * unitPrice;
        }
    }
}

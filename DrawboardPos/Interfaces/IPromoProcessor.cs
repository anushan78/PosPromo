namespace DrawboardPos.Interfaces
{
    /// <summary>
    /// Defines routines to be implemented by any prospective promo processor.
    /// </summary>
    /// <typeparam name="T">Product object.</typeparam>
    public interface IPromoProcessor<T> where T : IGroceryItem
    {
        /// <summary>
        /// Calculates the total price by applying the specified price over the count.
        /// This will define the logics for the specific promotion.
        /// </summary>
        /// <param name="unitCount">Number of items.</param>
        /// <param name="unitPrice">Price per unit.</param>
        /// <returns>Total for the product specified.</returns>
        double Apply(int unitCount, double unitPrice);
    }
}

namespace DrawboardPos.Services
{
    /// <summary>
    /// Defines the price processing methods for the pos.
    /// </summary>
    public interface IPosService
    {
        /// <summary>
        /// Process the products in the specified products input and return the total of them
        /// with promo applied.
        /// </summary>
        /// <param name="products">Products codes combined string.</param>
        /// <returns>Total Price for the specified products.</returns>
        double? Process(string products);
    }
}

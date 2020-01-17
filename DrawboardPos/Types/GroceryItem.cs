namespace DrawboardPos.Types
{
    /// <summary>
    /// Base Product item for grocery item.
    /// </summary>
    public abstract class GroceryItem
    {
        /// <summary>
        /// Product Code.
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// Unit price.
        /// </summary>
        public double UnitPrice { get; set; }

        /// <summary>
        /// Discount promotion description.
        /// </summary>
        public string DiscountPromo { get; set; }

        /// <summary>
        /// Specifies whether the promo is applicable.
        /// </summary>
        public bool HasPromoApplied { get; set; }
    }
}

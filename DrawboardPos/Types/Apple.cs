using DrawboardPos.Interfaces;

namespace DrawboardPos.Types
{
    /// <summary>
    /// Apple Product.
    /// </summary>
    public class Apple : GroceryItem, IGroceryItem
    {
        /// <summary>
        /// Region Code.
        /// </summary>
        public string RegionCode { get; set; }
    }
}

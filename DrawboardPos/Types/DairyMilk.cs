using DrawboardPos.Interfaces;
using System;

namespace DrawboardPos.Types
{
    /// <summary>
    /// Dairy milk product.
    /// </summary>
    public class DairyMilk : GroceryItem, IGroceryItem
    {
        /// <summary>
        /// Volume.
        /// </summary>
        public int BottleVolume { get; set; }

        /// <summary>
        /// Expiry Date.
        /// </summary>
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Dairy code.
        /// </summary>
        public string DairyCode { get; set; }
    }
}

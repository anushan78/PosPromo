using System;

namespace DrawboardPos.Types
{
    /// <summary>
    /// Defines types for manipulating product categories for Pos.
    /// </summary>
    /// <typeparam name="T">Collection type for grocery products.</typeparam>
    public class ProductPortfolio<T> where T : Tuple<Apple, Biscuit, Cheese, DairyMilk>
    {
        /// <summary>
        /// Grocery product collection type.
        /// </summary>
        public T Grocery { get; set; }
    }
}

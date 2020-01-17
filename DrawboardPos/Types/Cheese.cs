using DrawboardPos.Interfaces;

namespace DrawboardPos.Types
{
    /// <summary>
    /// Cheese Product.
    /// </summary>
    public class Cheese : GroceryItem, IGroceryItem
    {
        /// <summary>
        /// Type of the piece.
        /// </summary>
        public PieceType Type { get; set; }

        /// <summary>
        /// Unit weight.
        /// </summary>
        public int UnitWeight { get; set; }
    }

    /// <summary>
    /// Enum for the piece types.
    /// </summary>
    public enum PieceType
    {
        Slice,
        Bar,
        Wedge
    }
}

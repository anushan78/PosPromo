using DrawboardPos.Interfaces;

namespace DrawboardPos.Types
{
    /// <summary>
    /// Biscuit type.
    /// </summary>
    public class Biscuit : GroceryItem, IGroceryItem
    {
        /// <summary>
        /// unit weight.
        /// </summary>
        public int UnitWeight { get; set; }

        /// <summary>
        /// Biscuit flavour.
        /// </summary>
        public Flavour BiscuitFlavour { get; set; }
    }

    /// <summary>
    /// Enum for flavour.
    /// </summary>
    public enum Flavour
    {
        Savoury,
        Sweet,
        Grain
    }
}

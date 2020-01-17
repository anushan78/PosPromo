using DrawboardPos.Types;
using System;

namespace DrawboardPos
{
    /// <summary>
    /// Implements Pos Service helper methods.
    /// </summary>
    internal class PosServiceTestHelper
    {
        internal static Apple AppleProduct
        {
            get
            {
                return new Apple
                {
                    ProductCode = "A",
                    RegionCode = "RG01",
                    UnitPrice = 1.25,
                    DiscountPromo = "3 for $3.00",
                    HasPromoApplied = true
                };
            }
        }

        internal static Biscuit BiscuitProduct
        {
            get
            {
                return new Biscuit
                {
                    ProductCode = "B",
                    BiscuitFlavour = Flavour.Savoury,
                    UnitWeight = 250,
                    UnitPrice = 4.25
                };
            }
        }

        internal static Cheese CheeseProduct
        {
            get
            {
                return new Cheese
                {
                    ProductCode = "C",
                    Type = PieceType.Wedge,
                    UnitWeight = 300,
                    UnitPrice = 1.00,
                    DiscountPromo = "$5 for a six pack",
                    HasPromoApplied = true
                };
            }
        }

        internal static DairyMilk DairyMilkProduct
        {
            get
            {
                return new DairyMilk
                {
                    ProductCode = "D",
                    UnitPrice = 0.75,
                    BottleVolume = 600,
                    DairyCode = "DR45",
                    ExpiryDate = new DateTime(2020, 02, 25)
                };
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    // A common Layer to  which is common for All the Layers(UI/Business/Data access)      
    public enum enumCartItem : byte
    {
        A,
        B,
        C,
        D,
    }
     // A common structure for all the 
    public struct stPromotion
    {
        public enumCartItem enumCartItem;
        public int UnitPrice;
        public int DiscountUnits;
        public int DiscountedPrice;
    }

}

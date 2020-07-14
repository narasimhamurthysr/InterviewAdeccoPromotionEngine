using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLayer;

namespace BusinessLayer
{
    // complete Business logic will be her for Promotion  C char SKU ID
    // This Class is Isolated based on the Unique Modifications and also for SRP (SOLID) Single Responsibility Principle - Business Logic
    class PromotionC : IPromotion
    {
        public int UnitPrice { get; set; }
        public int DiscountUnitCount { get; set; }
        public int PromotionPrice { get; set; }

        public PromotionC(stPromotion pobjPromotion )
        {
            this.UnitPrice = pobjPromotion.UnitPrice;
            this.DiscountUnitCount = pobjPromotion.DiscountUnits ;
            this.PromotionPrice =  pobjPromotion.DiscountedPrice;
        }

        public int GetCostPrice(int CartUnits)
        {
            int _intTotalPrice = 0;

            if (DiscountUnitCount >= CartUnits)
            {
                _intTotalPrice = CartUnits * this.UnitPrice;
            }
            else
            {
                int Quotient = CartUnits / DiscountUnitCount;
                int Remainder = CartUnits % DiscountUnitCount;

                _intTotalPrice += Remainder * UnitPrice + Quotient * this.PromotionPrice;
            }

            return _intTotalPrice;
        }
    }

}

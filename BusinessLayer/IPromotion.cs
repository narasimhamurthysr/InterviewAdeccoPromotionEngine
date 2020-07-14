using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// Stock keeping unit(SKU)
    /// This Class is Isolated based on the Unique Modifications and also for SRP,ISP (SOLID) Single Responsibility Principle - Business Logic
    /// SRP - Single Responcibilty Principle
    /// ISP - Interface Segregation Principle   


    interface IPromotion
    {
        int UnitPrice { get; set; }
        int DiscountUnitCount { get; set; }
        int PromotionPrice { get; set; }

        int GetCostPrice(int CartUnits);
    }
}

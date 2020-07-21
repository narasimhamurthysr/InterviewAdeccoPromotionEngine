using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using CommonLayer;


namespace InterviewAdeccoPromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            ///----- Assignemnt complted by Narasimhamurthy SR on 2020 July 14-----------
            /// Design Principles Implemented
            /// RPI - Replace IF By Polimorphism
            /// Factory Pattern (object creation of the class is hidden) 
            /// DI -Dependency Injection (Ecternal entity has to decide the selection )
            /// Builder Pattern ( Implementaion/Constration is same but results diffrent in diffret objects)
            
            ApplicationBusiness objBusiness = new ApplicationBusiness();

           /// Scenario A
           /// 1 * A    50
           /// 1 * B    30
           /// 1 * C    20
           /// Total 100

            objBusiness.AddtoCart(enumCartItem.A);  // Add One Char A
            objBusiness.AddtoCart(enumCartItem.B);  // Add One Char B          
            objBusiness.AddtoCart(enumCartItem.C);  // Add One Char C

            int intCartCost =  objBusiness.CalcuateCartCost(); // Calulcate the Total Cart Price

            Console.WriteLine($"Scenario A Total Cart Cost :{intCartCost}.");
            Console.WriteLine("-----------------------------------------------------Press Enter To Continue----------------");
            Console.ReadKey();

            /// Scenario B
            /// 5 * A    130 + 2 * 50
            /// 5 * B    45 + 45 + 30
            /// 1 * C    20
            /// Total 370
            
            objBusiness.AddtoCart(enumCartItem.A);  // Add Five Char A
            objBusiness.AddtoCart(enumCartItem.A);
            objBusiness.AddtoCart(enumCartItem.A);
            objBusiness.AddtoCart(enumCartItem.A);
            objBusiness.AddtoCart(enumCartItem.A);

            objBusiness.AddtoCart(enumCartItem.B);  // Add Five Char B
            objBusiness.AddtoCart(enumCartItem.B);
            objBusiness.AddtoCart(enumCartItem.B);
            objBusiness.AddtoCart(enumCartItem.B);
            objBusiness.AddtoCart(enumCartItem.B);

            objBusiness.AddtoCart(enumCartItem.C);  // Add Five Char C

            intCartCost = objBusiness.CalcuateCartCost();

            Console.WriteLine($"Scenario B: Total Cart Cost :{intCartCost}.");
            Console.WriteLine("-----------------------------------------------------Press Enter To Continue----------------");
            Console.ReadKey();

            /// Scenario C
            /// 3 * A    130 + 2 * 50
            /// 5 * B    45 + 45 + 30
            /// 1 * C    -
            /// 1 * D    - 30
            /// Total 280

            objBusiness.AddtoCart(enumCartItem.A);   // Add Three Char A
            objBusiness.AddtoCart(enumCartItem.A);
            objBusiness.AddtoCart(enumCartItem.A);


            objBusiness.AddtoCart(enumCartItem.B);    // Add Five Char B
            objBusiness.AddtoCart(enumCartItem.B);
            objBusiness.AddtoCart(enumCartItem.B);
            objBusiness.AddtoCart(enumCartItem.B);
            objBusiness.AddtoCart(enumCartItem.B);

            objBusiness.AddtoCart(enumCartItem.C);    // Add One Char C  

            objBusiness.AddtoCart(enumCartItem.D);   // Add One Char D

            intCartCost = objBusiness.CalcuateCartCost();

            Console.WriteLine($"Scenario C: Total Cart Cost :{intCartCost}.");
            Console.WriteLine("-----------------------------------------------------Press Enter To Exit ----------------");
            Console.ReadKey();
        }
    }
}



﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using CommonLayer;

namespace TestScenarios
{
    [TestClass]
    public class PromotionEngineUnitTest
    {
        [TestMethod]
        public void Scenario1()
        {
            ApplicationBusiness objBusiness = new ApplicationBusiness();
            /// Scenario A
            /// 1 * A    50
            /// 1 * B    30
            /// 1 * C    20
            /// Total 100

            objBusiness.AddtoCart(enumCartItem.A);  // Add One Char A
            objBusiness.AddtoCart(enumCartItem.B);  // Add One Char B          
            objBusiness.AddtoCart(enumCartItem.C);  // Add One Char C

            Assert.AreEqual(objBusiness.CalcuateCartCost(), 100); 
        }

        [TestMethod]
        public void Scenario2()
        {
            ApplicationBusiness objBusiness = new ApplicationBusiness();

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

            Assert.AreEqual(objBusiness.CalcuateCartCost(), 370);
        }


        [TestMethod]
        public void Scenario3()
        {
            ApplicationBusiness objBusiness = new ApplicationBusiness();

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

            Assert.AreEqual(objBusiness.CalcuateCartCost(), 280);
        }
                                  
        
        /// <summary>
        /// Test case for extra product C SKU's
        /// </summary>
        [TestMethod]
        public void Scenario4()
        {
            ApplicationBusiness objBusiness = new ApplicationBusiness();

            objBusiness.AddtoCart(enumCartItem.A);   // Add Three Char A
            objBusiness.AddtoCart(enumCartItem.A);
            objBusiness.AddtoCart(enumCartItem.A);

            objBusiness.AddtoCart(enumCartItem.B);    // Add Two Char B
            objBusiness.AddtoCart(enumCartItem.B);

            objBusiness.AddtoCart(enumCartItem.C);    // Add Two Char C   
            objBusiness.AddtoCart(enumCartItem.C);

            objBusiness.AddtoCart(enumCartItem.D);   // Add One Char D
               

            Assert.AreEqual(objBusiness.CalcuateCartCost(), 225);
        }


        /// <summary>
        /// Test case for extra product D SKU's
        /// </summary>
        [TestMethod]
        public void Scenario5()
        {
            ApplicationBusiness objBusiness = new ApplicationBusiness();
                     

            objBusiness.AddtoCart(enumCartItem.A);   // Add Three Char A
            objBusiness.AddtoCart(enumCartItem.A);
            objBusiness.AddtoCart(enumCartItem.A);

            objBusiness.AddtoCart(enumCartItem.B);    // Add Two Char B
            objBusiness.AddtoCart(enumCartItem.B);
            
            objBusiness.AddtoCart(enumCartItem.C);    // Add One Char C   
            

            objBusiness.AddtoCart(enumCartItem.D);   // Add two Char D
            objBusiness.AddtoCart(enumCartItem.D);

            Assert.AreEqual(objBusiness.CalcuateCartCost(), 220);
        }
    }
}



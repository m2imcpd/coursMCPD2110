using coursCSharp.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpTest
{
    [TestClass]
    public class CalculeTest
    {
        [TestMethod]
        public void AdditionTest()
        {
            //Arrange
            Calcule calcule = new Calcule();

            //Act 
            double result = calcule.Addition("bonjour", 10, 30);

            //Assert
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            Calcule calcule = new Calcule();
            double result = calcule.Multiplication(10, 20, -15);

            Assert.AreEqual(-3000, result);
        }

        [TestMethod]
        public void DivisionTest()
        {
            Calcule calcule = new Calcule();
            double result = calcule.Division(90, 10, 3);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void DivisionTest2()
        {
            Calcule calcule = new Calcule();
            double result = calcule.Division();
            Assert.AreEqual(1, result);
            //Assert.AreNotEqual(notExpected, value);
            //Assert.IsFalse(resut);
            //Assert.IsInstanceOfType(result, typeof(double));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Division par zero interdite")]
        public void DivisionTest3()
        {
            Calcule calcule = new Calcule();
            double result = calcule.Division(10, 0, 20);
        }
    }
}

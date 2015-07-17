using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polynom;

namespace Polynom.Test
{
    [TestClass]
    public class PolynomTests
    {
        [TestMethod]
        public void PolynomAddTest()
        {
            Polynom first = new Polynom(new double[] { 1, 2, 3 });
            Polynom second = new Polynom(new double[] { 1, 2, 3 });
            Polynom result = new Polynom(new double[] { 2, 4, 6 });
            Assert.AreEqual(Polynom.Add(first, second), result);
        }

        [TestMethod]
        public void PolynomPlusOpTest()
        {
            Polynom first = new Polynom(new double[] { 1, 2, 3 });
            Polynom second = new Polynom(new double[] { 1, 2, 3 });
            Polynom result = new Polynom(new double[] { 2, 4, 6 });
            Assert.AreEqual(first + second, result);
        }

        [TestMethod]
        public void PolynomMinusOpTest()
        {
            Polynom result = new Polynom(new double[] { 1, 2, 3 });
            Polynom second = new Polynom(new double[] { 1, 2, 3 });
            Polynom first = new Polynom(new double[] { 2, 4, 6 });
            Assert.AreEqual(first - second, result);
        }

        [TestMethod]
        public void PolynomPlusMinusOpTest()
        {
            Polynom first = new Polynom(new double[] { 2, 4, 6 });
            Polynom second = new Polynom(new double[] { 1, 2, 3 });
            Assert.AreEqual(first - second + second, first);
        }

        [TestMethod]
        public void PolynomClonTest()
        {
            Polynom first = new Polynom(new double[] { 2, 4, 6 });
            Polynom second = first.Clone() as Polynom;
            Assert.AreEqual(first , second);
        }

        [TestMethod]
        public void PolynomMultiplicationOnNumberTest()
        {
            var arr = new double[] { 2, 4, 6 };
            double value = 5;
            Polynom first = new Polynom(arr);
            for (int i = 0; i < arr.Length; i++)
                arr[i] *= value;
            Polynom result = new Polynom(arr);
            Assert.AreEqual(first*5, result);
        }




    }
}

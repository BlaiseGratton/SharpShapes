using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestTrapezoid
    {
        [TestMethod]
        public void TestTrapezoidConstructor()
        {
            Trapezoid trapezoid = new Trapezoid(8, 2, 4);
            Assert.AreEqual(8, trapezoid.width);
            Assert.AreEqual(2, trapezoid.top); 
            Assert.AreEqual(4, trapezoid.height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidCantBeParallelogram()
        {
            Trapezoid trapezoid = new Trapezoid(8, 8, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidMinimumHeight()
        {
            Trapezoid trapezoid = new Trapezoid(8, 7, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidMinimumBase()
        {
            Trapezoid trapezoid = new Trapezoid(0, 3, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestTrapezoidMinimumTop()
        {
            Trapezoid trapezoid = new Trapezoid(1, 0, 4);
        }

        [TestMethod]
        public void TestTrapezoidArea()
        {
            Trapezoid trapezoid = new Trapezoid(8, 2, 4);
            Assert.AreEqual(20, trapezoid.Area());
        }

        [TestMethod]
        public void TestBiggerTrapezoidArea()
        {
            Trapezoid trapezoid = new Trapezoid(10, 9, 8);
            Assert.AreEqual(81, trapezoid.Area());
        }

        [TestMethod]
        public void TestTrapezoidPerimeter()
        {
            Trapezoid trapezoid = new Trapezoid(8, 2, 4);
            Assert.AreEqual(20, trapezoid.Perimeter());
        }

        [TestMethod]
        public void TestBiggerTrapezoidPerimeter()
        {
            Trapezoid trapezoid = new Trapezoid(10, 9, 8);
        }
    }
}

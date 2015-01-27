using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestTrapezoid
    {
        [TestMethod]
        public void TestTrapezoidConstructorProperties()
        {
            Trapezoid trapezoid = new Trapezoid(8, 2, 4);
            Assert.AreEqual(8, trapezoid.LongBase);
            Assert.AreEqual(2, trapezoid.ShortBase); 
            Assert.AreEqual(4, trapezoid.Height);
        }

        [TestMethod]
        public void TestTrapezoidConstructorAngles()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 2);
            Assert.AreEqual(38.66, trapezoid.AcuteAngle);
            Assert.AreEqual(141.34, trapezoid.ObtuseAngle);
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
            Trapezoid trapezoid = new Trapezoid(14, 2, 8);
            Assert.AreEqual(36, trapezoid.Perimeter());
        }

        [TestMethod]
        public void TestTrapezoidScale()
        {
            Trapezoid trapezoid = new Trapezoid(8, 2, 4);
            trapezoid.Scale(200);
            Assert.AreEqual(16, trapezoid.LongBase);
            Assert.AreEqual(8, trapezoid.ShortBase);
            Assert.AreEqual(4, trapezoid.Height);
        }

        [TestMethod]
        public void TestTrapezoidSideCount()
        {
            Trapezoid trapezoid = new Trapezoid(20, 15, 2);
            Assert.AreEqual(4, trapezoid.SidesCount);
        }
    }
}

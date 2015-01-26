using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpShapes;

namespace TestSharpShapes
{
    [TestClass]
    public class UnitTestSquares
    {
        [TestMethod]
        public void TestSquareConstructor()
        {
            Square square = new Square(10);
            Assert.AreEqual(10, square.Width);
            Assert.AreEqual(10, square.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareConstructorSanityChecksSide()
        {
            Square square = new Square(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareConstructorSanityChecksForPositivity()
        {
            Square square = new Square(-5);
        }

        [TestMethod]
        public void TestSquareSidesCount()
        {
            Square square = new Square(10);
            Assert.AreEqual(4, square.SidesCount);
        }

        [TestMethod]
        public void TestSquareArea()
        {
            Square square = new Square(2);
            Assert.AreEqual(4, square.Area());
        }

        [TestMethod]
        public void TestBiggerSquareArea()
        {
            Square square = new Square(12);
            Assert.AreEqual(144, square.Area());
        }

        [TestMethod]
        public void TestSquarePerimeter()
        {
            Square square = new Square(4);
            Assert.AreEqual(16, square.Perimeter());
        }

        [TestMethod]
        public void TestBiggerSquarePerimeter()
        {
            Square square = new Square(11);
            Assert.AreEqual(44, square.Perimeter());
        }

        [TestMethod]
        public void TestDefaultColors()
        {
            Square shape = new Square(10);
            Assert.AreEqual(System.Drawing.Color.Bisque, shape.FillColor);
            Assert.AreEqual(System.Drawing.Color.Tomato, shape.BorderColor);
        }

        [TestMethod]
        public void TestSquareScale200Percent()
        {
            Square square = new Square(10);
            square.Scale(200);
            Assert.AreEqual(20, square.Height);
            Assert.AreEqual(20, square.Width);
        }

        [TestMethod]
        public void TestSquareScale100Percent()
        {
            Square square = new Square(10);
            square.Scale(100);
            Assert.AreEqual(10, square.Height);
            Assert.AreEqual(10, square.Width);
        }

        [TestMethod]
        public void TestSquareScale43Percent()
        {
            Square square = new Square(10);
            square.Scale(43);
            Assert.AreEqual((decimal)4.3, square.Height);
            Assert.AreEqual((decimal)4.3, square.Width);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareScale0Percent()
        {
            Square square = new Square(10);
            square.Scale(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSquareScaleNegativePercent()
        {
            Square square = new Square(10);
            square.Scale(-40);
        }
    }
}

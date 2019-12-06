using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorLibrary;

namespace CalculatorLibraryTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
        [TestMethod]
        public void CircleShapeSquareCalc()
        {
            // �������������� ������ �����
            var circle = new CircleShape(10);
            // ����������� ������� �����
            var square = Calculator.CalculateShapeSquare(circle);
            Assert.AreEqual(314.159d, Math.Round(square, 3));
        }

        [TestMethod]
        public void TriangleShapeSquareCalc()
        {
            // �������������� ������ ������������
            var triangle = new TriangleShape(3, 4, 5);
            // ����������� ������� ������������
            var square = Calculator.CalculateShapeSquare(triangle);
            Assert.AreEqual(6d, square);
        }

        [TestMethod]
        public void UnknownShapeSquareCalc()
        {
            // ��������� ������������
            var rnd = new Random();
            // �������� ������ �������������� ��������
            List<IShape> shapes = new List<IShape>() {
                new CircleShape(2),
                new TriangleShape(3, 3, 1),
                new CircleShape(100f),
                new TriangleShape(new double[] { 1, 2, 1 })
            };
            // ������������ ������ � �������
            shapes.Sort((a, b) => rnd.Next(0, 2) == 1 ? 1 : -1);
            // ��������� ���������� ������� �����
            foreach (var s in shapes)
                Assert.IsInstanceOfType(s.CalcSquare(), typeof(double));
        }

        [TestMethod]
        public void IsRectangularTriangle()
        {
            // ������������� �����������
            var rectTriangle = new TriangleShape(3, 4, 5);
            Assert.IsTrue(rectTriangle.IsRectangular());

            // ������� �����������
            var simpleTriangle = new TriangleShape(3, 3, 4);
            Assert.IsFalse(simpleTriangle.IsRectangular());
        }
    }
}

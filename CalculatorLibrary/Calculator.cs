using System;

namespace CalculatorLibrary
{
    /// <summary>
    /// Интерфейс геометрической фигуры
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Метод, вычисляющий площадь фигуры
        /// </summary>
        /// <returns>Значение площади фигуры</returns>
        double CalcSquare();
    }

    /// <summary>
    /// Геометрическая фигура круга
    /// </summary>
    public class CircleShape : IShape
    {
        /// <summary>
        /// Радиус треугольника
        /// </summary>
        public double radius;
        /// <summary>
        /// Конструктор геометрической фигуры круга
        /// </summary>
        /// <param name="radius">Величина радиуса</param>
        public CircleShape(double radius)
        {
            this.radius = radius;
        }
        public double CalcSquare()
        {
            return Math.PI * Math.Pow(this.radius, 2);
        }
    }

    /// <summary>
    /// Геометрическая фигура треугольника
    /// </summary>
    public class TriangleShape : IShape
    {

        /// <summary>
        /// Массив размеров сторон треугольника
        /// </summary>
        public double[] sides = new double[3];
        /// <summary>
        /// Конструктор треугольника по трём переменным-сторонам
        /// </summary>
        /// <param name="a">Сторона A</param>
        /// <param name="b">Сторона B</param>
        /// <param name="c">Сторона C</param>
        public TriangleShape(double a, double b, double c)
        {
            this.sides[0] = a;
            this.sides[1] = b;
            this.sides[2] = c;
        }

        /// <summary>
        /// Конструктор треугольника по массиву с тремя сторонами
        /// </summary>
        /// <param name="sides">Массив с тремя сторонами</param>
        public TriangleShape(double[] sides)
        {
            if (sides.Length != 3) throw new FormatException("Invalid sides array length");
            this.sides = sides;
        }
        /// <summary>
        /// Определяет, является ли треугольник прямоугольным
        /// </summary>
        /// <returns></returns>
        public bool IsRectangular()
        {
            // Вычисляем квадраты сторон
            double a = Math.Pow(sides[0], 2), b = Math.Pow(sides[1], 2), c = Math.Pow(sides[2], 2);
            // Ищем сумму квадратов катетов равных квадрату гипотенузе
            return (a + b == c) || (a + c == b) || (c + b == a);
        }
        public double CalcSquare()
        {
            // Переменная полупериметра
            double p = 0;
            // Вычисляем периметр, суммируя все стороны треугольника
            foreach (var s in sides) p += s;
            // Делим периметр на два, получая из периметра полупериметр
            p /= 2f;

            // Переменная суммы разности полупериметра и сторон треугольника
            double square = 0;
            foreach (var s in sides) square += p - s;

            // Вычисляем площадь, возвращая квадратный корень произведения текущего
            // значения периметра на полупериметр
            return Math.Sqrt(square * p);
        }
    }

    /// <summary>
    /// Калькулятор параметров геометрических фигур
    /// </summary>
    public static class Calculator
    {
        /// <summary>
        /// Вычисляет площадь фигуры
        /// </summary>
        /// <param name="shape">Геометрическая фигура</param>
        /// <returns></returns>
        public static double CalculateShapeSquare(IShape shape)
        {
            return shape.CalcSquare();
        }
    }
}
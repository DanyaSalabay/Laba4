using System;

namespace Lab4.Tasks6to7
{
    public class Triangle
    {
        private double _a;
        private double _b;
        private double _c;

        public Triangle()
        {
            _a = 1.0;
            _b = 1.0;
            _c = 1.0;
        }

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException(
                    "Длины сторон должны быть больше нуля.");
            }

            _a = a;
            _b = b;
            _c = c;
        }

        public double A
        {
            get { return _a; }
            set 
            { 
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Сторона А должна быть больше нуля.");
                }
                _a = value; 
            }
        }

        public double B
        {
            get { return _b; }
            set 
            { 
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Сторона B должна быть больше нуля.");
                }
                _b = value; 
            }
        }

        public double C
        {
            get { return _c; }
            set 
            { 
                if (value <= 0)
                {
                    throw new ArgumentException(
                        "Сторона C должна быть больше нуля.");
                }
                _c = value; 
            }
        }

        public bool IsValid()
        {
            if (_a + _b <= _c)
            {
                return false;
            }
            if (_a + _c <= _b)
            {
                return false;
            }
            if (_b + _c <= _a)
            {
                return false;
            }
            return true;
        }

        public double GetArea()
        {
            if (!IsValid())
            {
                return 0.0;
            }

            double p = GetPerimeter() / 2.0;
            double square = p * (p - _a) * (p - _b) * (p - _c);
            
            return Math.Sqrt(square);
        }

        public double GetPerimeter()
        {
            return _a + _b + _c;
        }

        public override string ToString()
        {
            return $"Стороны: a={_a:F2}, b={_b:F2}, c={_c:F2} | " +
                   $"Периметр: {GetPerimeter():F2} | " +
                   $"Площадь: {GetArea():F2} | " +
                   $"Существует: {IsValid()}";
        }

        // --- ЗАДАНИЕ 7 ---

        public static double operator -(Triangle t)
        {
            if (t == null)
            {
                return 0.0;
            }
            return t.GetArea();
        }

        public static implicit operator double(Triangle t)
        {
            if (t == null)
            {
                return 0.0;
            }
            return t.GetPerimeter();
        }

        public static explicit operator bool(Triangle t)
        {
            if (t == null)
            {
                return false;
            }
            return t.IsValid();
        }

        public static bool operator <(Triangle t1, Triangle t2)
        {
            if (t1 == null || t2 == null)
            {
                return false;
            }
            return t1.GetArea() < t2.GetArea();
        }

        public static bool operator >(Triangle t1, Triangle t2)
        {
            if (t1 == null || t2 == null)
            {
                return false;
            }
            return t1.GetArea() > t2.GetArea();
        }
    }
}
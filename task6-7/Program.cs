using System;
using Lab4.Tasks6to7;

namespace Lab4.Tasks6to7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("МЕНЮ (Задания 6-7)");
            Console.WriteLine("1. Задание 6 (Класс Triangle)");
            Console.WriteLine("2. Задание 7 " +
                              "(Перегрузка операций)");
            Console.Write("\nВыбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunTask6();
                    break;
                case "2":
                    RunTask7();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        static void RunTask6()
        {
            Console.WriteLine("\nТестирование Задания 6");

            try
            {
                Triangle tDefault = new Triangle();
                Console.WriteLine("\n1. Конструктор" +
                                  " по умолчанию:");
                Console.WriteLine(tDefault.ToString());

                Triangle tValid = new Triangle(3, 4, 5);
                Console.WriteLine("\n2. Конструктор с" +
                                  " параметрами (3, 4, 5):");
                Console.WriteLine(tValid.ToString());
                
                Console.WriteLine("\n3. Попытка создать" +
                                  " треугольник (-1, 2, 3):");
                try
                {
                    Triangle tInvalid = new Triangle(-1, 2, 3);
                    Console.WriteLine(tInvalid.ToString());
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка! {ex.Message}");
                }
                
                Console.WriteLine("\nТестирование методов");
                Console.WriteLine($"Существует ли (3, 4, 5)? " +
                    $"{tValid.IsValid()}");
                
                Triangle tNoExist = new Triangle(1, 1, 10);
                Console.WriteLine($"Существует ли (1, 1, 10)? " +
                    $"{tNoExist.IsValid()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nКритическая ошибка: {ex.Message}");
            }
        }

        static void RunTask7()
        {
            Console.WriteLine("\nТестирование Задания 7");

            try
            {
                Triangle tValid = new Triangle(3, 4, 5);

                Console.WriteLine("\nТестирование операций");
                Console.WriteLine($"Рассматривается треугольник: " +
                    $"a={tValid.A}, b={tValid.B}, c={tValid.C}");

                double areaMinus = -tValid;
                Console.WriteLine($"Площадь через унарный минус: " +
                    $"{areaMinus:F2}");

                double perimeter = tValid;
                Console.WriteLine($"Периметр через приведение к " +
                    $"double: {perimeter:F2}");

                Triangle tNoExist = new Triangle(1, 1, 10);
                bool exists1 = (bool)tValid;
                bool exists2 = (bool)tNoExist;
                Console.WriteLine($"Существует (3, 4, 5)" +
                                  $" через bool? " +
                    $"{exists1}");
                Console.WriteLine($"Существует (1, 1, 10)" +
                                  $" через bool? " +
                    $"{exists2}");

                Triangle t1 = new Triangle(3, 4, 5); 
                Triangle t2 = new Triangle(5, 5, 6); 
                Console.WriteLine("\nСравнение треугольников:");
                Console.WriteLine($"t1: {t1.ToString()}");
                Console.WriteLine($"t2: {t2.ToString()}");
                
                Console.WriteLine($"t1 < t2: {t1 < t2}");
                Console.WriteLine($"t1 > t2: {t1 > t2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nКритическая ошибка: {ex.Message}");
            }
        }
    }
}

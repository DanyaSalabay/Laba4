using System;
using System.Collections.Generic;
using System.IO;
using Lab4.Tasks1to5;

namespace Lab4.Tasks1to5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("МЕНЮ (Задания 1-5)");
            Console.WriteLine("1. Задание 1 (Дубликаты в списке)");
            Console.WriteLine("2. Задание 2 (Двусвязный список)");
            Console.WriteLine("3. Задание 3 (Факультативы)");
            Console.WriteLine("4. Задание 4 (Файл и буквы)");
            Console.WriteLine("5. Задание 5 (АЗС и бензин)");
            Console.WriteLine("0. Выход");
            Console.Write("\nВыбор: ");

            string choice = Console.ReadLine();
            string filePath4 = "task4.txt";
            string filePath5 = "task5.txt";

            switch (choice)
            {
                case "1":
                    RunTask1();
                    break;
                case "2":
                    RunTask2();
                    break;
                case "3":
                    TasksSolver.SolveTask3();
                    break;
                case "4":
                    TasksSolver.CreateTask4File(filePath4);
                    Console.WriteLine("\nРешение");
                    TasksSolver.SolveTask4(filePath4);
                    break;
                case "5":                   
                    TasksSolver.FillTask5FileFromConsole(filePath5);
                    Console.WriteLine("\nРешение");
                    TasksSolver.SolveTask5(filePath5);
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        static void RunTask1()
        {
            Console.WriteLine("Задание 1");
            
            List<int> list = TasksSolver.ReadIntListFromConsole();

            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            Console.WriteLine("\nИсходный список: " + 
                string.Join(", ", list));

            List<int> result = 
                TasksSolver.RemoveConsecutiveDuplicates(list);

            Console.WriteLine("Результат: " + 
                string.Join(", ", result));
        }

        static void RunTask2()
        {
            Console.WriteLine("Задание 2");
            Console.WriteLine("Создание однонаправленного списка L1:");

            Node<int> singleList = TasksSolver.CreateSingleList();

            if (singleList == null)
            {
                Console.WriteLine("Список L1 пуст.");
                return;
            }

            Console.WriteLine("\nПостроение двунаправленного L:");
            DoubleNode<int> doubleList = 
                TasksSolver.BuildDoublyList(singleList);

            Console.WriteLine("Прямой порядок (Next): ");
            TasksSolver.PrintDoublyList(doubleList);
            
            TasksSolver.PrintDoublyListReverse(doubleList);
        }
    }
}

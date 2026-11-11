using System;
using System.Collections.Generic;
using System.IO;

namespace Lab4.Tasks1to5
{
    // Вспомогательный класс для однонаправленного списка
    public class Node<T>
    {
        private T _data;
        private Node<T> _next;

        public Node(T data)
        {
            _data = data;
            _next = null;
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Node<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }
    }

    // Вспомогательный класс для двунаправленного списка
    public class DoubleNode<T>
    {
        private T _data;
        private DoubleNode<T> _next;
        private DoubleNode<T> _prev;

        public DoubleNode(T data)
        {
            _data = data;
            _next = null;
            _prev = null;
        }

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public DoubleNode<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }

        public DoubleNode<T> Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }
    }

    public static class TasksSolver
    {
        // --- ЗАДАНИЕ 1 ---
        public static List<T> RemoveConsecutiveDuplicates<T>(
            List<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (list.Count == 0)
            {
                return new List<T>();
            }

            List<T> result = new List<T>();
            result.Add(list[0]);
            int i = 1;

            for (i = 1; i < list.Count; i++)
            {
                if (!EqualityComparer<T>.Default.Equals(
                    list[i], list[i - 1]))
                {
                    result.Add(list[i]);
                }
            }

            return result;
        }

        public static List<int> ReadIntListFromConsole()
        {
            List<int> list = new List<int>();
            int number = 0;
            string input = "";
            
            Console.WriteLine("Вводите целые числа" +
                              " (пустая строка - конец):");

            while (true)
            {
                Console.Write("Элемент: ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                if (int.TryParse(input, out number))
                {
                    list.Add(number);
                }
                else
                {
                    Console.WriteLine("Ошибка!" +
                                      " Введите целое число.");
                }
            }

            return list;
        }

        // --- ЗАДАНИЕ 2 ---
        public static DoubleNode<T> BuildDoublyList<T>(
            Node<T> head)
        {
            if (head == null)
            {
                return null;
            }

            DoubleNode<T> newHead = new DoubleNode<T>(head.Data);
            DoubleNode<T> currentDouble = newHead;
            Node<T> currentSingle = head.Next;

            while (currentSingle != null)
            {
                DoubleNode<T> newNode = 
                    new DoubleNode<T>(currentSingle.Data);

                currentDouble.Next = newNode;
                newNode.Prev = currentDouble;
                
                currentDouble = newNode;
                currentSingle = currentSingle.Next;
            }

            return newHead;
        }

        public static Node<int> CreateSingleList()
        {
            Node<int> head = null;
            Node<int> tail = null;
            int inputNumber = 0;
            string input = "";

            Console.WriteLine("Вводите числа (Enter - конец):");

            while (true)
            {
                Console.Write("Элемент: ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                if (int.TryParse(input, out inputNumber))
                {
                    Node<int> newNode = new Node<int>(inputNumber);

                    if (head == null)
                    {
                        head = newNode;
                        tail = newNode;
                    }
                    else
                    {
                        tail.Next = newNode;
                        tail = newNode;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите число.");
                }
            }

            return head;
        }

        public static void PrintDoublyList(DoubleNode<int> head)
        {
            if (head == null)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            DoubleNode<int> current = head;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            
            Console.WriteLine();
        }

        public static void PrintDoublyListReverse
            (DoubleNode<int> head)
        {
            if (head == null)
            {
                return;
            }

            DoubleNode<int> current = head;
            DoubleNode<int> tail = head;

            while (current != null)
            {
                tail = current;
                current = current.Next;
            }

            Console.Write("Обратный порядок: ");
            current = tail;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Prev;
            }
            
            Console.WriteLine();
        }

        // --- ЗАДАНИЕ 3 ---
        public static void SolveTask3()
        {
            HashSet<string> allElectives = new HashSet<string>
            {
                "Программирование", 
                "Робототехника", 
                "Английский", 
                "Психология",
                "Математика",
                "Физика"
            };

            Console.WriteLine("Список всех факультативов:");
            foreach (string item in allElectives)
            {
                Console.WriteLine("- " + item);
            }

            HashSet<string> student1 = new HashSet<string> 
            { 
                "Программирование", "Английский" 
            };
            HashSet<string> student2 = new HashSet<string> 
            { 
                "Программирование", "Робототехника" 
            };
            HashSet<string> student3 = new HashSet<string> 
            { 
                "Программирование", "Математика" 
            };
            HashSet<string> student4 = new HashSet<string> 
            { 
                "Программирование", "Английский" 
            };
            HashSet<string> student5 = new HashSet<string> 
            { 
                "Программирование", "Физика" 
            };

            Console.WriteLine("\nДанные студентов:");
            PrintStudent("Артём", student1);
            PrintStudent("Андрей", student2);
            PrintStudent("Никита", student3);
            PrintStudent("Денис", student4);
            PrintStudent("Даниил", student5);

            HashSet<string> unionElectives = 
                new HashSet<string>();
            HashSet<string> intersectElectives = 
                new HashSet<string>(allElectives);

            unionElectives.UnionWith(student1);
            unionElectives.UnionWith(student2);
            unionElectives.UnionWith(student3);
            unionElectives.UnionWith(student4);
            unionElectives.UnionWith(student5);

            intersectElectives.IntersectWith(student1);
            intersectElectives.IntersectWith(student2);
            intersectElectives.IntersectWith(student3);
            intersectElectives.IntersectWith(student4);
            intersectElectives.IntersectWith(student5);

            HashSet<string> noneElectives = 
                new HashSet<string>(allElectives);
            noneElectives.ExceptWith(unionElectives);

            Console.WriteLine("\nРЕЗУЛЬТАТЫ");

            Console.WriteLine("\n1. Ходят ВСЕ студенты:");
            PrintSet(intersectElectives);

            Console.WriteLine("\n2. Ходит ХОТЯ БЫ ОДИН студент:");
            PrintSet(unionElectives);

            Console.WriteLine("\n3. НЕ ходит НИКТО:");
            PrintSet(noneElectives);
        }

        private static void PrintStudent(
            string name, HashSet<string> electives)
        {
            Console.Write(name + ": ");
            
            if (electives.Count == 0)
            {
                Console.Write("(ничего)");
            }

            foreach (string item in electives)
            {
                Console.Write(item + " ");
            }
            
            Console.WriteLine();
        }

        private static void PrintSet(HashSet<string> set)
        {
            if (set.Count == 0)
            {
                Console.WriteLine("- (нет таких)");
                return;
            }

            foreach (string item in set)
            {
                Console.WriteLine("- " + item);
            }
        }

        // --- ЗАДАНИЕ 4 ---
        public static void CreateTask4File(string path)
        {
            string text = "Я студент второго курса и я устал, " +
                          "хочу зимние каникулы. " +
                          "А еще я ищу буквы в нечетных словах.";

            try
            {
                File.WriteAllText(path, text);
                Console.WriteLine($"Файл успешно создан: {path}");
                Console.WriteLine($"Содержимое: {text}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при создании файла: "
                                  + ex.Message);
            }
        }

        public static void SolveTask4(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Ошибка: Файл {path} не найден.");
                return;
            }

            string text = File.ReadAllText(path);

            char[] separators = new char[] 
            { 
                ' ', '.', ',', '!', '?', ';', ':', '-', '\n', '\r' 
            };
            
            string[] words = text.Split(
                separators, 
                StringSplitOptions.RemoveEmptyEntries);

            HashSet<char> uniqueChars = new HashSet<char>();
            int i = 0;
            int wordIndex = 1;

            for (i = 0; i < words.Length; i++)
            {
                if (wordIndex % 2 != 0)
                {
                    string word = words[i].ToLower();
                    int j = 0;
                    
                    for (j = 0; j < word.Length; j++)
                    {
                        char c = word[j];
                        if (c >= 'а' && c <= 'я' || c == 'ё')
                        {
                            uniqueChars.Add(c);
                        }
                    }
                }
                wordIndex++;
            }

            char[] sortedChars = new char[uniqueChars.Count];
            uniqueChars.CopyTo(sortedChars);
            Array.Sort(sortedChars);

            Console.WriteLine("Нечетные слова:");
            wordIndex = 1;
            for (i = 0; i < words.Length; i++)
            {
                if (wordIndex % 2 != 0)
                {
                    Console.Write(words[i] + " ");
                }
                wordIndex++;
            }
            Console.WriteLine();

            Console.WriteLine("\nУникальные символы" +
                              " в алфавитном порядке:");
            if (sortedChars.Length == 0)
            {
                Console.WriteLine("(не найдено)");
            }
            else
            {
                for (i = 0; i < sortedChars.Length; i++)
                {
                    Console.Write(sortedChars[i] + " ");
                }
                Console.WriteLine();
            }
        }

        // --- ЗАДАНИЕ 5 ---
        // Метод для ввода с клавиатуры и записи в файл
        public static void FillTask5FileFromConsole(string path)
        {
            Console.Write("Введите количество записей N: ");
            string inputN = Console.ReadLine();
            int n = 0;

            if (!int.TryParse(inputN, out n) || n <= 0)
            {
                Console.WriteLine("Ошибка: N должно быть > 0.");
                return;
            }

            List<string> lines = new List<string>();
            lines.Add(n.ToString()); 

            int i = 0;
            string line = "";

            Console.WriteLine($"\nВведите {n} строк в формате:");
            Console.WriteLine("<Компания> <Улица> " +
                              "<Марка> <Цена>");

            for (i = 0; i < n; i++)
            {
                Console.Write($"Строка {i + 1}: ");
                line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    Console.WriteLine("Ошибка: пустая строка.");
                    i--;
                    continue;
                }

                string[] parts = line.Split(
                    new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 4)
                {
                    Console.WriteLine("Ошибка: нужно 4 слова.");
                    i--;
                    continue;
                }

                lines.Add(line);
            }

            try
            {
                File.WriteAllLines(path, lines);
                Console.WriteLine($"\nФайл сохранен: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка записи: " + ex.Message);
            }
        }
        
        public static void SolveTask5(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine($"Ошибка: Файл" +
                                  $" {path} не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(path);
            if (lines.Length == 0)
            {
                Console.WriteLine("Файл пуст.");
                return;
            }

            int n = 0;
            if (!int.TryParse(lines[0], out n))
            {
                Console.WriteLine("Ошибка: первая строка" +
                                  " не число N.");
                return;
            }

            if (n <= 0 || n >= lines.Length)
            {
                Console.WriteLine("Ошибка: некорректное N.");
                return;
            }

            Dictionary<string, int> minPrices = 
                new Dictionary<string, int>();

            int i = 0;
            string[] parts = null;
            string brand = "";
            int price = 0;

            for (i = 1; i <= n; i++)
            {
                parts = lines[i].Split(
                    new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 4)
                {
                    brand = parts[2];
                    
                    if (!int.TryParse(parts[3], out price))
                    {
                        continue;
                    }

                    if (!minPrices.ContainsKey(brand))
                    {
                        minPrices.Add(brand, price);
                    }
                    else
                    {
                        if (price < minPrices[brand])
                        {
                            minPrices[brand] = price;
                        }
                    }
                }
            }

            Console.WriteLine("\nМинимальные цены по маркам:");
            foreach (KeyValuePair<string, int> pair in minPrices)
            {
                Console.WriteLine($"АИ-{pair.Key}:" +
                                  $" {pair.Value} коп.");
            }

            Dictionary<string, int> cheapStationsCount = 
                new Dictionary<string, int>();
            
            cheapStationsCount.Add("92", 0);
            cheapStationsCount.Add("95", 0);
            cheapStationsCount.Add("98", 0);

            for (i = 1; i <= n; i++)
            {
                parts = lines[i].Split(
                    new char[] { ' ' }, 
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 4)
                {
                    brand = parts[2];
                    
                    if (!int.TryParse(parts[3], out price))
                    {
                        continue;
                    }

                    if (minPrices.ContainsKey(brand) && 
                        price == minPrices[brand])
                    {
                        cheapStationsCount[brand]++;
                    }
                }
            }

            Console.WriteLine("\nКоличество АЗС с минимальной ценой:");
            Console.Write("92: " + cheapStationsCount["92"]);
            Console.Write(" | 95: " + cheapStationsCount["95"]);
            Console.WriteLine(" | 98: " + cheapStationsCount["98"]);
            
            Console.WriteLine("\nОтвет:");
            Console.WriteLine(
                $"{cheapStationsCount["92"]} " +
                $"{cheapStationsCount["95"]} " +
                $"{cheapStationsCount["98"]}");
        }
    }
}
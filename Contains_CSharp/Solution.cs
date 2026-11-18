using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Contains_CSharp
{
    public class Solution<T> where T : IComparable<T>
    {
        private static Random _random = new Random();

        public static List<T> UniqueList(List<T> list1, List<T> list2)
        {
            if (list1 == null || list2 == null)
            {
                throw new ArgumentException("Списки не должны быть null");
            }

            List<T> endList= new List<T>();

            foreach (T el in list1)
            {
                if (!list2.Contains(el) && !endList.Contains(el))
                {
                    endList.Add(el);
                }
            }

            foreach (T el in list2)
            {
                if (!list1.Contains(el) && !endList.Contains(el))
                {
                    endList.Add(el);
                }
            }

            return endList;
        }

        public static void MinMaxList(LinkedList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("Список должен содержать хотя бы один элемент");
            }

            LinkedListNode<T> minNode = list.First;
            LinkedListNode<T> maxNode = list.First;

            for (LinkedListNode<T> node = list.First; node != null; node = node.Next)
            {
                if (node.Value.CompareTo(minNode.Value) < 0)
                {
                    minNode = node;
                }

                if (node.Value.CompareTo(maxNode.Value) > 0)
                {
                    maxNode = node;
                }
            }

            if (minNode == maxNode)
            {
                return;
            }

            LinkedListNode<T> start = null;
            LinkedListNode<T> end = null;

            for (LinkedListNode<T> node = list.First; node != null; node = node.Next)
            {
                if (node == minNode)
                {
                    start = minNode;
                    end = maxNode;
                    break;
                }

                if (node == maxNode)
                {
                    start = maxNode;
                    end = minNode;
                    break;
                }
            }

            LinkedListNode<T> current = start.Next;

            while (current != end)
            {
                LinkedListNode<T> next = current.Next;
                list.Remove(current);
                current = next;
            }
        }

        public static void RatingShow(List<string> nameShow, List<List<string>> favoriteShow)
        {
            if (nameShow == null || favoriteShow == null || favoriteShow.Count == 0)
            {
                throw new ArgumentException("Должен быть хотя бы один телезритель");
            }

            HashSet<string> allShowSet = new HashSet<string>(nameShow);
            HashSet<string> allIntersectSet = new HashSet<string>(allShowSet);
            HashSet<string> allAddSet = new HashSet<string>();

            foreach (List<string> person in favoriteShow)
            {
                HashSet<string> personSet = new HashSet<string>(person);
                personSet.IntersectWith(allShowSet);

                allAddSet.UnionWith(personSet);
                allIntersectSet.IntersectWith(personSet);
            }

            HashSet<string> allBedSet = new HashSet<string>(allShowSet);
            allBedSet.ExceptWith(allAddSet);

            PrintSet("Шоу, которые понравились всем:", allIntersectSet);
            PrintSet("Шоу, которые понравились хоть кому-то:", allAddSet);
            PrintSet("Шоу, которые не понравились никому (грустно):", allBedSet);
        }

        private static void PrintSet(string title, HashSet<string> set)
        {
            Console.WriteLine(title);

            if (set.Count == 0)
            {
                Console.WriteLine("таких нет");
                return;
            }

            foreach (string show in set)
            {
                Console.Write(" " + show);
            }
            Console.WriteLine();
        }

        public static void FillTextFile(string fileName)
        {
            string[] lines = new string[]
            {
                "В 2024 году в магазин привезли 15 книг и 3 тетради.",
                "Тираж составил 7000 экземпляров, а цена 150 рублей.",
                "Вчера было холодно, а сегодня стало теплее.",
                "Мы встретились в 9 часов утра."
            };

            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }

        public static void DigitInText(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new ArgumentException("Такого файла не существует");
            }

            HashSet<char> uniqDigit = new HashSet<char>();

            using (StreamReader file = new StreamReader(fileName, Encoding.UTF8))
            {
                int charCode;
                while ((charCode = file.Read()) != -1)
                {
                    if (char.IsDigit((char)charCode))
                    {
                        uniqDigit.Add((char)charCode);
                    }
                }
            }

            Console.WriteLine("Все цифры, которые есть в тексте:");

            if (uniqDigit.Count == 0)
            {
                Console.WriteLine("цифр нет");
                return;
            }

            List<char> digits = new List<char>(uniqDigit);
            digits.Sort();

            foreach (char el in digits)
            {
                Console.Write(el + " ");
            }
            Console.WriteLine();
        }

        public static void FillPeopleFile(string fileName, int n)
        {
            string[] surnames = new string[]
            {
                "Иванов", "Петров", "Сидоров", "Смирнов", "Кузнецов", "Попов"
            };

            string[] names = new string[]
            {
                "Сергей", "Антон", "Юрий", "Мария", "Ольга", "Иван"
            };

            DateTime start = new DateTime(1995, 1, 1);

            using (StreamWriter file = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                file.WriteLine(n);

                for (int i = 0; i < n; i++)
                {
                    DateTime date = start.AddDays(_random.Next(0, 60));

                    file.WriteLine(surnames[_random.Next(surnames.Length)] + " "
                        + names[_random.Next(names.Length)] + " "
                        + date.ToString("dd.MM.yyyy"));
                }
            }
        }

        public static void OldPerson(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new ArgumentException("Такого файла не существует");
            }

            SortedList<DateTime, List<string>> byDate = new SortedList<DateTime, List<string>>();

            using (StreamReader file = new StreamReader(fileName, Encoding.UTF8))
            {
                string firstLine = file.ReadLine();
                int n;

                if (firstLine == null || !int.TryParse(firstLine.Trim(), out n) || n <= 0)
                {
                    throw new ArgumentException("В первой строке должно быть количество людей");
                }

                for (int i = 0; i < n; i++)
                {
                    string input = file.ReadLine();

                    if (input == null)
                    {
                        throw new ArgumentException($"В файле меньше {n} строк с данными");
                    }

                    string[] parts = input.Split(new char[] { ' ' },
                        StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length != 3)
                    {
                        throw new ArgumentException($"Строка {i + 2}: должно быть три значения - фамилия, имя и дата рождения");
                    }

                    if (parts[0].Length > 20)
                    {
                        throw new ArgumentException($"Строка {i + 2}: вы ввели фамилию недопустимой длины");
                    }

                    if (parts[1].Length > 20)
                    {
                        throw new ArgumentException($"Строка {i + 2}: вы ввели имя недопустимой длины");
                    }

                    DateTime date;

                    if (!DateTime.TryParseExact(parts[2], "dd.MM.yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out date) || date.Year < 1800 || date.Year > 2100)
                    {
                        throw new ArgumentException($"Строка {i + 2}: неверный ввод даты (нужен формат ДД.ММ.ГГГГ, год от 1800 до 2100)");
                    }

                    if (!byDate.ContainsKey(date))
                    {
                        byDate.Add(date, new List<string>());
                    }

                    byDate[date].Add(parts[0] + " " + parts[1]);
                }
            }

            List<string> oldest = byDate.Values[0];

            if (oldest.Count == 1)
            {
                Console.WriteLine(oldest[0]);
            }
            else
            {
                Console.WriteLine(oldest.Count);
            }
        }
    }
}

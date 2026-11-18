using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Contains_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool work = true;

            while (work)
            {

                Console.WriteLine("----Лабораторная работа №4 ---\t");
                Console.WriteLine("-------------Задание 1--------\t");
                Console.WriteLine(" 1.Элементы только одного из двух списков\t");
                Console.WriteLine("-------------Задание 2--------\t");
                Console.WriteLine(" 2.Удаление элементов между минимумом и максимумом\t");
                Console.WriteLine("-------------Задание 3--------\t");
                Console.WriteLine(" 3.Рейтинг телевизионных шоу\t");
                Console.WriteLine("-------------Задание 4--------\t");
                Console.WriteLine(" 4.Цифры в тексте\t");
                Console.WriteLine("-------------Задание 5--------\t");
                Console.WriteLine(" 5.Самый старший человек\t");
                Console.WriteLine("-------------Задание 6--------\t");
                Console.WriteLine(" 6.Конструкторы и свойства класса Money\t");
                Console.WriteLine(" 7.Вычитание копеек\t");
                Console.WriteLine("-------------Задание 7--------\t");
                Console.WriteLine(" 8.Унарные операции ++ и --\t");
                Console.WriteLine(" 9.Операции приведения типа\t");
                Console.WriteLine("10.Вычитание копеек (операция -)\t");
                Console.WriteLine("11.Вычитание денежных сумм\t");
                Console.WriteLine("0.Выход");

                int choice = Check.InputInt("Введите номер задачи:");

                switch (choice)
                {
                    case 0:
                        work = false;
                        break;

                    case 1:
                        {
                            List<int> list1 = Check.InputIntList("Введите элементы списка L1 через пробел:", 0);
                            List<int> list2 = Check.InputIntList("Введите элементы списка L2 через пробел:", 0);

                            Console.WriteLine("Результат: ");
                            Console.WriteLine(ToText(Solution<int>.UniqueList(list1, list2)));
                            break;
                        }

                    case 2:
                        {
                            LinkedList<int> list = new LinkedList<int>(
                                Check.InputIntList("Введите элементы списка L через пробел (не меньше одного):", 1));

                            Console.WriteLine("Исходный список: " + ToText(list));
                            Solution<int>.MinMaxList(list);

                            Console.WriteLine("Результат: ");
                            Console.WriteLine(ToText(list));
                            break;
                        }

                    case 3:
                        {
                            List<string> nameShow = Check.InputStringList(
                                "Введите названия шоу через запятую:", false);
                            int count = Check.InputInt("Введите количество телезрителей (от 1 до 10):", 1, 10);

                            List<List<string>> favoriteShow = new List<List<string>>();

                            for (int i = 0; i < count; i++)
                            {
                                favoriteShow.Add(Check.InputStringList(
                                    $"Введите через запятую шоу, которые нравятся телезрителю {i + 1} (можно оставить пустым):", true));
                            }

                            Console.WriteLine("Результат: ");
                            Solution<string>.RatingShow(nameShow, favoriteShow);
                            break;
                        }

                    case 4:
                        {
                            string fileName = Check.InputString("Введите имя файла (например, text.txt):");

                            if (!File.Exists(fileName))
                            {
                                Solution<char>.FillTextFile(fileName);
                                Console.WriteLine($"Файла не было, он создан и заполнен примером текста: {fileName}");
                            }

                            Console.WriteLine("Исходный файл:");
                            ShowTextFile(fileName);

                            Console.WriteLine("Результат: ");
                            Solution<char>.DigitInText(fileName);
                            break;
                        }

                    case 5:
                        {
                            string fileName = "people.txt";

                            Console.WriteLine("1.Заполнить файл случайными данными");
                            Console.WriteLine("2.Использовать уже существующий файл " + fileName);
                            int variant = Check.InputInt("Выберите вариант:", 1, 2);

                            if (variant == 1)
                            {
                                int n = Check.InputInt("Введите количество людей (от 1 до 100):", 1, 100);
                                Solution<char>.FillPeopleFile(fileName, n);
                            }

                            Console.WriteLine("Исходный файл:");
                            ShowTextFile(fileName);

                            Console.WriteLine("Результат: ");
                            Solution<char>.OldPerson(fileName);
                            break;
                        }

                    case 6:
                        {
                            Money empty = new Money();
                            Console.WriteLine("Конструктор без параметров: " + empty);

                            Money money = InputMoney("");
                            Console.WriteLine("Конструктор с параметрами: " + money);

                            money.Rubles = (uint)Check.InputInt("Введите новое значение рублей:", 0, int.MaxValue);
                            money.Kopeks = (byte)Check.InputInt("Введите новое значение копеек (от 0 до 99):", 0, 99);

                            Console.WriteLine("После изменения свойств: " + money);
                            break;
                        }

                    case 7:
                        {
                            Money money = InputMoney("");
                            uint kopeks = InputKopeks();

                            Console.WriteLine("Результат: ");
                            Console.WriteLine((money - kopeks).ToString());
                            break;
                        }

                    case 8:
                        {
                            Money money = InputMoney("");

                            Money plus = money;
                            plus++;

                            Money minus = money;
                            minus--;

                            Console.WriteLine("Исходная сумма: " + money);
                            Console.WriteLine("После ++: " + plus);
                            Console.WriteLine("После --: " + minus);
                            break;
                        }

                    case 9:
                        {
                            Money money = InputMoney("");

                            uint rubles = (uint)money;
                            bool isNotEmpty = money;

                            Console.WriteLine("Явное приведение к uint (рубли): " + rubles);
                            Console.WriteLine("Неявное приведение к bool (сумма не равна нулю): " + isNotEmpty);
                            break;
                        }

                    case 10:
                        {
                            Money money = InputMoney("");
                            uint kopeks = InputKopeks();

                            Console.WriteLine("Money - uint: " + (money - kopeks));
                            Console.WriteLine("uint - Money: " + (kopeks - money));
                            break;
                        }

                    case 11:
                        {
                            Money money1 = InputMoney("первой суммы ");
                            Money money2 = InputMoney("второй суммы ");

                            Console.WriteLine("Результат: ");
                            Console.WriteLine((money1 - money2).ToString());
                            break;
                        }

                    default:
                        {
                            ConsoleColor previousColor = Console.ForegroundColor;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Нет такой задачи, введите другой номер задачи!");
                            Console.ForegroundColor = previousColor;
                            break;
                        }
                }

                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
                Console.WriteLine("\n");
            }
        }

        static Money InputMoney(string name)
        {
            uint rubles = (uint)Check.InputInt($"Введите рубли {name}(от 0 до {int.MaxValue}):", 0, int.MaxValue);
            byte kopeks = (byte)Check.InputInt($"Введите копейки {name}(от 0 до 99):", 0, 99);

            return new Money(rubles, kopeks);
        }

        static uint InputKopeks()
        {
            return (uint)Check.InputInt($"Введите количество копеек (от 0 до {int.MaxValue}):", 0, int.MaxValue);
        }

        static string ToText<T>(IEnumerable<T> items)
        {
            StringBuilder text = new StringBuilder();

            foreach (T item in items)
            {
                text.Append(item);
                text.Append(' ');
            }

            if (text.Length == 0)
            {
                return "(пусто)";
            }

            return text.ToString().TrimEnd();
        }

        static void ShowTextFile(string path)
        {
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);

            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}

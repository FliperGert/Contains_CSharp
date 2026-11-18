using System;
using System.Collections.Generic;

namespace Contains_CSharp
{
    public class Check
    {
        static public bool IsInt(string data)
        {
            int x;

            if (Int32.TryParse(data, out x))
            {
                return true;
            }

            return false;
        }

        static public int InputInt(string info)
        {
            string data;

            do
            {
                Console.WriteLine(info);
                data = Console.ReadLine();

                if (!IsInt(data))
                {
                    Console.WriteLine("Вы ввели не целое число, повторите попытку");
                }
            }
            while (!IsInt(data));

            return Int32.Parse(data);
        }

        static public int InputInt(string info, int min, int max)
        {
            int number;

            do
            {
                number = InputInt(info);

                if (number < min || number > max)
                {
                    Console.WriteLine($"Число должно быть от {min} до {max}, повторите попытку");
                }
            }
            while (number < min || number > max);

            return number;
        }

        static public string InputString(string info)
        {
            string data;

            do
            {
                Console.WriteLine(info);
                data = Console.ReadLine();

                if (data == null || data.Trim() == "")
                {
                    Console.WriteLine("Строка не должна быть пустой, повторите попытку");
                }
            }
            while (data == null || data.Trim() == "");

            return data.Trim();
        }

        static public List<int> InputIntList(string info, int minCount)
        {
            List<int> result;
            bool isCorrect;

            do
            {
                Console.WriteLine(info);
                string data = Console.ReadLine();
                string[] parts = data.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                result = new List<int>();
                isCorrect = true;

                for (int i = 0; i < parts.Length; i++)
                {
                    if (!IsInt(parts[i]))
                    {
                        Console.WriteLine($"\"{parts[i]}\" не является целым числом, повторите попытку");
                        isCorrect = false;
                        break;
                    }

                    result.Add(Int32.Parse(parts[i]));
                }

                if (isCorrect && result.Count < minCount)
                {
                    Console.WriteLine($"Нужно ввести не меньше {minCount} элементов, повторите попытку");
                    isCorrect = false;
                }
            }
            while (!isCorrect);

            return result;
        }

        static public List<string> InputStringList(string info, bool canBeEmpty)
        {
            List<string> result;

            do
            {
                Console.WriteLine(info);
                string data = Console.ReadLine();
                string[] parts = data.Split(',');

                result = new List<string>();

                for (int i = 0; i < parts.Length; i++)
                {
                    string item = parts[i].Trim();

                    if (item != "")
                    {
                        result.Add(item);
                    }
                }

                if (result.Count == 0 && !canBeEmpty)
                {
                    Console.WriteLine("Нужно ввести хотя бы одно название, повторите попытку");
                }
            }
            while (result.Count == 0 && !canBeEmpty);

            return result;
        }
    }
}

using System;

namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine(Arr4_Task.Division(1, 99999));
        // Console.WriteLine(Arr4_Task.Division(5, 7));
        // Console.WriteLine(Arr4_Task.Division(1, 3));
        // Console.WriteLine(Arr4_Task.Division(1, 33333));
        // Console.WriteLine(Arr4_Task.Division(1, 6));
        // Console.WriteLine(Arr4_Task.Division(1, 3535));
        // Console.WriteLine(Arr4_Task.Division(5, 8));

        bool err = false;
        var rand = new Random((int) DateTime.Now.Millisecond);
        for (int i = 0; i < 1000; i++)
        {
            int b = rand.Next(1, 10000);
            int a = rand.Next(1, b);
            var actual = Arr4_Task.Division(a, b);
            var convert = Convertion(actual);
            var expect = TestDivision(a, b);
            if (convert != expect)
            {
                Console.WriteLine("Error : {0}/{1}", a, b);
                Console.WriteLine("Actual : {0}", actual);
                Console.WriteLine("Expect : {0}", expect);
                err = true;
                break;
            }

            if (i % 100 == 0)
            {
                Console.Clear();
                Console.WriteLine("Выполнено {0}%", i / 10);
            }
        }

        if (err == false)
        {
            Console.Clear();
            Console.WriteLine("Все тесты пройдены. Задание выполнено!");
        }

        Console.ReadKey();
    }

    static string Convertion(string inputString)
    {
        var maxVal = 10000;
        var result = "0.";
        int start = 0;
        int lenght = 0;
        var cycle = new int[maxVal];
        for (int i = 2; i < inputString.Length; i++)
        {
            var number = inputString.Substring(i, 1);
            if (number == "(")
                start = i;
            else if (number == ")")
                break;
            else
            {
                if (start > 0)
                {
                    lenght++;
                    cycle[i - start - 1] = int.Parse(number);
                }

                result += number;
            }
        }

        for (int i = result.Length, j = 0; i < maxVal; i++)
        {
            result += cycle[j];
            j++;
            if (j == lenght) j = 0;
        }

        return result;
    }

    static string TestDivision(int m, int n)
    {
        var maxVal = 10000;
        long q0 = m % n;
        long q = q0;
        int i = 2;
        long c = m / n;
        string result = c + ".";
        long len = maxVal;
        if (q == 0)
            return result;
        while (i < len)
        {
            long digit = (q * 10) / n;
            result += digit;
            i++;
            q = (q * 10) % n;
        }

        return result;
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/* превратить рациональную дробь a/b (0 < a < b < 100000) в десятичную   "1/6" => "0.1(6)" */
namespace ConsoleApp1;

class Arr4Task
{
    [SuppressMessage("ReSharper.DPA", "DPA0000: DPA issues")]
    public static string Division(int a, int b)
    {
        var resultingString = "0,";
        var remainders = new List<int>();
        var i = 1;
        remainders.Add(a);
        while (remainders[i - 1] > 0)  //Пока остаток от деления не станет равным нулю.
        {
            remainders.Add(0);   //На первой итерации в списке один элемент = по нулевому индексу. Сейчас индекс i = 1,
                                 //следовательно, на первом индексе мы просто забиваем слот.
            
            var x = remainders[i - 1] * 10;    //Предыдущий остаток от деления
            var resultOfDivision = x / b;
            remainders[i] = x % b;
                
            resultingString += resultOfDivision;

            for (var j = 0; j < i; j++)
            {
                if (remainders[i] != remainders[j])
                    continue; 
                return resultingString = resultingString.Insert(j + 2, "(") + ")";
            }

            i++;
        }

        return resultingString;
    }
}

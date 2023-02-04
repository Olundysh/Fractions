using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
/* превратить рациональную дробь a/b (0 < a < b < 100000) в десятичную   "1/6" => "0.1(6)" */
namespace ConsoleApp1;

class Arr4_Task
{
    public static string Division(int a, int b)
    {
        var res = "0.";
        var remainders = new List<int>();
        var i = 1;
        remainders.Add(a);
        while (remainders[i - 1] > 0)
        {
            remainders.Add(0);
            int x = remainders[i - 1] * 10;
            int currentDigit = (x - x % b) / b;
            remainders[i] = x % b;
                
            res += currentDigit;

            for (var j = 0; j < i; j++)
            {
                if (remainders[i] != remainders[j])
                    continue;
                res = res.Insert(j + 2, "(") + ")";
                remainders[i] = 0;
            }

            i++;
        }

        return res;
    }
}

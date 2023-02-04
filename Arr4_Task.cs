using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* превратить рациональную дробь a/b (0 < a < b < 100000) в десятичную   "1/6" => "0.1(6)" */
namespace ConsoleApp1
{
    class Arr4_Task
    {
        public static string Division(int a, int b)
        {
            var remainOfDivision = a;
            var growingString = "";
            var endOfPeriod = 0;
            var startOfPeriod = 0;
            
            for (var i = 0; i < 100; i++)
            {
                var resultOfDivision = 0;
                
                resultOfDivision = remainOfDivision * 10 / b;
                
                remainOfDivision = remainOfDivision * 10 % b;
                growingString += resultOfDivision;
                
                if (i > 0)
                {
                    for (var j = 1; j < 100; j++)
                    {
                        resultOfDivision = remainOfDivision * 10 / b;
                
                        remainOfDivision = remainOfDivision * 10 % b;
                        growingString += resultOfDivision;
                        
                        if (remainOfDivision == 0)
                        {
                            return "0," + growingString.TrimEnd('0');
                        }
                        
                        if (growingString[i-1] == growingString[j] && growingString[i-1] != '0')
                        {
                            startOfPeriod = i-1;
                            endOfPeriod = j;
                            return "0," + growingString.Substring(0, startOfPeriod) + "(" +
                                   growingString.Substring(startOfPeriod, endOfPeriod) + ")";
                        } 
                        
                        if (growingString[i-1] == '0')
                        {
                            for (var k = 0; k < 100; k++)
                            {
                                resultOfDivision = remainOfDivision * 10 / b;
                
                                remainOfDivision = remainOfDivision * 10 % b;
                                growingString += resultOfDivision;
                        
                        
                                if (growingString[k] != '0')
                                {
                                    startOfPeriod = i-1;
                                    endOfPeriod = k;
                                    return "0," + growingString.Substring(0, startOfPeriod) + "(" +
                                           growingString.Substring(startOfPeriod, endOfPeriod+1) + ")";
                                }
                            }
                        }
                    }
                }
            }

            return "0," + growingString.Substring(0, startOfPeriod) + "(" +
                   growingString.Substring(startOfPeriod, endOfPeriod+1) + ")";
        }
    }
}
    
    
   

         


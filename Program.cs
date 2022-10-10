using System;
using System.Reflection.Metadata.Ecma335;

namespace DelegatsEventLONQ
{
    class Program
    {   delegate double? operation(double? x, double y);
        static double? Add(double? x, double y) => x + y;
        static double? Resume(double? x, double y) => x - y;
        static double? Multy(double? x, double y) => x * y;
        static double? Division(double? x, double y) => (y==0)?null:(x / y);
        static void Main(string[] args)
        {  
            operation? op=null;
            Console.WriteLine("Введите x");
            double x=Double.Parse(Console.ReadLine());
            Console.WriteLine("Введите у");
            double y = Double.Parse(Console.ReadLine());
           // Console.WriteLine("Введите операцию");
           // char c = Char.Parse(Console.ReadLine());
           // bool end = false;
           // switch (c)
           // {
           //     case '+': op += Add; break;
           //     case '-': op += Resume; break;
           //     case '*': op += Multy; break;
           //     case '/': op += Division; break;
           // }
           //
           Console.WriteLine("Введите операции (= конец ввода)");
           char[] arrc=Console.ReadLine().ToArray();
           bool end = false;
           foreach (char c in arrc)
           {
               switch (c)
               {
                   case '+': op += Add; break;
                   case '-': op += Resume; break;
                   case '*': op += Multy; break;
                   case '/': op += Division; break;
                   case '=': end = true; break;
               }
               if (end) break;
           }
            double? res=x;
            foreach (operation item in op.GetInvocationList())
            {
                res = item?.Invoke(res, y);
            }
           
            Console.WriteLine($"Результат: {(((op==null)?"Операции не задано":(res==null)?"не может быть найден":res))}");
           // Console.WriteLine($"Результат: {(((op == null) ? "Операции не задано" : (op(x,y) == null) ? "не может быть найден" : op(x,y)))}");
        }
    }
}

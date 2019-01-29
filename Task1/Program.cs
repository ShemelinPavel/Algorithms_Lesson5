/*

Shemelin Pavel

1

Реализовать перевод из 10 в 2 систему счисления с использованием стека

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main( string[] args )
        {
            uint Number = 101;
            uint NumberControl = 101;

            Stack<uint> binStack = new Stack<uint>();

            string Print()
            {
                StringBuilder res = new StringBuilder();
                while (binStack.Count != 0) res.Append( binStack.Pop() );

                return res.ToString();
            }

            do
            {
                binStack.Push( Number % 2 );
                Number /= 2;

            } while ( Number != 0) ;

            Console.WriteLine( $"Конвертация десятичного числа в двоичное через стек:   {NumberControl} -> {Print()}");
            Console.WriteLine( $"Конвертация (проверочная) средствами среды .Net:       {NumberControl} -> {Convert.ToString( NumberControl, 2 )}" );

            Console.ReadKey();
        }
    }
}

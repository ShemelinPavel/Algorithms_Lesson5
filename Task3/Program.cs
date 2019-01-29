/*

Shemelin Pavel

3

Написать программу, которая определяет, является ли введенная скобочная последовательность правильной.
Примеры правильных скобочных выражений: (), ([])(), {}(), ([{}]), неправильных — )(, ())({), (, ])}), ([(]) для скобок [,(,{.
Например: (2+(2*2)) или [2/{5*(4+7)}]

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main( string[] args )
        {

            // словарь правильных сочетаний скобок - ключи открывающиеся скобки, значения - закрывающиеся
            Dictionary<char, char> brktCorretDict = new Dictionary<char, char>();
            brktCorretDict.Add( '[', ']' );
            brktCorretDict.Add( '{', '}' );
            brktCorretDict.Add( '(', ')' );
            brktCorretDict.Add( '<', '>' );

            //стак со скобками
            //если новый символ из строки - закрывающаяся скобка,
            //а верхний элемент стака - соответсвтующаяся открывающаяся скобка из словаря
            //верхний символ стака удаляется
            Stack<char> brktStack = new Stack<char>();

            Console.Write( "Введите скобочную последовательность:" );

            string brktSequence = Console.ReadLine();

            foreach (char item in brktSequence)
            {
                if (brktCorretDict.ContainsKey( item )) brktStack.Push( item );
                else if (brktCorretDict.ContainsValue( item ))
                {
                    KeyValuePair<char, char> keyValuePair = brktCorretDict.Where( kvp => kvp.Value == item ).First();

                    if (brktStack.Peek() == keyValuePair.Key) brktStack.Pop();
                    else brktStack.Push( item );
                }
            }

            //если стак пустой - значит скобочная последовательность верна

            if (brktStack.Count == 0) Console.WriteLine( $"Скобочная последовательность: {brktSequence} верна." );
            else Console.WriteLine( $"Скобочная последовательность: {brktSequence} не корректна!" );

            Console.ReadKey();
        }
    }
}

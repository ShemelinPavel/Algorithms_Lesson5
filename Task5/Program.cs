/*

Shemelin Pavel

5

Реализовать алгоритм перевода из инфиксной записи арифметического выражения в постфиксную

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main( string[] args )
        {
            /* Алгоритм Дейкстpы

            а) если стек пуст, то опеpация из входной стpоки пеpеписывается в стек;
            б) опеpация выталкивает из стека все опеpации с большим или pавным пpиоpитетом в выходную стpоку;
            в) если очеpедной символ из исходной стpоки есть откpывающая скобка, то он пpоталкивается в стек;
            г) закpывающая кpуглая скобка выталкивает все опеpации из стека до ближайшей откpывающей скобки, сами скобки в выходную стpоку не пеpеписываются, а уничтожают дpуг дpуга.

            */

            //стринг-билдер для формирования результирующей строки
            StringBuilder res = new StringBuilder();

            //словарь приоритетов арифм. операций
            Dictionary<char, int> operationPriority = new Dictionary<char, int>();

            operationPriority.Add( '(', 0 );
            operationPriority.Add( ')', 1 );
            operationPriority.Add( '+', 2 );
            operationPriority.Add( '-', 2 );
            operationPriority.Add( '*', 3 );
            operationPriority.Add( '/', 3 );

            //получить приоритет операции из словаря
            int GetOperationPriority( char oper )
            {
                KeyValuePair<char, int> val = operationPriority.Where( kvp => kvp.Key == oper ).First();
                return val.Value;
            }

            //Console.Write( "Введите строку с арифметической операцией: " );
            //string operationTxt = Console.ReadLine();

            //исходная строка с арифм. операцией
            string operationTxt = "(A+B)*(C+D)-E";

            //стак арифм. операций
            Stack<char> operationStack = new Stack<char>();

            foreach (char item in operationTxt)
            {
                if (operationPriority.ContainsKey( item ))
                {
                    if (operationStack.Count == 0)
                    {
                        operationStack.Push( item );
                    }
                    else if (item == '(')
                    {
                        operationStack.Push( item );
                    }
                    else if (item == ')')
                    {
                        bool exitflag = true;

                        do
                        {
                            char o_s_item = operationStack.Pop();
                            if (o_s_item == '(') exitflag = false;
                            else res.Append( o_s_item );

                        } while (exitflag);
                    }
                    else if (GetOperationPriority( item ) <= GetOperationPriority( operationStack.Peek() ))
                    {
                        bool exitflag = true;
                        do
                        {
                            res.Append( operationStack.Pop() );
                            if (operationStack.Count == 0 || GetOperationPriority( item ) > GetOperationPriority( operationStack.Peek() )) exitflag = false;

                        } while (exitflag);
                        operationStack.Push( item );
                    }
                    else operationStack.Push( item );
                }
                else res.Append( item );
            }
            //если операции остались в стеке - допиешем их в строку с результатом
            while (operationStack.Count != 0)
            {
                res.Append( operationStack.Pop() );
            }

            Console.WriteLine( $"\nИсходная операция: {operationTxt}" );
            Console.WriteLine( $"\nПостфиксная операция: {res.ToString()}" );

            Console.ReadKey();
        }
    }
}

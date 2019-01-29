/*

Shemelin Pavel

6 

Реализовать очередь

*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{

    class Program
    {

        /// <summary>
        /// шаблонный класс очереди
        /// </summary>
        /// <typeparam name="T">тип значений очереди</typeparam>
        public class newQueue<T>: IEnumerable
        {
            /// <summary>
            /// массив значений очереди
            /// </summary>
            T[] arr;

            /// <summary>
            /// размер очереди
            /// </summary>
            int size;

            /// <summary>
            /// номинальный размер (вместимость массива) очереди
            /// </summary>
            const int def_cap = 10;

            /// <summary>
            /// реальная вместимость очереди 
            /// </summary>
            int cap;

            //голова очереди
            int h;

            //хвост очереди
            int t;

            /// <summary>
            /// конструктор объекта Очередь
            /// </summary>
            public newQueue()
            {
                this.cap = def_cap;
                this.arr = new T[this.cap];
                this.size = 0;
                this.h = -1;
                this.t = 0;
            }

            /// <summary>
            /// количество элементов в очереди
            /// </summary>
            public int Count => this.size;

            /// <summary>
            /// очередь пуста
            /// </summary>
            /// <returns>очередь пуста - true/false</returns>
            public bool IsEmpty()
            {
                return this.size == 0;
            }

            /// <summary>
            /// добавить элемент в хвост очереди
            /// </summary>
            /// <param name="newElement">новый элемент очереди типа T</param>
            public void Enqueue(T newElement)
            {
                if (this.size == this.cap)
                {
                    T[] newArr = new T[this.cap * 2];
                    Array.Copy( this.arr, newArr, this.arr.Length );
                    this.arr = newArr;
                    this.cap *= 2;
                }
                this.size++;
                this.arr[this.t++] = newElement;
            }

            /// <summary>
            /// удалить элемент из головы очереди
            /// </summary>
            /// <returns></returns>
            public T Dequeue()
            {
                if (this.size == 0) throw new Exception( "This queue is empty" );
                this.size--;

                return this.arr[++this.h];
            }

            /// <summary>
            /// реализация интерфейса IEnumerable
            /// </summary>
            /// <returns>перечислитель коллекции очереди</returns>
            public IEnumerator GetEnumerator()
            {
                if (this.size == 0) throw new Exception( "This queue is empty" );

                for (int i = this.h + 1; i < this.t; i++)
                {
                    yield return this.arr[i];
                }
            }
        }

        static void Main( string[] args )
        {

            newQueue<string> q = new newQueue<string>();

            void Print<T>( newQueue<T> qe )
            {
                foreach (var item in qe)
                {
                    Console.WriteLine( item );
                }
            }

            q.Enqueue( "1" );
            q.Enqueue( "2" );
            q.Enqueue( "3" );
            q.Enqueue( "4" );
            q.Enqueue( "5" );
            q.Enqueue( "6" );
            q.Enqueue( "7" );
            q.Enqueue( "8" );
            q.Enqueue( "9" );
            q.Enqueue( "10" );
            q.Enqueue( "11" );
            q.Enqueue( "12" );

            Console.WriteLine( "Исходная очередь:\n" );
            Print<string>( q );

            Console.WriteLine( $"Удаляем значение из очереди: {q.Dequeue()}\n" );
            Console.WriteLine( $"Удаляем значение из очереди: {q.Dequeue()}\n" );
            Console.WriteLine( $"Удаляем значение из очереди: {q.Dequeue()}\n" );

            q.Enqueue( "13" );
            Console.WriteLine( $"Добавляем значение в очередь: 13\n" );
            q.Enqueue( "14" );
            Console.WriteLine( $"Добавляем значение в очередь: 14\n" );

            Console.WriteLine( "Состояние очереди:\n" );
            Print<string>( q );

            Console.ReadKey();
        }
    }
}

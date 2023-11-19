using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hazi1
{
    internal class Program
    {
        class Elem<T>
        {
            public T tartalom;
            public Elem<T> under;

            public Elem()
            {
                this.under = this;
            }

            public Elem(T tartalom)
            {
                this.tartalom = tartalom;
                this.under = null;
            }
        }
        class lancolt_verem<T>
        {
            private Elem<T> bottom;
            private int count;

            public lancolt_verem()
            {
                bottom = new Elem<T>();
                bottom.under = bottom;
                count = 0;
            }

            public void Push(T tartalom)
            {
                Elem<T> uj = new Elem<T>(tartalom);
                uj.under = bottom.under;
                bottom.under = uj;
                count++;
            }
            public T Pop()
            {
                Elem<T> aktelem = bottom.under;
                bottom.under = bottom.under.under;
                count--;
                return aktelem.tartalom;
            }

            public T Peek() => bottom.under.tartalom;

            public bool Empty() => count == 0;

            public int Count { get => count; }

            public void Kiir()
            {
                Elem<T> aktelem = bottom.under;
                while (aktelem != bottom)
                {
                    Console.WriteLine(aktelem.tartalom);
                    aktelem = aktelem.under;
                }
            }
        }



        static void Main(string[] args)
        {
            lancolt_verem<int> tomb = new lancolt_verem<int>();
            Console.WriteLine("1. feladat:");
            tomb.Push(1);
            tomb.Push(4);
            tomb.Push(2);
            tomb.Push(6);
            tomb.Push(3);
            tomb.Push(5);
            tomb.Kiir();
            Console.WriteLine("2. feladat:");
            Console.WriteLine(tomb.Pop());
            Console.WriteLine(tomb.Pop());
            Console.WriteLine("3. feladat:");
            Console.WriteLine(tomb.Peek());
            Console.WriteLine("4. feladat:");
            Console.WriteLine(tomb.Empty());
            Console.WriteLine("5. feladat:");
            Console.WriteLine(tomb.Count);
        }
    }
}
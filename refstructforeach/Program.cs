using System;
using static System.Console;

namespace spanforeach
{
    class Program
    {
        static void Main(string[] args)
        {
            // This app demonstrates various patterns for using
            // forach with ref structs.
            // ref structs cannot implement interfaces, so IEnumerable isn't an option
            int[] data = new int[] {0,1,2,3,4};
            var foo = new Foo(data);
            Span<int> data2 = data;
            var bar = new Bar(data2[2..^1]);

            WriteLine("foreach over foo");
            foreach (var f in foo)
            {
                Console.WriteLine(f);
            }

            WriteLine("foreach over bar");
            foreach (var b in bar)
            {
                Console.WriteLine(b);
            }

            WriteLine("foreach over a span");
            foreach (var s in data2)
            {
                Console.WriteLine(s);
            }
        }
    }
}

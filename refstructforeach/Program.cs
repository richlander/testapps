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
            Span<int> data = new int[] { 0, 1, 2, 3, 4, 5, 6};
            var foo = new Foo(data);
            var bar = new Bar(data[2..^1]);

            WriteLine("foreach over foo, using custom enumerator");
            foreach (var f in foo)
            {
                Console.WriteLine(f);
            }

            WriteLine("foreach over bar, using spans enumerator");
            foreach (var b in bar)
            {
                Console.WriteLine(b);
            }

            WriteLine("foreach over a span directly");
            foreach (var s in data)
            {
                Console.WriteLine(s);
            }

            // create holder value for remaining examples
            var holder = new TwoFooHolder(foo, new Foo(data[3..^2]));

            WriteLine("foreach over two Foos");
            foreach(var f in holder)
            {
                foreach(var num in f)
                {
                    WriteLine(num);
                }
            }

            WriteLine("indexer access over two Foos");
            for (int i = 0; i < 2;i++)
            {
                var f = holder[i];
                foreach(var num in f)
                {
                    WriteLine(num);
                }
            }

            WriteLine("Randomly access Foos");
            for (int i = 0; i < 2;i++)
            {
                var foo1 = holder[i];
                var foo2 = holder[(i+1) % 2];

                WriteLine($"Foo1 length: {foo1.Length}; Foo2 length: {foo2.Length}");
            }
        }
    }
}

/*
Output:

foreach over foo, using custom enumerator
0
1
2
3
4
5
6
foreach over bar, using spans enumerator
2
3
4
5
foreach over a span directly
0
1
2
3
4
5
6
foreach over two Foos
0
1
2
3
4
5
6
3
4
indexer access over two Foos
0
1
2
3
4
5
6
3
4
Randomly access Foos
Foo1 length: 7; Foo2 length: 2
Foo1 length: 2; Foo2 length: 7
*/

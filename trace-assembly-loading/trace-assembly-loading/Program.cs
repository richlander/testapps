using System;
using System.Runtime.Loader;
using library;
using static System.Console;

namespace trace_assembly_loading
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");
            PrintAssemblies();
            WriteLine("Press any key to continue ...");
            ReadKey();
            WriteLine("Call into `library` assembly");
            GetFoo();
            PrintAssemblies();
        }

        static void PrintAssemblies()
        {
            WriteLine("Assemblies loaded:");
            foreach (var asm in AssemblyLoadContext.Default.Assemblies)
            {
                if (asm.FullName.StartsWith("System")) {continue;}
                WriteLine(asm.FullName);
            }
        }

        static string GetFoo()
        {
            return library.Class1.Foo;
        }
    }
}

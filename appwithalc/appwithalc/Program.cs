using System;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using interfaces;
using static System.Console;

namespace appwithalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ALC(World)!");

            // print all ALCs
            PrintAlcs();

            // get default ALC
            PrintAssemblies(AssemblyLoadContext.Default);


            var libPath = Path.Combine(
                AppContext.BaseDirectory,
                "library.dll"
            );

            // create custom load context
            // load "library" assembly
            var alcName = "my customer ALC";
            WriteLine();
            WriteLine($"Load library assembly via new \"{alcName}\" ALC"); ;
            var pc = new PrivateContext(alcName);
            // load library
            var library = pc.LoadFromAssemblyPath(libPath);
            var foo = library.CreateInstance<IFoo>("library.Foo");
            WriteLine($"Foo: {foo.GetFoo()}");
            
            PrintAssemblies(pc);

            // print all ALCs
            PrintAlcs();

            // load "library" assembly via Assembly.LoadFile
            // this will create an ALC just for it and any dependencies not in the default ALC
            // it will not conflict with the custom PrivateContext ALC created above
            WriteLine();
            WriteLine($"Load library assembly via Assembly.LoadFile"); ;
            var library2 = Assembly.LoadFile(libPath);
            var foo2 = library.CreateInstance<IFoo>("library.Foo");
            WriteLine($"Foo: {foo2.GetFoo()}");

            // print all ALCs
            PrintAlcs();

        }

        private static void PrintAlcs()
        {
            WriteLine();
            WriteLine("Enumerate over all ALCs:");
            foreach (var alc in AssemblyLoadContext.All)
            {
                WriteLine(alc.Name);
            }
        }

        private static void PrintAssemblies(AssemblyLoadContext context)
        {
            WriteLine();
            WriteLine($"Enumerate over all assemblies in \"{context.Name}\" ALC:");
            foreach (var assembly in context.Assemblies)
            {
                WriteLine(assembly.FullName);
            }
        }
    }
}

using System;

namespace readstdin
{
    class Program
    {
        static void Main(string[] args)
        {
            // If using VS Code, ensure you do not use (for this app):
            // "console": "internalConsole"
            // Instead use:
            // "console": "externalTerminal"

            // To run this program, try:
            // dotnet run
            // echo foo | dotnet run

            string line = null;
            if (Console.IsInputRedirected)
            {
                while ((line = Console.In.ReadLine()) is object)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("I wanted content from standard in and only got this useless string");
            }
        }
    }
}

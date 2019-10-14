using System;
using static System.Console;

namespace index_and_range
{
    class Program
    {
        static void Main(string[] args)
        {
            // start with int[]
            int[] arrayOfNums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int lastNum = arrayOfNums[^1]; // 10
            int[] subArrayOfNums = arrayOfNums[2..6]; // {3, 4, 5, 6}

            PrintValues(nameof(arrayOfNums), arrayOfNums);
            WriteLine($"{nameof(lastNum)}: {lastNum}");
            PrintValues(nameof(subArrayOfNums), subArrayOfNums);

            // Create a Memory<int> using arrayofNums as input
            // Create no-copy slices of the array
            Memory<int> memoryOfNums = arrayOfNums;
            Memory<int> lastTwoNums = memoryOfNums[^2..];
            Memory<int> middleNums = memoryOfNums[4..8]; // {5, 6, 7, 8}

            PrintValues(nameof(memoryOfNums), memoryOfNums.Span);
            PrintValues(nameof(lastTwoNums), lastTwoNums.Span);
            PrintValues(nameof(middleNums), middleNums.Span);


            // Create a substring using a range
            string myString = "0123456789ABCDEF";
            string substring = myString[0..5]; // "01234"

            PrintValues(nameof(myString), myString);
            PrintValues(nameof(substring), substring);

            // Create a Memory<char> using a range
            ReadOnlyMemory<char> myChars = myString.AsMemory();
            ReadOnlyMemory<char> firstChars = myChars[0..5]; // {'0', '1', '2', '3', '4'}

            PrintValues(nameof(myChars), myChars.Span);
            PrintValues(nameof(firstChars), firstChars.Span);

            // Get an offset with an Index
            Index indexFromEnd = Index.FromEnd(3); // equivalent to [^3]
            int offsetFromLength = indexFromEnd.GetOffset(10); // 7
            int value = arrayOfNums[offsetFromLength]; // 8

            WriteLine($"{nameof(indexFromEnd)}: {indexFromEnd}");
            WriteLine($"{nameof(offsetFromLength)}: {offsetFromLength}");
            WriteLine($"{nameof(value)}: {value}");

            // Get an offset with a Range
            Range rangeFromEnd = 5..^0;
            (int offset, int length) = rangeFromEnd.GetOffsetAndLength(10); // offset = 5, length = 5
            Memory<int> values = memoryOfNums.Slice(offset, length); // {6, 7, 8, 9, 10}

            PrintValues(nameof(values), values.Span);
        }

        static void PrintValues(string name, Span<int> values)
        {
            Write($"{name}: ");
            var first = true;
            foreach(var v in values)
            {
                if (!first)
                {
                    Write($",{v}");
                    
                }
                else
                {
                    first = false;
                    Write(v);
                }
            }
            WriteLine();
        }

        static void PrintValues(string name, ReadOnlySpan<char> values)
        {
            Write($"{name}: ");
            var first = true;
            foreach (var v in values)
            {
                if (!first)
                {
                    Write($",{v}");

                }
                else
                {
                    first = false;
                    Write(v);
                }
            }
            WriteLine();
        }

    }
}

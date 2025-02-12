using System;
using TextFile;

namespace AllEven
{
    class Program
    {
        static void Main()
        {
            TextFileReader reader = new ("input.txt");
            bool l = true;
            while (reader.ReadInt(out int e) )
                if (!(l = e % 2 == 0)) break;
            Console.WriteLine(l?"igaz":"hamis");
            //Console.WriteLine(Examine(ref reader) ? "igaz":"hamis");
        }

        //static bool Examine(ref TextFileReader reader)
        //{
        //    while (reader.ReadInt(out int e))
        //    {
        //        if (e % 2 != 0) return false;
        //    }
        //    return true;
        //}
    }
}

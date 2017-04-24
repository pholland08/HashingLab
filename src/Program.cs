using HashingLab.src;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO Open file for reading
            string[] lines = System.IO.File.ReadAllLines("./../../input/words.txt");
            //string[] lines = System.IO.File.ReadAllLines("./../../input/phil.txt");

            // Create or erase output file
            File.Create("./../../input/output.txt").Close();
            StreamWriter file = new System.IO.StreamWriter("./../../input/output.txt", true);

            // TODO Initialize hash table
            MyHashTable table = new MyHashTable(128);

            // While less than 40% full, add entries to table
            int CurrentLine = 0;
            //while (table.CurrentCapacity < (table.Length * .4d)) { table.Add(lines[CurrentLine++]); }
            while (table.CurrentCapacity < (table.Length * .99d)) { table.Add(lines[CurrentLine++]); }

            // TODO Get min, max, and avg #probes for the first 30 words
            CurrentLine = 0;
            int ProbeSum = 0;
            int ProbeMin = table.Length;
            int ProbeMax = -1;
            while (CurrentLine < table.CurrentCapacity)
            {
                MyHashNode retrieved = table.Get(lines[CurrentLine]);
                ProbeSum += retrieved.ProbeCount;
                ProbeMin = retrieved.ProbeCount < ProbeMin ? retrieved.ProbeCount : ProbeMin;
                ProbeMax = retrieved.ProbeCount > ProbeMax ? retrieved.ProbeCount : ProbeMax;
                CurrentLine++;
            }
            // TODO Get min, max, and avg #probes for the last 30 words
            
            // TODO Print table
            Console.WriteLine(table.ToString());
            file.Write(table.ToString());

            // 
            file.WriteLine($"Minimum number of probes: {ProbeMin}");
            file.WriteLine($"Maximum number of probes: {ProbeMax}");
            file.WriteLine($"average number of probes: {(double)ProbeSum / table.CurrentCapacity}");
            file.Close();
            Console.WriteLine($"Minimum number of probes: {ProbeMin}");
            Console.WriteLine($"Maximum number of probes: {ProbeMax}");
            Console.WriteLine($"average number of probes: {(double)ProbeSum / table.CurrentCapacity}");
            double a = (double)table.CurrentCapacity / (double)table.Length;
            double E = (1 - a / 2) / (1 - a);
            Console.WriteLine($"Load factor (alpha): {a}");
            Console.WriteLine($"Expected number of probes: {E}");

            // End program
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}

using System;
using System.IO;

namespace LTDT
{
    class MaTranKe
    {
        public int n;
        public int[,] a;
        public MaTranKe()
        { }
        public MaTranKe(string filename)
        {
            bool result = load(filename);
            if (result == false)
                Console.WriteLine("Error during file loaded.");
        }
        public bool Read(string filename)
        {
            return load(filename);
        }
        public void Show()
        {
            Console.WriteLine(n);
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
        }
        private bool load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("This file does not exist.");
                return false;
            }
            string[] lines = File.ReadAllLines(filename);
            n = Int32.Parse(lines[0]);
            a = new int[n, n];
            for (int i = 0; i < n; ++i)
            {
                string[] tokens = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < n; ++j)
                    a[i, j] = Int32.Parse(tokens[j]);
            }
            return true;
        }
    }
}

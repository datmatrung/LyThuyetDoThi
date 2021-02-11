using System;
using System.Collections.Generic;
using System.IO;

namespace LTDT
{
    class DanhSachKe
    {
        public int n;
        public List<int>[] a;
        public DanhSachKe()
        { }
        public DanhSachKe(string filename)
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
                Console.Write(a[i].Count + " ");
                for (int j = 0; j < a[i].Count; ++j)
                    Console.Write(a[i][j] + " ");
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
            a = new List<int>[n];
            for (int i = 0; i < n; ++i)
            {
                string[] tokens = lines[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int m = Int32.Parse(tokens[0]);
                a[i] = new List<int>();
                for (int j = 0; j < m; ++j)
                    a[i].Add(Int32.Parse(tokens[j+1]));
            }
            return true;
        }
    }
}

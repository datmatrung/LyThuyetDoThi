using System;
using System.Collections.Generic;

namespace LTDT
{
    class LienThong
    {
        private int V;
        private List<int>[] a;
        private MaTranKe g = new MaTranKe();
        public LienThong() { }
        private LienThong(int v)
        {
            V = v;
            a = new List<int>[v];
            for (int i = 0; i < v; ++i)
                a[i] = new List<int>();
        }
        private void ThemCanh(int v, int u)
        {
            a[v].Add(u);
        }
        private void DFS(int v, bool[] tham)
        {
            tham[v] = true;
            List<int> ds = a[v];
            foreach (var n in ds)
            {
                if (!tham[n])
                    DFS(n, tham);
            }
        }
        private int[,] TaoMaTranDuongDi()
        {
            int n = g.n;
            LienThong f = new LienThong(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (g.a[i, j] == 1)
                        f.ThemCanh(i, j);
                }
            }
            int[,] A = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                bool[] tham = new bool[n];
                f.DFS(i, tham);
                for (int j = 0; j < n; j++)
                {
                    if (tham[j] == true)
                        A[i, j] = 1;
                }
            }
            return A;
        }
        private bool LienThongManh()
        {
            int[,] A = TaoMaTranDuongDi();
            bool LienThongManh = true;
            for (int i = 0; i < g.n; i++)
            {
                for (int j = 0; j < g.n; j++)
                {
                    if (A[i, j] == 0)
                    {
                        LienThongManh = false;
                        break;
                    }
                }
            }
            return LienThongManh;
        }
        private bool LienThongTungPhan()
        {
            int[,] A = TaoMaTranDuongDi();
            bool LienThongTungPhan = true;
            for (int i = 0; i < g.n; i++)
            {
                for (int j = 0; j < g.n; j++)
                {
                    if (A[i, j] == 0 & A[j, i] == 0)
                    {
                        LienThongTungPhan = false;
                        break;
                    }
                }
            }
            return LienThongTungPhan;
        }
        private bool LienThongYeu()
        {
            int n = g.n;
            LienThong f = new LienThong(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (g.a[i, j] == 1)
                        f.ThemCanh(i, j);
                }
            }
            LienThong k = new LienThong(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < f.a[i].Count; j++)
                {
                    k.ThemCanh(i, f.a[i][j]);
                    k.ThemCanh(f.a[i][j], i);
                }
            }
            int[,] A = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                bool[] tham = new bool[n];
                k.DFS(i, tham);
                for (int j = 0; j < n; j++)
                {
                    if (tham[j] == true)
                        A[i, j] = 1;
                }
            }
            bool LienThongYeu = true;
            for (int i = 0; i < g.n; i++)
            {
                for (int j = 0; j < g.n; j++)
                {
                    if (A[i, j] == 0)
                    {
                        LienThongYeu = false;
                        break;
                    }
                }
            }
            return LienThongYeu;
        }
        public void Xuat(string filename)
        {
            g.Read(filename);
            if (LienThongManh())
                Console.WriteLine("Do thi lien thong manh");
            else if (LienThongTungPhan())
                Console.WriteLine("Do thi lien thong tung phan");
            else if (LienThongYeu())
                Console.WriteLine("Do thi lien thong yeu");
            else
                Console.WriteLine("Do thi khong lien thong");
        }
    }
}

using System;
using System.Collections.Generic;

namespace LTDT
{
    class TPLT
    {
        MaTranKe g = new MaTranKe();
        Stack<int> S = new Stack<int>();
        bool[] tham;
        private void NhapDFS(int dinh)
        {
            tham[dinh] = true;
            for (int i = 0; i < g.n; i++)
            {
                if (g.a[dinh, i] == 1 && !tham[i])
                    NhapDFS(i);
            }
            S.Push(dinh);
        }
        private void DaoNguoc()
        {
            for (int i = 0; i < g.n; i++)
            {
                for (int j = 0; j < g.n; j++)
                {
                    if (g.a[i, j] == 1)
                    {
                        g.a[i, j] = 0;
                        g.a[j, i] = 2;
                    }
                }
            }
        }
        private void XuatDFS(int dinh)
        {
            tham[dinh] = true;
            Console.Write(dinh + " ");
            for (int v = 0; v < g.n; v++)
            {
                if (g.a[dinh, v] == 2 && !tham[v])
                    XuatDFS(v);
            }
        }
        public void Xuat(string filename)
        {
            g.Read(filename);
            tham = new bool[g.n];
            for (int dinh = 0; dinh < g.n; dinh++)
            {
                if (!tham[dinh])
                    NhapDFS(dinh);
            }
            DaoNguoc();
            tham = new bool[g.n];
            int i = 1;
            while (S.Count > 0)
            {
                int dinh = S.Pop();
                if (!tham[dinh])
                {
                    Console.Write($"Thanh phan lien thong manh {i}: ");
                    XuatDFS(dinh);
                    i++;
                    Console.WriteLine();
                }
            }
        }
    }
}

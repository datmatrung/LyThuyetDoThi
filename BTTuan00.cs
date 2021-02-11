using System;
using System.Collections.Generic;

namespace LTDT
{
    class BTTuan00
    {
        public void DocMaTranKe(string filename)
        {
            MaTranKe g = new MaTranKe(filename);
            g.Show();

            bool LaDoiXung = true;
            for (int i = 0; i < g.n && LaDoiXung; ++i)
            {
                int j;
                for (j = i + 1; j < g.n && g.a[i, j] == g.a[j, i]; ++j) ;
                if (j < g.n)
                    LaDoiXung = false;
            }
            if (LaDoiXung == false)
                Console.WriteLine("Ma tran khong doi xung");
            else
                Console.WriteLine("Ma tran doi xung");
        }
        public void DocDanhSachKe(string filename)
        {
            DanhSachKe g = new DanhSachKe(filename);
            g.Show();
            bool LaVoHuong = true;
            for (int i = 0; i < g.n && LaVoHuong; ++i)
            {
                int j;
                for (j = 0; j < g.a[i].Count && g.a[g.a[i][j]].Contains(i); ++j) ;
                if (j < g.a[i].Count)
                    LaVoHuong = false;
            }
            if (LaVoHuong == false)
                Console.WriteLine("Danh sach ke bieu dien do thi mot chieu");
            else
                Console.WriteLine("Danh sach ke bieu dien do thi hai chieu");
        }
        public void ChuyenMaTranThanhDanhSach(string namein, string nameout)
        {
            MaTranKe am = new MaTranKe(namein);
            DanhSachKe al = new DanhSachKe();
            al.n = am.n;
            al.a = new List<int>[al.n];
            for (int i = 0; i < am.n; ++i)
            {
                al.a[i] = new List<int>();
                for (int j = 0; j < am.n; ++j)
                    if (am.a[i, j] != 0)
                        al.a[i].Add(j);
            }
            // write to file
            string content = al.n.ToString();
            for (int i = 0; i < al.n; ++i)
            {
                string s = Environment.NewLine + al.a[i].Count.ToString();
                for (int j = 0; j < al.a[i].Count; ++j)
                    s = s + " " + al.a[i][j].ToString();
                content = content + s;
            }
            System.IO.File.WriteAllText(nameout, content);
            Console.WriteLine("Da chuyen tu ma tran ke sang danh sach ke");
        }
        public void ChuyenDanhSachThanhMaTran(string namein, string nameout)
        {
            DanhSachKe al = new DanhSachKe(namein);
            MaTranKe am = new MaTranKe();
            am.n = al.n;
            am.a = new int[am.n, am.n];
            Array.Clear(am.a, 0, am.a.Length);
            for (int i = 0; i < am.n; ++i)
            {
                for (int j = 0; j < al.a[i].Count; ++j)
                    am.a[i, al.a[i][j]] = 1;
            }
            // write to file
            string content = am.n.ToString();
            for (int i = 0; i < am.n; ++i)
            {
                string s = Environment.NewLine;
                for (int j = 0; j < am.n; ++j)
                    s = s + am.a[i, j].ToString() + " ";
                content = content + s;
            }
            System.IO.File.WriteAllText(nameout, content);
            Console.WriteLine("Da chuyen tu danh sach ke sang ma tran ke");
        }
    }
}

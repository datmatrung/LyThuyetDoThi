using System;

namespace LTDT
{
    class BTTuan01
    {
        MaTranKe g = new MaTranKe();
        public void XuatCau1(string filename)
        {
            g.Read(filename);
            if (TinhDoiXung() == true)
                XuLyDoThiVoHuong();
            else
                XuLyDoThiCoHuong();
        }
        private bool TinhDoiXung()
        {
            int i, j;
            bool laDoiXung = true;
            for (i = 0; i < g.n && laDoiXung; ++i)
            {
                for (j = i + 1; (j < g.n) && (g.a[i, j] == g.a[j, i]); ++j) ;
                if (j < g.n)
                    laDoiXung = false;
            }
            return laDoiXung;
        }

        private void XuLyDoThiVoHuong()
        {
            g.Show();
            Console.WriteLine("Do thi vo huong");
            Console.WriteLine($"So dinh cua do thi: {g.n}");
            int[] BacDinh = new int[g.n];
            DemBacDinh(ref BacDinh);
            int SoCanh = DemSoCanh(BacDinh, true);
            Console.WriteLine($"So canh cua do thi: {SoCanh}");
            int SoCanhBoi = DemCanhBoi(true);
            Console.WriteLine($"So cap dinh xuat hien canh boi: {SoCanhBoi}");
            int SoCanhKhuyen = DemCanhKhuyen();
            Console.WriteLine($"So canh khuyen: {SoCanhKhuyen}");
            int SoDinhTreo = DemDinhTreo(BacDinh);
            Console.WriteLine($"So dinh treo: {SoDinhTreo}");
            int SoDinhCoLap = DemDinhCoLap(BacDinh);
            Console.WriteLine($"So dinh co lap: {SoDinhCoLap}");
            Console.WriteLine("Bac cua tung dinh: ");
            for (int i = 0; i < g.n; ++i)
                Console.Write($"{i}({BacDinh[i]}) ");
            Console.WriteLine();
            if (SoCanhKhuyen > 0)
                Console.WriteLine("Gia do thi");
            else
            {
                if (SoCanhBoi > 0)
                    Console.WriteLine("Da do thi");
                else
                    Console.WriteLine("Don do thi");
            }
        }

        private void DemBacDinh(ref int[] BacDinh)
        {
            for (int i = 0; i < g.n; ++i)
            {
                int count = 0;
                for (int j = 0; j < g.n; ++j)
                    if (g.a[i, j] != 0)
                    {
                        count += g.a[i, j];
                        if (i == j)  
                            count += g.a[i, i];
                    }
                BacDinh[i] = count;
            }
        }
        private int DemSoCanh(int[] BacDinh, bool LaVoHuong)
        {
            int TongBacDinh = 0;
            for (int i = 0; i < BacDinh.Length; ++i)
                TongBacDinh += BacDinh[i];
            if (LaVoHuong == true)
                return TongBacDinh / 2;
            else
                return TongBacDinh;
        }
        private int DemCanhBoi(bool LaVoHuong)
        {
            int SoCanhBoi = 0;
            if (LaVoHuong == true)
            {
                for (int i = 0; i < g.n; ++i)
                    for (int j = i; j < g.n; ++j)
                        if (g.a[i, j] > 1)
                            SoCanhBoi++;
            }
            else
            {
                for (int i = 0; i < g.n; ++i)
                    for (int j = 0; j < g.n; ++j)
                        if (g.a[i, j] > 1)
                            SoCanhBoi++;
            }
            return SoCanhBoi;
        }
        private int DemCanhKhuyen()
        {
            int SoCanhKhuyen = 0;
            for (int i = 0; i < g.n; ++i)
                SoCanhKhuyen += g.a[i, i];
            return SoCanhKhuyen;
        }
        private int DemDinhTreo(int[] BacDinh)
        {
            int SoDinhTreo = 0;
            for (int i = 0; i < BacDinh.Length; ++i)
                if (BacDinh[i] == 1)
                    SoDinhTreo++;
            return SoDinhTreo;
        }
        private int DemDinhCoLap(int[] BacDinh)
        {
            int SoDinhCoLap = 0;
            for (int i = 0; i < BacDinh.Length; ++i)
                if (BacDinh[i] == 0)
                    SoDinhCoLap++;
            return SoDinhCoLap;
        }
        private void DemBacDinh(ref int[] BacVao, ref int[] BacRa)
        {
            for (int i = 0; i < g.n; ++i)
            {
                int DemBacVao = 0, DemBacRa = 0;
                for (int j = 0; j < g.n; ++j)
                {
                    if (g.a[i, j] != 0)
                        DemBacRa += g.a[i, j];
                    if (g.a[j, i] != 0)
                        DemBacVao += g.a[j, i];
                }
                BacVao[i] = DemBacVao;
                BacRa[i] = DemBacRa;
            }
        }

        private void XuLyDoThiCoHuong()
        {
            g.Show();
            Console.WriteLine("Do thi co huong");
            Console.WriteLine($"So dinh cua do thi: {g.n}");
            int[] BacVao = new int[g.n];
            int[] BacRa = new int[g.n];
            DemBacDinh(ref BacVao, ref BacRa);
            int SoCanh = DemSoCanh(BacVao, false);
            Console.WriteLine($"So canh cua do thi: {SoCanh}");
            int SoCanhBoi = DemCanhBoi(false);
            Console.WriteLine($"So cap dinh xuat hien canh boi: {SoCanhBoi}");
            int SoCanhKhuyen = DemCanhKhuyen();
            Console.WriteLine($"So canh khuyen: {SoCanhKhuyen}");
            int[] BacDinh = new int[g.n];
            for (int i = 0; i < g.n; ++i)
                BacDinh[i] = BacVao[i] + BacRa[i];
            int SoDinhTreo = DemDinhTreo(BacDinh);
            Console.WriteLine($"So dinh treo: {SoDinhTreo}");
            int SoDinhCoLap = DemDinhCoLap(BacDinh);
            Console.WriteLine($"So dinh co lap: {SoDinhCoLap}");
            Console.WriteLine("(Bac vao - Bac ra) cua tung dinh: ");
            for (int i = 0; i < g.n; ++i)
                Console.Write($"{i}({BacVao[i]}-{BacRa[i]}) ");
            Console.WriteLine();
            if (SoCanhBoi > 0)
                Console.WriteLine("Da do thi co huong");
            else
                Console.WriteLine("Do thi co huong");
        }
        public void XuatCau2(string filename)
        {
            g.Read(filename);
            if (LaDoThiDayDu())
                Console.WriteLine($"Day la do thi day du K{g.n}");
            else
                Console.WriteLine("Day khong phai la do thi day du");
            int ChinhQuy = 0;
            if (LaDoThiChinhQuy(ref ChinhQuy))
                Console.WriteLine($"Day la do thi {ChinhQuy}-chinh quy");
            else
                Console.WriteLine("Day khong phai la do thi chinh quy");
            if (LaDoThiVong())
                Console.WriteLine($"Day la do thi vong C{g.n}");
            else
                Console.WriteLine("Day khong phai la do thi vong");
            Console.WriteLine();
        }
        public bool LaDoThiDayDu()
        {
            int i, j;
            bool LaDayDu = true;
            for (i = 0; i < g.n && LaDayDu; ++i)
            {
                for (j = i + 1; (j < g.n) && (g.a[i, j] == 1); ++j) ;
                if (j < g.n)
                    LaDayDu = false;
            }
            return LaDayDu;
        }
        public bool LaDoThiChinhQuy(ref int k)
        {
            k = 0;
            int i, j;
            bool LaChinhQuy = true;
            for (i = 0; i < g.n; ++i)
                if (g.a[0, i] == 1)
                    k++;
            for (i = 1; i < g.n && LaChinhQuy; ++i)
            {
                int count = 0;
                for (j = 0; j < g.n; ++j)
                    if (g.a[i, j] != 0)
                        count++;
                if (count != k)
                    LaChinhQuy = false;
            }
            return LaChinhQuy;
        }
        public bool LaDoThiVong()
        {
            int k = 0;
            LaDoThiChinhQuy(ref k);
            if (k != 2)
                return false;
            
            int[] marked = new int[g.n];
            int nm = 0;
            for (int i = 0; i < g.n; ++i)
                marked[i] = 0;

            bool LaVong = true;
            int v = 0, j, next; 
            while (nm < g.n && LaVong)
            {
                for (j = 0; j < g.n && (g.a[v, j] == 0 || marked[j] != 0); ++j) ;
                if (j < g.n)
                {
                    next = j;
                    marked[next] = 1;
                    v = next;
                    nm++;
                }
                else
                    LaVong = false;
            }
            return LaVong;
        }
    }
}

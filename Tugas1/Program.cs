using System;
using System.Collections.Generic;

namespace Tugas1
{
    class Program
    {

        private static int[] id;
        private static int jml;
        private static int bayar;
        private static int total = 0;
        private static List<Barang> barang = new List<Barang>();
        private static Electronic bElectronic = new Electronic();
        private static Electronic bElectronic2 = new Electronic();
        static void Main(string[] args)
        {
            bElectronic.nama = "Monitor";
            bElectronic.harga = 5000000;
            _ = bElectronic.jenisBarang;

            bElectronic2.nama = "Keyboard";
            bElectronic2.harga = 1000000;
            _ = bElectronic2.jenisBarang;

            barang.Add(bElectronic);
            barang.Add(bElectronic2);

            menu1();

        }
        public static void Invoice()
        {
            string inv = "INV";
            DateTime date = DateTime.Now.AddDays(7);
            int counter = 00239;

            int year = Convert.ToInt32(date.ToString("yyyy").Substring(2, 2));
            int thisDate = Convert.ToInt32(date.ToString("dd"));
            String day = date.ToString("dddd").Substring(0, 2).ToUpper();
            String thisYear = date.ToString("yyyy");
            String month = date.ToString("MM");

            String invoice = $"{inv}/{thisYear}{month}/{day}/{ToRoman(thisDate)}/{ToRoman(year)}/{counter}";

            Console.WriteLine($"INVOICE CODE : {invoice}");

        }

        static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        public static void menu1()
        {
            Console.WriteLine("=================Aplikasi Pembelian Elektronik=================");
            Console.WriteLine("===============================================================");
            Console.WriteLine("==========================List Barang==========================");
            Console.WriteLine("===============================================================");
            tampilBarang();
            Console.WriteLine("===============================================================");
            Console.WriteLine("Pilih Menu = ");
            Console.WriteLine("1. Pembelian");
            Console.WriteLine("2. Daftar Barang");
            Console.WriteLine("3. History Pembelian");
            Console.WriteLine("9. Keluar");
            try
            {
                int m = int.Parse(Console.ReadLine());
                switch (m)
                {
                    case 1:
                        pembelian();
                        Console.ReadLine();
                        Console.Clear();
                        menu1();
                        break;

                    case 2:
                        Console.Clear();
                        menu2();
                        break;
                    case 3:
                        Console.Clear();
                        history();
                        Console.ReadLine();
                        Console.Clear();
                        menu1();
                        break;
                    case 9:
                        Console.WriteLine("Terimakasih Sudah Mampir");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Maaf format salah");
            }
        }

        public static void menu2()
        {
            Console.Clear();
            Console.WriteLine("===============================================================");
            Console.WriteLine("==========================List Barang==========================");
            Console.WriteLine("===============================================================");
            tampilBarang();
            Console.WriteLine("===============================================================");
            Console.WriteLine("Pilih Menu = ");
            Console.WriteLine("1. Tambah Barang");
            Console.WriteLine("2. Update Barang");
            Console.WriteLine("3. Hapus barang");
            Console.WriteLine("4. Kembali");

            try
            {
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Console.Clear();
                        tambahBarang();
                        menu2();
                        break;
                    case 2:
                        Console.Clear();
                        updateBarang();
                        menu2();
                        break;
                    case 3:
                        Console.Clear();
                        hapusBarang();
                        menu2();
                        break;
                    case 4:
                        Console.Clear();
                        menu1();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Maaf format salah");
                menu1();
            }
        }



        public static void tampilBarang()
        {
            for (int i = 0; i < barang.Count; i++)
            {
                Console.WriteLine(" " + (i) + ". Nama Barang: {0}, Harga: {1}, Jenis: {2}",
                    barang[i].nama, barang[i].harga, barang[i].jenisBarang = (new Electronic().jenisBarang));

                Console.WriteLine("\tBARANG ID : {0} {1}", i, barang[i].Tampil());
            }
            
        }

        public static void updateBarang()
        {
            Console.WriteLine("ID Barang: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Masukkan Harga :");
            int newH = int.Parse(Console.ReadLine());
            barang[id].harga = newH;
            Console.Clear();
            tampilBarang();
        }

        public static void hapusBarang()
        {
            Console.WriteLine("ID Barang yang akan dihapus :");
            int id = int.Parse(Console.ReadLine());
            barang.RemoveAt(id);
            Console.Clear();
            tampilBarang();
        }
        public static void tambahBarang()
        {
            Electronic jB = new Electronic();
            Console.Write("Masukkan Nama Barang: ");
            jB.nama = Console.ReadLine();
            Console.Write("Masukkan Harga Barang : Rp");
            jB.harga = int.Parse(Console.ReadLine());
            _ = jB.jenisBarang;

            barang.Add(jB);
            Console.Clear();
            tampilBarang();
        }
        public static void history()
        {
            if (jml == 0)
            {
                Console.WriteLine("\t\tHISTORY KOSONG");
                Console.WriteLine("\t\t========================");
            }
            else
            {
                for (int i = 0; i < id.Length; i++)
                {
                    Console.WriteLine($"No- {i + 1}   Nama Barang :  {barang[(id[i])].nama}  Harga :  {barang[(id[i])].harga}");
                }
            }
        }

        public static double totalHarga(int jHarga)
        {
            int nom = (jHarga);
            total += nom;
            return total;
        }
        public static void refund(int bayar, int total)
        {
            int kembali;
            kembali = bayar - total;

            if (bayar < total)
            {
                Console.WriteLine("Maaf, uang anda kurang !!");
                Console.WriteLine("-------------------------");
            }
            else
            {
                Console.WriteLine($"\nUang kembalian anda Rp.  {kembali} ,00");
            }
        }
        public static void pembelian()
        {
            do
            {
                Console.Write("\nMasukkan jumlah barang: ");
                try
                {
                    jml = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format Salah");
                }

            } while (jml < 1);

            id = new int[jml];
            for (int i = 0; i < jml; i++)
            {
                do
                {
                    Console.Write($"\nMasukkan ID barang Ke-{0}: ", (i + 1));
                    id[i] = int.Parse(Console.ReadLine());
                } while (id[i] < 0);
            }
            Console.WriteLine("\n\nBarang yang dibeli");
            Console.WriteLine("=============================");
            Invoice();

            for (int i = 0; i < jml; i++)
            {
                Console.WriteLine($"{i} .  {barang[(id[i])].nama}  {barang[(id[i])].harga}");
                total = (int)totalHarga(barang[(id[i])].harga);
            }
            Console.WriteLine($"TOTAL HARGA: {total} ");
            do
            {
                Console.Write("Uang Bayar : ");
                bayar = int.Parse(Console.ReadLine());

                refund(bayar, total);

            } while (bayar < total);

            Console.WriteLine("Terimakasih telah berbelanja di toko kami ");

        }
        
    }
}
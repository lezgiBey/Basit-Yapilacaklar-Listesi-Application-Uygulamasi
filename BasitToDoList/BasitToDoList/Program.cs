using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BasitToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GirisPage.Giris();

            bool kontrol = true;

            while (kontrol)
            {
                kontrol = Secim();
            }
        }

        public static Boolean Secim()
        {
            Console.Clear();
            DataBaseProcess.Listele();
            Console.WriteLine("\n------------------------------------------------------\n");
            Console.WriteLine("1.Listele   2.Cagir    3.Ekle   4.Güncelle   5.Sil    0.Çıkış");
            Console.Write("Seçiminiz: ");

            string sec = Console.ReadLine();

            Console.WriteLine();
            if (sec == "1")
            {
                DataBaseProcess.hataMesaji = "\n\nListeleme Yapılamadı.!\nSeçiminizi tekrar edin yada programı kapatıp açın.";
                DataBaseProcess.Listele();
                sec = "0";
            }
            else if (sec == "2")
            {
                DataBaseProcess.hataMesaji = "\n\nÇağırma Yapılamadı!\nGirdiğiniz değerler hatalı.\nLütfen kontrol edip tekrar girin.";
                DataBaseProcess.Cagir();
                DataBaseProcess.Listele();
                sec = "0";
            }
            else if (sec == "3")
            {
                DataBaseProcess.hataMesaji = "\n\nEkleme Yapılamadı!\nGirdiğiniz değerler hatalı.\nLütfen kontrol edip tekrar girin.";
                DataBaseProcess.Ekle();
                DataBaseProcess.Listele();
                sec = "0";
            }
            else if (sec == "4")
            {
                DataBaseProcess.hataMesaji = "\n\nGüncelleme Yapılamadı!\nGüncellemek istediğiniz index yanlış olabilir yada girdiğiniz değerler hatalı.\nLütfen kontrol edip tekrar deneyin.";
                DataBaseProcess.Guncelle();
                DataBaseProcess.Listele();
                sec = "0";
            }
            else if (sec == "5")
            {
                DataBaseProcess.hataMesaji = "\n\nSilme Yapılamadı!\nSilmek istediğiniz indexi kontrol edin.\nLütfen tekrar deneyin.";
                DataBaseProcess.Sil();
                DataBaseProcess.Listele();
                sec = "0";
            }
            else if (sec == "0")
            {
                return false;
            }
            sec = "0";
            return true;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasitToDoList
{
    internal class GirisPage
    {
        private static String kullaniciAdi;
        private static String sifre;
        public static void Giris()
        {
            Console.Write("Kullanıcı Adı: ");
            kullaniciAdi = Console.ReadLine();
            Console.Write("Şifre: ");
            sifre = Console.ReadLine();
            if (kullaniciAdi == "admin" && sifre == "admin")
            {
                Console.Clear();
                Console.WriteLine("Giriş Başarılı");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Kullanıcı adı veya şifre hatalı!");
                Console.WriteLine();
                Giris();
            }
            Console.Clear();
        }
    }
}

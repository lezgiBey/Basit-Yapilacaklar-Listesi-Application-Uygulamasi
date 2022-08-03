using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BasitToDoList
{
    internal class DataBaseProcess
    {


        static SqlConnection baglanti;
        static SqlCommand komut;
        static SqlDataReader reader;

        static string dataBaseName = "DESKTOP-DKDGEHS";
        static string tableName = "BasitYapilacaklarListesi";

        public static String hataMesaji = "";

        static readonly string baglantiCumlesi = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI", dataBaseName, tableName);
        
        public static void DataBaseIslem(string islem)
        {
            try
            {
                baglanti = new SqlConnection();
                baglanti.ConnectionString = baglantiCumlesi;
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = islem;

                baglanti.Open();
                int sonuc = komut.ExecuteNonQuery();
                baglanti.Close();

                if (sonuc > 0)
                {
                    Console.WriteLine("(: İşlem başarılı. :)");
                }
                else
                {
                    Console.WriteLine("): İşlem başarısız! :(");
                }
            }
            catch (Exception e) {
                Console.WriteLine("\nHATA!!!");
                Console.WriteLine(hataMesaji);
                Console.ReadKey();
                hataMesaji = "";
            }
        }
        public static DateTime TarihAlma()
        {
            DateTime sonTarih;
            try
            {
                Console.Write("Görev Son Günü (00): ");
                int sonGun = Convert.ToInt32(Console.ReadLine());
                Console.Write("Görev Ay Günü (00): ");
                int sonAy = Convert.ToInt32(Console.ReadLine());
                Console.Write("Görev Yıl Günü (0000): ");
                int sonYıl = Convert.ToInt32(Console.ReadLine());
                sonTarih = new DateTime(sonYıl, sonAy, sonGun);
                sonTarih.ToString("dd/MM/yyyy");

                return sonTarih;
            }
            catch(Exception e)
            {
                Console.Write("Lütfen girdiğiniz tarih değerleri kontrol edin!");
                sonTarih = new DateTime(0001, 01, 01);
                return sonTarih;
                Console.ReadKey();
            }
        }

        public static void CagirListele(string islem)
        {
            int sayac = 0;
            Console.WriteLine("------------> Görevler <------------\n");
            baglanti = new SqlConnection(baglantiCumlesi);
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = islem;
            baglanti.Open();
            reader = komut.ExecuteReader();
            Console.WriteLine("No    Görev         Açıklama        Açılış Tarihi      Görevin Son Günü");
            while (reader.Read())
            {
                sayac++;
                Console.WriteLine(reader[0] + "  " + reader[1] + "  " + reader[2] + "  " + reader[3] + "  " + reader[4]);

            }
            baglanti.Close();
        }
        public static void Listele()
        {
            CagirListele("SELECT * FROM Liste");
        }
        public static void Cagir()
        {
            Console.Write("Numara Nedir: ");
            int no = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            CagirListele("SELECT * FROM Liste WHERE id=" + no + "");

            Console.WriteLine("\nDevam etmek için herhangi bir tuşa basınız...");
            Console.ReadKey();
        }
        public static void Ekle()
        {
            DateTime date = DateTime.Now;
            date.ToString("dd/MM/yyyy");

            Console.Write("Görev Başlığı: ");
            string gorev = Console.ReadLine();
            Console.Write("Görev Açıklaması: ");
            string aciklama = Console.ReadLine();
            Console.WriteLine("Görevin Açılış Tarihi: " + date);
            DateTime sonGun = TarihAlma();

            DataBaseIslem("INSERT INTO Liste(Gorev,Aciklama,Gorev_Acilma_Gunu,Gorev_Son_Gunu) VALUES ('" + gorev + "','" + aciklama + "','" + date + "','" + sonGun + "')");
        }
        public static void Guncelle()
        {
            Console.Write("No Nedir: ");
            int no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Görev Nedir: ");
            string gorev = Console.ReadLine();
            Console.Write("Açıklama: ");
            string aciklama = Console.ReadLine();
            DateTime sonGun = TarihAlma();

            DataBaseIslem("UPDATE Liste SET Gorev='" + gorev + "',Aciklama='" + aciklama + "',Gorev_Son_Gunu= '" + sonGun.ToString() + "' WHERE id='" + no.ToString() + "'");
        }
        public static void Sil()
        {
            Console.Write("Numara Nedir: ");
            int no = Convert.ToInt32(Console.ReadLine());

            DataBaseIslem("DELETE FROM Liste WHERE id=" + no + "");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ExcelDataReader;
using System.Xml;

namespace İETTProje
{
    class Program
    {
        static void Main(string[] args)
        {

            //İSİM İŞLEMLERİ

            //Dosyanın okunacağı dizin
            string filePath = @"C:\Users\oguz-\Desktop\Okul\Staj-1\İETT PROJE\isim.xlsx";


            //Dosyayı okuyacağımı ve gerekli izinlerin ayarlanması.
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader;

            List<double> liste = new List<double>();

            List<İsim> isimListesi = new List<İsim>();

            int counter = 0;

            //Gönderdiğim dosya xls'mi xlsx formatında mı kontrol ediliyor.
            if (Path.GetExtension(filePath).ToUpper() == ".XLS")
            {
                //Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else
            {
                //Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }

            //Datasete atarken ilk satırın başlık olacağını belirtiyor.

            DataSet result = excelReader.AsDataSet();

            while (excelReader.Read())//excelden veriler liste atıldı.
            {
                counter++;

                //ilk satır başlık olduğu için 2.satırdan okumaya başlıyorum.
                if (counter > 1)
                {
                    liste.Add(excelReader.GetDouble(0));
                    liste.Add(excelReader.GetDouble(1));
                    liste.Add(excelReader.GetDouble(2));
                }
            }

            //0-380 list<isim> içerisine veriler yerleştirildi.
            for (int i = 0; i <= 378; i = i + 3)
            {
                İsim isim = new İsim();
                isim.ID = liste[i];
                isim.isimXkoordinat = liste[i + 1];
                isim.isimYkoordinat = liste[i + 2];

                isimListesi.Add(isim);

            }

            //Okuma bitiriliyor.
            excelReader.Close();

            //İSİM İŞLEMLERİ BİTTİ 
            //List<isim> isimlistesi altında isimler , x ve y koordinatları tutuldu.



            //DURAK İŞLEMLERİ

            //Dosyanın okunacağı dizin
            string filePath1 = @"C:\Users\oguz-\Desktop\Okul\Staj-1\İETT PROJE\durak.xlsx";

            //Dosyayı okuyacağımı ve gerekli izinlerin ayarlanması.
            FileStream stream1 = File.Open(filePath1, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader1;

            List<double> liste1 = new List<double>();

            List<Durak> durakliste = new List<Durak>();

            int counter1 = 0;

            //Gönderdiğim dosya xls'mi xlsx formatında mı kontrol ediliyor.
            if (Path.GetExtension(filePath1).ToUpper() == ".XLS")
            {
                //Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader1 = ExcelReaderFactory.CreateBinaryReader(stream1);
            }
            else
            {
                //Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader1 = ExcelReaderFactory.CreateOpenXmlReader(stream1);
            }

            //Datasete atarken ilk satırın başlık olacağını belirtiyor.
            DataSet result1 = excelReader1.AsDataSet();

            //Veriler okunmaya başlıyor.
            while (excelReader1.Read())
            {
                counter1++;

                //ilk satır başlık olduğu için 2.satırdan okumaya başlıyorum.
                if (counter1 > 1)
                {
                    liste1.Add(excelReader1.GetDouble(0));
                    liste1.Add(excelReader1.GetDouble(1));
                    liste1.Add(excelReader1.GetDouble(2));
                }
            }

            for (int y = 0; y < liste1.Count; y = y + 3)
            {
                Durak durak = new Durak();
                durak.durakKodu = liste1[y];
                durak.durakXkoordinat = liste1[y + 1];
                durak.durakYkoordinat = liste1[y + 2];

                durakliste.Add(durak);

            }



            //Okuma bitiriliyor.
            excelReader1.Close();

            //DURAK İŞLEMLERİ BİTTİ
            //List<Durak> durakliste adı altında  durakKodu , durakXkoordinat , durakYkoordinat alanlarında tutuldu.

            /*
             BENDEN İSTENENLER
             1.Her kişiye en yakın 15 durak 
             -bir kişiye en yakın durak bulunacak.durak ataması yapılacak.durak listeden silinecek.
             -diğer kişiye en yakın durak bulunacak.durak ataması yapıcalacak.durak listeden silinecek.
            -126 kişiye atama yapıldıktan sonra aynı işlemi 15 kere tekrar edicem.


            2.Her kişiye en yakın 15 durak
            -Herkez için en yakın ilk durak bulunacak atama işlemi yapılacak.
            -Atanan durak listeden silinecek.
            -Daha sonra kişinin x ve y si en son atanan durağın x ve y si olacak.
            -Daha sonra diğer kişilere 1. durakları atanacak.
            -Daha sonra 2.3.,....,15. durak atanacak.
             */

            List<İsim> yedekisimliste = new List<İsim>();
            yedekisimliste = isimListesi;


            List<Durak> yedekdurakliste = new List<Durak>();
            yedekdurakliste = durakliste;

            List<double> enyakin1 = new List<double>();
            List<double> enyakin2 = new List<double>();
            List<double> enyakin3 = new List<double>();
            List<double> enyakin4 = new List<double>();
            List<double> enyakin5 = new List<double>();
            List<double> enyakin6 = new List<double>();
            List<double> enyakin7 = new List<double>();
            List<double> enyakin8 = new List<double>();
            List<double> enyakin9 = new List<double>();
            List<double> enyakin10 = new List<double>();
            List<double> enyakin11 = new List<double>();
            List<double> enyakin12 = new List<double>();
            List<double> enyakin13 = new List<double>();
            List<double> enyakin14 = new List<double>();
            List<double> enyakin15 = new List<double>();

            List<List<double>> enyakinlar = new List<List<double>>();

            enyakinlar.Add(enyakin1);
            enyakinlar.Add(enyakin2);
            enyakinlar.Add(enyakin3);
            enyakinlar.Add(enyakin4);
            enyakinlar.Add(enyakin5);
            enyakinlar.Add(enyakin6);
            enyakinlar.Add(enyakin7);
            enyakinlar.Add(enyakin8);
            enyakinlar.Add(enyakin9);
            enyakinlar.Add(enyakin10);
            enyakinlar.Add(enyakin11);
            enyakinlar.Add(enyakin12);
            enyakinlar.Add(enyakin13);
            enyakinlar.Add(enyakin14);
            enyakinlar.Add(enyakin15);

            Console.Clear();

            double distance = 0.0;
            double ydifference = 0.0;
            double xdifference = 0.0;
            double sonuc = 1000.0;


            double[,] Array2D = new double[127, 16];

            for (int z = 0; z < 127; z++)
            {
                Array2D[z, 0] = z + 1;
            }

            Durak temp = new Durak();

            int h = 0;

            DÖN:

            for (int a = 0; a < yedekisimliste.Count; a++)
            {
                for (int b = 0; b < yedekdurakliste.Count; b++)
                {
                    ydifference = (yedekdurakliste[b].durakYkoordinat - yedekisimliste[a].isimYkoordinat);
                    xdifference = (yedekdurakliste[b].durakXkoordinat - yedekisimliste[a].isimXkoordinat);

                    distance = Math.Sqrt(Math.Abs((ydifference * ydifference) + (xdifference * xdifference)));

                    if (distance < sonuc)
                    {
                        sonuc = distance;
                        temp.durakKodu = yedekdurakliste[b].durakKodu;
                    }//end if


                }//end inner for

                enyakinlar[h].Add(temp.durakKodu);

                Durak ahmet;
                ahmet = yedekdurakliste.Find(I => I.durakKodu == temp.durakKodu);
                yedekdurakliste.Remove(ahmet);

                sonuc = 1000.0;

            }//end medium for

            h++;

            if (h == 15)
            {
                goto BİTİR;
            }

            goto DÖN;


            BİTİR:


            //Arraye  atama
            for (int m = 1; m < 16; m++)
            {
                for (int n = 0; n < 127; n++)
                {
                    Array2D[n, m] = enyakinlar[m - 1][n];
                }
            }

            //EKRANA YAZDIRMA
            for (int i = 0; i < 127; i++)
            {
                for (int y = 0; y < 16; y++)
                {

                    Console.Write(Array2D[i, y] + "  ");

                    if (y == 15)
                    {
                        Console.WriteLine();
                    }
                }

            }



            Console.ReadLine();


        }//Main sonu


    }//class Program sonu

}//namespace İETT Proje sonu

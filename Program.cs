using System;
using System.Data;

namespace Ödev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Kaç öğrenci girmek istiyorsunuz?");
                int ogrenci = int.Parse(Console.ReadLine());
                string[,] liste = new string[ogrenci+1, 7];
                liste[0, 0] = "Numara";
                liste[0, 1] = "Ad";
                liste[0, 2] = "Soyad";
                liste[0, 3] = "Vize Notu";
                liste[0, 4] = "Final Notu";
                liste[0, 5] = "Ortalama";
                liste[0, 6] = "Harf Notu";

                byte enkucuk = 100;  
                byte enbuyuk = 0;
               double tumort = 0;
                for (int i = 1; i <= ogrenci; i++)
                {
                    Console.WriteLine($"{i}. Öğrencinin ismini giriniz:");
                    string ad = Console.ReadLine();

                    Console.WriteLine($"{i}. Öğrencinin soyadını giriniz:");
                    string soyad = Console.ReadLine();

                    Console.WriteLine($"{i}. Öğrencinin numarasını giriniz:");
                    double number = double.Parse(Console.ReadLine());

                    byte vnot;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine($"{i}. Öğrencinin vize notunu giriniz:");
                            vnot = byte.Parse(Console.ReadLine());

                            if (vnot >= 0 && vnot <= 100)
                                break;
                            else
                            {
                                Console.WriteLine("Lütfen 0-100 değer aralığında değer giriniz.");
                            }
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Lütfen 0-100 değer aralığında değer giriniz.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Yanlış formatta girdiniz.");
                        }

                    }

                    byte fnot;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine($"{i}. Öğrencinin final notunu giriniz:");
                            fnot = byte.Parse(Console.ReadLine());
                            if (fnot >= 0 && fnot <= 100)
                                break;
                            else
                            {
                                Console.WriteLine("Lütfen 0-100 değer aralığında değer giriniz.");
                            }
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Lütfen 0-100 değer aralığında değer giriniz.");
                        }
                        catch (FormatException)
                        { 
                        Console.WriteLine("Yanlış formatta girdiniz.");
                        }
                        
                    }
                    


                    double ort = vnot * 0.4 + fnot * 0.6;


                    string hnot = ort >= 85 ? "AA" :
                        ort >= 75 ? "BA" :
                        ort >= 60 ? "BB" :
                        ort >= 50 ? "CB" :
                        ort >= 40 ? "CC" :
                        ort >= 30 ? "DC" :
                        ort >= 20 ? "DD" :
                        ort >= 10 ? "FD" : "FF";

                    liste[i, 0] = number.ToString();
                    liste[i, 1] = ad;
                    liste[i, 2] = soyad;
                    liste[i, 3] = vnot.ToString();
                    liste[i, 4] = fnot.ToString();
                    liste[i, 5]=ort.ToString();
                    liste[i, 6] = hnot;
                    
                    tumort += ort;
                   
                 
                    
                    
                        byte[] bnot = { vnot, fnot };
                        Array.Sort(bnot);
                        byte dusuk = bnot[0];
                        byte yuksek = bnot[bnot.Length - 1];
                    if (dusuk < enkucuk) enkucuk = dusuk;
                    if (yuksek > enbuyuk) enbuyuk = yuksek;




                }
                Console.WriteLine();
                for (int i = 0; i <=ogrenci;  i++)
                {
                    
                    for (int j= 0; j < 7; j++)
                    {
                        Console.Write($"{liste[i,j],-15}");
                    }
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n");
                Console.WriteLine($"En düşük not: {enkucuk}");
                Console.WriteLine($"En yüksek not: {enbuyuk}");

                double sınıfort = tumort / ogrenci;
                Console.WriteLine($"Tüm sınıfın ortalaması: {sınıfort}");




            }
            catch (FormatException)
            {
                Console.WriteLine("Yanlış formatta yazdınız.");
                throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Lütfen geçerli değer aralığında giriş yapınız.");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu.");
                throw;
            }


        }
    }
}

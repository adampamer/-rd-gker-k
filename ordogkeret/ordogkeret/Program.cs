using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordogkeret
{
    class Program
    {
        static void Main(string[] args)
        {
                  
            const int tomb = 4;
            const int keret = 10;
            const int keretekszama = (keret-tomb)/2;
            int[] tombfo = new int[tomb];
            int[] tombme = new int[tomb];
            int randt = 0;
            int[,] matrix = new int[tomb, tomb];
            int[,] matrix2 = new int[keret, keret];
            double[] hely = new double[keret];
            double[] hely2 = new double[keret];
            double[] tomb2 = new double[keret];
            double[] tomb3 = new double[keret];
            double[] tombs = new double[keret];
            int oszlop1 = 0, oszlop2 = 0;
            int sor1 = 0, sor2 = 0;
            int randert = 0, randtombert = 0;
            int p = 0, dm = 0, ker = 0,ker2=0 ;
            Random szamok = new Random();
            do
            {
                for (int i = 0; i < tomb; i++)
                {
                    tomb2[i] = 20;
                    tomb3[i] = 20;
                }
                do
                {                                                         // Random szám generálás
                          randt = 20;
                          p = 0;
                          for (int i = 0; i < tomb; i++)
                          {
                                    for (int j = 0; j < tomb; j++)
                                    {
                                              matrix[i, j] = randt;
                                        
                                    }

                          }
                          for (int i = 0; i < keret; i++)
                          {
                              for (int j = 0; j < keret; j++)
                              {
                                  matrix2[i, j] = randt;

                              }
                          }
                          randert = szamok.Next(1, tomb);
                          randtombert = szamok.Next(1, tomb);
                          do
                          {
                                    p++;
                                    oszlop1 = szamok.Next(0, tomb);
                                    sor1 = szamok.Next(0, tomb);
                                    oszlop2 = szamok.Next(0, tomb);
                                    sor2 = szamok.Next(0, tomb);
                                    if (randert < matrix[oszlop1, sor1] && randert < matrix[oszlop2, sor2] && randert < matrix[oszlop1, sor2] && randert < matrix[oszlop2, sor1])
                                    {

                                              matrix[oszlop2, sor1] -= randert;
                                              matrix[oszlop2, sor2] += randert;
                                              matrix[oszlop1, sor1] += randert;
                                              matrix[oszlop1, sor2] -= randert;

                                    }
                          } while (p <= tomb * 100);
                          
                          dm++;
                } while (dm == 5000);
                oszlop1 = 0;
                oszlop2 = 0;
                sor1 = 0;
                sor2 = 0;
                
                      for (int i = keretekszama; i < (keretekszama + tomb); i++)
                          {
                                    for (int j = keretekszama; j < (keretekszama + tomb); j++)
                                    {
                                              matrix2[i, j] = matrix[i - keretekszama, j - keretekszama];
                                    }
                          }
                      do
                      {
                          for (int i = 0; i < keretekszama; i++)
                          {
                              for (int y = keretekszama-i; y < (keretekszama + tomb)+i; y++)
                              {
                                  p++;
                                  oszlop1 = szamok.Next(keretekszama - i-1, keretekszama - i-1);
                                  sor1 = szamok.Next(keretekszama-i-1, (keretekszama + tomb)+i+1);
                                  oszlop2 = szamok.Next((keretekszama + tomb)+i, (keretekszama + tomb)+i+1);
                                  sor2 = szamok.Next(keretekszama - i+1, (keretekszama + tomb)+i-1);
                                  if (randert < matrix2[oszlop1, sor1] && randert < matrix2[oszlop2, sor2] && randert < matrix2[oszlop1, sor2] && randert < matrix2[oszlop2, sor1])
                                  {

                                      matrix2[oszlop2, sor1] -= randert;
                                      matrix2[oszlop2, sor2] += randert;
                                      matrix2[oszlop1, sor1] += randert;
                                      matrix2[oszlop1, sor2] -= randert;

                                  }
                              }
                              oszlop1 = 0;
                              oszlop2 = 0;
                              sor1 = 0;
                              sor2 = 0;
                              for (int x = keretekszama ; x < (keretekszama + tomb); x++)
                              {
                                  p++;
                                  oszlop1 = szamok.Next(keretekszama - i - 1,(keretekszama + tomb) + i + 1) ;
                                  sor1 = szamok.Next(keretekszama - i - 1, keretekszama - i - 1);
                                  oszlop2 = szamok.Next(keretekszama - i + 1, (keretekszama + tomb) + i - 1);
                                  sor2 = szamok.Next((keretekszama + tomb) + i, (keretekszama + tomb) + i + 1);
                                  if (randert < matrix2[oszlop1, sor1] && randert < matrix2[oszlop2, sor2] && randert < matrix2[oszlop1, sor2] && randert < matrix2[oszlop2, sor1])
                                  {

                                      matrix2[oszlop2, sor1] -= randert;
                                      matrix2[oszlop2, sor2] += randert;
                                      matrix2[oszlop1, sor1] += randert;
                                      matrix2[oszlop1, sor2] -= randert;

                                  }
                              }
                              
                          }
                      } while (p <= tomb * 100);

                      for (int i = 0; i < matrix2.GetLength(0); i++)
                {
                    for (int i2 = 0; i2 < matrix2.GetLength(1); i2++)
                    {
                        hely[i] += matrix2[i, i2];
                        hely2[i] += matrix2[i2, i];
                    }
                }
                for (int i = 0; i < matrix2.GetLength(0); i++)               // Kiírjuk a mátrixban lévő értékeket
                {
                    for (int j = 0; j < matrix2.GetLength(1); j++)
                    {
                        Console.Write("{0:00} ", matrix2[i, j]);
                    }
                    Console.WriteLine("____" + hely[i]);
                    Console.WriteLine();
                }
                for (int i = 0; i < keret; i++)
                {
                    Console.Write(hely2[i] + ",");
                }
                Console.ReadKey();
                Console.Clear();
                for (int i = 0; i < keret; i++)
                {
                          for (int i2 = 0; i2 < keret; i2++)
                    {
                        hely[i] = 0;
                        hely2[i] = 0;
                    }
                }
                
            } while (true);

        }
    }
}

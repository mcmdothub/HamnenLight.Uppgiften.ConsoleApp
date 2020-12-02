using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HamnenLight.Uppgiften.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int dag = 1;
            double TotalaPlatser = 25;
            double BokadeHamnPlatser = 0;

            //Create Port and parking areea
            Hamn hamn = new Hamn();
            hamn.Båtplatser = new List<Slot>();

            // Create lists for created boats, uncomming boats,waiting list boast without parking spots
            List<Boat> båtarSkapade = new List<Boat>();
            List<Boat> båtarPåväg = new List<Boat>();
            List<Boat> BåtarUtanHamnPlats = new List<Boat>();

            //Create Random daily comming boats
            Random rnd = new Random();
            int båtarSomKommerVarjeDag = 5;

            while (true)
            {
                string fileName = @"..\Details.txt";
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    Console.WriteLine($" Wellcome. On day {dag} have arrived: \n");
                    sw.WriteLine($" Today's day {dag}\n");

                    for (int i = 0; i < båtarSomKommerVarjeDag; i++)
                    {
                        int randomNum = rnd.Next(1, 5);
                        if (randomNum == 1)
                        {
                            SmallBoat roddbåtar = new SmallBoat();
                            båtarSkapade.Add(roddbåtar);
                            {
                                if (roddbåtar.PlatsenSomBåtenTar == 0.5)
                                {
                                    båtarSkapade.Add(roddbåtar);
                                }
                            }
                        }
                        else if (randomNum == 2)
                        {
                            Motorbåt motorbåtar = new Motorbåt();
                            båtarSkapade.Add(motorbåtar);
                        }
                        else if (randomNum == 3)
                        {
                            Segelbåt segelbåtar = new Segelbåt();
                            båtarSkapade.Add(segelbåtar);
                        }
                        else if (randomNum == 4)
                        {
                            Lastfartyg lastfartyg = new Lastfartyg();
                            båtarSkapade.Add(lastfartyg);
                        }
                    }

                    foreach (var item in båtarSkapade)
                    {
                        Console.WriteLine($" Boat {item.IdNr} type {item.BoatType} have arrived.");
                        sw.WriteLine($" Boat {item.IdNr} type {item.BoatType} have arrived.");

                        if ((BokadeHamnPlatser + item.PlatsenSomBåtenTar) <= TotalaPlatser)
                        {
                            BokadeHamnPlatser += item.PlatsenSomBåtenTar;

                            string slotID = Guid.NewGuid().ToString();

                            item.NuvarandePlatsID = slotID;

                            båtarPåväg.Add(item);

                            hamn.Båtplatser.Add(new Slot { ID = slotID, PlatsStorlek = item.PlatsenSomBåtenTar, Bokad = true });
                        }

                        else
                        {
                            BåtarUtanHamnPlats.Add(item);
                        }
                    }

                    // Show created boats
                    Console.WriteLine(" Boats arriving today:\n");
                    sw.WriteLine(" Boats arriving today:\n");
                    foreach (var item in båtarSkapade)
                    {

                    }
                    Console.WriteLine();

                    foreach (var item in hamn.Båtplatser)
                    {
                        foreach (var i in båtarPåväg)
                        {
                            if (i.PlatsenSomBåtenTar == i.PlatsenSomBåtenTar) ;


                        }
                    }

                    double platsnummer = 1;
                    int antalRoddbåtar = 0;
                    int antalMotorbåtar = 0;
                    int antalSegelbåtar = 0;
                    int antalLastfartyg = 0;
                    double maxhastighet = 0;
                    int TotalHastighet = 0;
                    double vikt = 0;

                    Console.WriteLine("Plats\tBåttyp\t\tNummer\tVikt\tMaxhastighet\t\tUnik\n");
                    sw.WriteLine("Plats\tBåttyp\t\tNummer\tVikt\tMaxhastighet\t\tUnik\n");


                    foreach (Boat item in båtarPåväg.ToList())
                    {
                        {

                        }
                        if (item != null)
                        {
                            if (item.PlatsenSomBåtenTar > 1)
                            {

                                Console.WriteLine($"{platsnummer}-{platsnummer + item.PlatsenSomBåtenTar - 1}.\t{item.BoatType}\t{item.IdNr}\t{item.Vikt}\t{item.MaxHastighet} km/h\t\t{item.ÖvrigtEgenskap} ");
                                sw.WriteLine($"{platsnummer}-{platsnummer + item.PlatsenSomBåtenTar - 1}.\t{item.BoatType}\t{item.IdNr}\t{item.Vikt}\t{item.MaxHastighet} km/h\t\t{item.ÖvrigtEgenskap} ");
                                platsnummer++;
                            }
                            else
                            {
                                Console.WriteLine($"{platsnummer}.\t{item.BoatType}\t{item.IdNr}\t{item.Vikt}\t{item.MaxHastighet} km/h\t\t{item.ÖvrigtEgenskap} ");
                                sw.WriteLine($"{platsnummer}.\t{item.BoatType}\t{item.IdNr}\t{item.Vikt}\t{item.MaxHastighet} km/h\t\t{item.ÖvrigtEgenskap} ");
                            }

                            if (item is SmallBoat)
                            {

                                antalRoddbåtar++;
                                platsnummer += item.PlatsenSomBåtenTar;



                            }
                            else if (item is Motorbåt)
                            {

                                antalMotorbåtar++;
                                platsnummer += item.PlatsenSomBåtenTar;


                            }
                            else if (item is Segelbåt)
                            {

                                antalSegelbåtar++;
                                platsnummer += item.PlatsenSomBåtenTar - 1;


                            }
                            else if (item is Lastfartyg)
                            {

                                antalLastfartyg++;
                                platsnummer += item.PlatsenSomBåtenTar - 1;


                            }
                        }
                        else
                        {
                            Console.WriteLine(platsnummer + ". Tom Plats");
                            sw.WriteLine(platsnummer + ". Tom Plats");
                            platsnummer++;

                        }
                    }

                    if (platsnummer < 26)
                    {
                        double tommaPlatser = 26 - platsnummer;

                        for (int i = 0; i < tommaPlatser; i++)
                        {
                            Console.WriteLine(platsnummer + ". Tom Plats");
                            sw.WriteLine(platsnummer + ". Tom Plats");
                            platsnummer++;
                        }

                    }

                    foreach (var item in båtarPåväg.ToList())
                    {
                        if (item != null)
                        {
                            if (item.AntalDagarParkeratIHamnen != 0)
                            {
                                vikt += item.Vikt;
                                maxhastighet += item.MaxHastighet;
                                item.AntalDagarParkeratIHamnen--;
                                TotalHastighet++;

                            }

                            else
                            {
                                Console.WriteLine($" The boat leaving the harbor: {item.IdNr}");
                                sw.WriteLine($" The boat leaving the harbor: {item.IdNr}");

                                //   BokadeHamnPlatser += item.PlatserSomTas;
                                vikt -= item.Vikt;
                                maxhastighet -= item.MaxHastighet;
                                TotalHastighet--;
                                if (item is SmallBoat)
                                    antalRoddbåtar--;
                                else if (item is Motorbåt)
                                    antalMotorbåtar--;
                                else if (item is Segelbåt)
                                    antalSegelbåtar--;
                                else if (item is Lastfartyg)
                                    antalLastfartyg--;
                                BokadeHamnPlatser -= item.PlatsenSomBåtenTar;
                                båtarPåväg.Remove(item);
                            }
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Antalet av roddbåtar: {antalRoddbåtar}\nAntalet av motorbåtar: {antalMotorbåtar}\nAntalet av segelbåtar: {antalSegelbåtar}\nAntalet av lastfartyg: {antalLastfartyg}");
                    sw.WriteLine($"Antalet av roddbåtar: {antalRoddbåtar}\nAntalet av motorbåtar: {antalMotorbåtar}\nAntalet av segelbåtar: {antalSegelbåtar}\nAntalet av lastfartyg: {antalLastfartyg}");

                    double maxMedeltal = maxhastighet / TotalHastighet;
                    Console.WriteLine("Medelhastigheten är: " + Math.Round(maxMedeltal, 1) + " km/h");
                    sw.WriteLine("Medelhastigheten är: " + Math.Round(maxMedeltal, 1) + " km / h");
                    Console.WriteLine("Total vikt är: " + vikt + " kg\n");
                    sw.WriteLine("Total vikt är: " + vikt + " kg\n");

                    // Visa vilka båtar fick inte plats
                    Console.WriteLine(" Boats that do not fit:");
                    sw.WriteLine(" Boats that do not fit:");
                    foreach (var item in BåtarUtanHamnPlats)
                    {
                        Console.WriteLine($"{item.BoatType} med ID nummer: {item.IdNr}");
                        sw.WriteLine($"{item.BoatType} med ID nummer: {item.IdNr}");
                    }

                    båtarSkapade.Clear();
                    BåtarUtanHamnPlats.Clear();

                    dag++;

                    Console.WriteLine();
                    Console.WriteLine(" The next day, click enter");
                    sw.Close();
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                        Console.Clear();
                    File.WriteAllText(fileName, "");
                }
            }
        }
    }
}
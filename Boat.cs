using System;

namespace HamnenLight.Uppgiften.ConsoleApp
{
    public class Boat
    {
        public string BoatType { get; set; }
        public string IdNr { get; set; }
        public double Vikt { get; set; }
        public double MaxHastighet { get; set; }
        public string ÖvrigtEgenskap { get; set; }
        public int AntalDagarParkeratIHamnen { get; set; }
        public double PlatsenSomBåtenTar { get; set; }
        public string NuvarandePlatsID { get; set; }




        public static string GetNummerID() //Hämtar nummer ID
        {

            string[] ar = new string[3];
            Random rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                int numm = rnd.Next(0, 26);
                char let = (char)('a' + numm);
                string svaret = let.ToString();
                ar[i] = svaret.ToUpper();

            }
            string toReturn = null;
            foreach (string item in ar)
            {
                toReturn += item;
            }

            return toReturn.ToUpper();
        }

        public static int AddVikt(int minWeight, int maxWeight) //Hämtar vikt
        {
            Random rnd = new Random();
            int number = rnd.Next(minWeight, maxWeight + 1);
            int Totalvikt = number;
            return Totalvikt;
        }

        public static double AddMaxSpeed(int minSpeed, int maxSpeed) //Metod för att generera random på maximalhastighet och minimal
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(minSpeed, maxSpeed + 1);
            int finalMaxSpeed = randomNummer;
            double kmPerHour = finalMaxSpeed * 1.852; //Omvandlar knopp till km/h
            return Math.Round(kmPerHour);
        }

        public virtual string AddUnikEgenskap() //String för att skapa en unik string till våra båtar 
        {

            string unik = "";
            return unik;
        }

    }

}
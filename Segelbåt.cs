using System;

namespace HamnenLight.Uppgiften.ConsoleApp
{
    public class Segelbåt : Boat  
    {
        public int BåtLength { get; set; }

        string IdPrefix = "S-";
        int minVikt = 500;
        int maxVikt = 6000;
        int minSpeed = 0;
        int maxiSpeed = 10;


        public Segelbåt()
        {
            BoatType = "SegelBåt";
            IdNr = IdPrefix + GetNummerID();
            ÖvrigtEgenskap = AddUnikEgenskap();
            Vikt = AddVikt(minVikt, maxVikt);
            MaxHastighet = AddMaxSpeed(minSpeed, maxiSpeed);
            AntalDagarParkeratIHamnen = 4;
            PlatsenSomBåtenTar = 2.0;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(10, 60 + 1);
            string unik = $"Båtens längd: {randomNummer} ";
            return unik;
        }
    }
}
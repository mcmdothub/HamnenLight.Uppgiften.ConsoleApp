using System;

namespace HamnenLight.Uppgiften.ConsoleApp
{
    public class Lastfartyg : Boat 
    {
        public int Containers { get; set; }

        string IdPrefix = "L-";
        int minVikt = 3000;
        int maxVikt = 20000;
        int minSpeed = 0;
        int maxiSpeed = 20;

        public Lastfartyg()
        {
            BoatType = "Lastfartyg";
            IdNr = IdPrefix + GetNummerID();
            ÖvrigtEgenskap = AddUnikEgenskap();
            Vikt = AddVikt(minVikt, maxVikt);
            MaxHastighet = AddMaxSpeed(minSpeed, maxiSpeed);
            AntalDagarParkeratIHamnen = 6;
            PlatsenSomBåtenTar = 4.0;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(500 + 1);
            string unik = $"Containers totalt på fartyget: {randomNummer}";
            return unik;
        }
    }
}
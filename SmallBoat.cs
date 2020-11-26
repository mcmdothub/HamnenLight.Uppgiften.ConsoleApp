using System;

namespace HamnenLight.Uppgiften.ConsoleApp
{
    class SmallBoat : Boat 
    {
        public int MaxPassenger { get; set; }

        string IdPrefix = "R-";
        int minVikt = 100;
        int maxVikt = 300;
        int minSpeed = 0;
        int maxiSpeed = 3;


        public SmallBoat()
        {
            BoatType = "RoddBåt ";
            IdNr = IdPrefix + GetNummerID();
            ÖvrigtEgenskap = AddUnikEgenskap();
            Vikt = AddVikt(minVikt, maxVikt);
            MaxHastighet = AddMaxSpeed(minSpeed, maxiSpeed);
            AntalDagarParkeratIHamnen = 1;
            PlatsenSomBåtenTar = 0.5;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(1, 6 + 1);
            string unik = $"Maximal antal passangerare: {randomNummer}";
            return unik;
        }
    }
}
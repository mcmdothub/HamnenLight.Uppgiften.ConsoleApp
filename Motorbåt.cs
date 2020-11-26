using System;

namespace HamnenLight.Uppgiften.ConsoleApp
{
    public class Motorbåt : Boat 
    {
        public int Hästkrafter { get; set; }

        string IdPrefix = "M-";
        int minVikt = 200;
        int maxVikt = 3000;
        int minSpeed = 0;
        int maxiSpeed = 60;


        public Motorbåt()
        {
            BoatType = "Motorbåt";
            IdNr = IdPrefix + GetNummerID();
            ÖvrigtEgenskap = AddUnikEgenskap();
            Vikt = AddVikt(minVikt, maxVikt);
            MaxHastighet = AddMaxSpeed(minSpeed, maxiSpeed);
            AntalDagarParkeratIHamnen = 3;
            PlatsenSomBåtenTar = 1.0;
        }

        public override string AddUnikEgenskap()
        {
            Random rnd = new Random();
            int randomNummer = rnd.Next(10, 1000 + 1);
            string unik = $"Antal hästkrafter: {randomNummer}";
            return unik;
        }

    }
}
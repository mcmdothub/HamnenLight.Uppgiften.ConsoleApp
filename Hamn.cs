using System.Collections.Generic;

namespace HamnenLight.Uppgiften.ConsoleApp
{
    class Hamn
    {
        public double Storlek { get; set; }

        public List<Slot> Båtplatser { get; set; }

    }

    class Slot
    {
        public double PlatsStorlek { get; set; }
        public string ID { get; set; }
        public bool Bokad { get; set; }
    }
}
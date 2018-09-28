using System;
using System.Collections.Generic;

namespace RegistryApp.model
{
    public class Member
    {
        public string Name { get; set; }

        public string PersonalNumber { get; set; }

        public int BoatAmount { get; set; }

        public List<Boat> Boats { get; set; }

        public Member()
        {
            Boats = new List<Boat>();
        }

        public void AddBoat(Boat boat)
        {
            Boats.Add(boat);
            BoatAmount += 1;
        }
    }
}
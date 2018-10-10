using System;
using System.Collections.Generic;

namespace RegistryApp.model
{
    public class Member
    {
        private int _id;
        private string _name;
        private string _personalNumber;
        private int _boatAmount;
        private List<Boat> _boats;

        public int ID 
        {
            get => _id;  
            private set { _id = value; }
        }

        public string Name 
        {
            get => _name;  
            private set { _name = value; }
        }

        public string PersonalNumber
        {
            get => _personalNumber;  
            private set { _personalNumber = value; }
        }

        public int BoatAmount
        {
            get => _boatAmount;  
            private set { _boatAmount = value; }
        }

        public List<Boat> Boats
        {
            get => _boats;  
            private set { _boats = value; }
        }

        public Member(int id, string name, string personalNumber)
        {
            ID = id;
            Name = name;
            PersonalNumber = personalNumber;
            Boats = new List<Boat>();
        }

        public void AddBoat(Boat boat)
        {
            Boats.Add(boat);
            BoatAmount += 1;
        }

        public void DeleteBoat(Boat boat)
        {
            Boats.Remove(boat);
            BoatAmount -= 1;
        }

        public void EditInformation(
            string newName, string newPersonalNumber
        )
        {
            Name = newName;
            PersonalNumber = newPersonalNumber;
        }
    }
}
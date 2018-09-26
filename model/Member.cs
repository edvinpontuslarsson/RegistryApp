using System;

namespace RegistryApp.model
{
    public class Member
    {
        public int _id; // set in this class, automatic

        public string _name;

        public string _personalNr;

        public uint _boatAmount;

        public Boat[] _boats;

        public Member(
            string name,
            string personalNr, 
            uint boatAmount
        )
        {
            _id = 1; // TODO: increment based on stored ones
            
            _name = name;
            _personalNr = personalNr;
            _boatAmount = boatAmount;
        }

        public void AddBoat(Boat boat)
        {
            // TODO: implement this
        }
    }
}
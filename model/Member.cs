using System;

namespace RegistryApp.model
{
    public class Member
    {
        public string _name;

        public string _personalNumber;

        public uint _boatAmount;

        public Boat[] _boats;

        public Member(
            string name,
            string personalNumber, 
            uint boatAmount
        )
        {
            _name = name;
            _personalNumber = personalNumber;
            _boatAmount = boatAmount;
        }
    }
}
using System;

namespace RegistryApp.model
{
    public class Boat
    {
        public string _type; 

        public int _length;

        public Boat(string type, int length)
        {
            _type = type; // if userInput !== lowercase one of listed types, set to Other
            _length = length;
        }
    }
}
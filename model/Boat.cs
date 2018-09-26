using System;

namespace RegistryApp.model
{
    public class Boat
    {
        public string _type; 

        public int _length;

        public Boat(string type, int length)
        {
            _type = type;
            _length = length;
        }
    }
}
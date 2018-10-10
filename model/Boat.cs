using System;

namespace RegistryApp.model
{
    public class Boat
    {
        private int _id;
        private string _type;
        private string _length;

        public int ID
        {
            get => _id;  
            private set { _id = value; }
        }

        public string Type
        {
            get => _type;  
            private set { _type = value; }
        }

        public string Length
        {
            get => _length;  
            private set { _length = value; }
        }

        public Boat(int id, string type, string length)
        {
            ID = id;
            Type = type;
            Length = length;
        }

        public void EditInformation(string newType, string newLength)
        {
            Type = newType;
            Length = newLength;
        }
    }
}
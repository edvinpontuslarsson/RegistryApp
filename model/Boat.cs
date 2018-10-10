using System;
using System.Runtime.Serialization;

namespace RegistryApp.model
{
    [DataContract] // for XML-conversion
    public class Boat
    {
        private int _id;
        private string _type;
        private string _length;

        // for XML-conversion
        [DataMember(Order = 1)]
        public int ID
        {
            get => _id;  
            private set { _id = value; }
        }

        [DataMember(Order = 2)]
        public string Type
        {
            get => _type;  
            private set { _type = value; }
        }

        [DataMember(Order = 3)]
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
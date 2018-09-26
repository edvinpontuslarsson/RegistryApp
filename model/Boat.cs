using System;

namespace RegistryApp.model
{
    public class Boat
    {
        // TODO: perhaps use enum BoatType instead
        public string _type; 

        public int _length;

        public Boat(string type, int length)
        {
            //_type = GetBoatTypeAsString(type);

            _type = type;
            _length = length;
        }

        /// <summary>
        /// TODO: Implement this
        /// </summary>
        private string GetBoatTypeAsString(BoatType type)
        {
            return "Not implemented yet";
        }
    }
}
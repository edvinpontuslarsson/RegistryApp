using System;
using System.IO;
using Newtonsoft.Json;

namespace RegistryApp.model
{
    public class Registry
    {
        private Member _member;

        private Boat[] _boats;

        public void AddMember(
            string name,
            string personalNumber, 
            uint boatAmount = 0
        )
        {
            _member = 
                new Member(name, personalNumber, boatAmount);
            StoreMember();
        }

        public void AddBoat(Boat boat)
        {
            // TODO: implement this
        }

        private void StoreMember()
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            jsonSerializer.NullValueHandling =
                NullValueHandling.Ignore;

            string projectDir = 
                Directory.GetCurrentDirectory();
            string storageDir = 
                $"{projectDir}/storage/registry.json";

            
        }
    }
}
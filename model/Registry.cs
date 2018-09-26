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
            string personalNr, 
            uint boatAmount = 0
        )
        {
            _member = 
                new Member(name, personalNr, boatAmount);
            StoreMember();
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
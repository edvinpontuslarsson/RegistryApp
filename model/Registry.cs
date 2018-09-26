using System;
using System.IO;
using Newtonsoft.Json;

namespace RegistryApp.model
{
    public class Registry
    {
        private Members _members;

        private Boat[] _boats;

        public void AddMember(
            string name,
            string personalNumber, 
            uint boatAmount = 0
        )
        {
            // first get all members, then add new one
            StoreMember();
        }

        public void AddBoat(Boat boat)
        {
            // TODO: implement this
        }

        private void StoreMember()
        {
            string projectDir = 
                Directory.GetCurrentDirectory();
            string storageDir = 
                $"{projectDir}/storage/members.json";

            

            
        }
/* 
        private Member GetMember()
        {

        }*/
    }
}
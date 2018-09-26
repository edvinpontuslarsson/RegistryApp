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
            Member a = new Member("Donald Duck", "19070926-313", 0);
            Member b = new Member("Batman", "19500926-5555", 0);

            Member[] bothMembers = new Member[2];

            bothMembers[0] = a;
            bothMembers[1] = b;

            Members members = new Members(bothMembers);

            string json = JsonConvert.SerializeObject(members);

            string projectDir = 
                Directory.GetCurrentDirectory();
            string storageDir = 
                $"{projectDir}/storage/members.json";

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@storageDir, true))
            {
                file.Write(json);
            }
        }
/* 
        private Member GetMember()
        {

        }*/
    }
}
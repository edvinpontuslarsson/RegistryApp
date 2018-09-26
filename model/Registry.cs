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
            string json = StoreMember(); // make void later

            Members members = GetMembers(json);
            Console.WriteLine(members._members[0]._name);
        }

        public void AddBoat(Boat boat)
        {
            // TODO: implement this
        }

        private string StoreMember() // just return string now to test, read file later
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

            return json;
        }

        private Members GetMembers(string json)
        {
            Member[] emptyNow = new Member[0];
            Members members = new Members(emptyNow);

            JsonConvert.PopulateObject(json, members);

            return members;
        }
    }
}
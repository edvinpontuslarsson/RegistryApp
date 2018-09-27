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
            // Console.WriteLine(members._members[0]._name);
        }

        public void AddBoat(Boat boat)
        {
            // TODO: implement this
        }

        private string StoreMember()
        {
            string projectDir = 
                Directory.GetCurrentDirectory();
            string storageDir = 
                $"{projectDir}/storage/members.json";

            // try first getting what json is, should be an array

            // Maybe then I don't need a Members, Members is the starting JSON

            /*
            
            Read file, populate Members with JSON array            
            
             */

            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-read-from-a-text-file
            
            string file = File.ReadAllText(storageDir);

            Members members = new Members();
            

            JsonConvert.PopulateObject(file, members);
            
            /* 
            Member a = new Member("Donald Duck", "19070926-313", 0);
            Member b = new Member("Batman", "19500926-5555", 0);

            Member[] bothMembers = new Member[2];

            bothMembers[0] = a;
            bothMembers[1] = b;
            */
            

            string json = JsonConvert.SerializeObject(members);

            

            using (System.IO.StreamWriter writer =
                new System.IO.StreamWriter(@storageDir, true))
            {
                writer.Write(json);
            }

            return json;
        }

        private Members GetMembers(string json)
        {
            Member[] emptyNow = new Member[0]; // hmm, maybe rethink member classes
            Members members = new Members();

            JsonConvert.PopulateObject(json, members);

            return members;
        }
    }
}
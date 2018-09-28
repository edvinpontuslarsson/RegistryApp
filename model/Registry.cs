using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegistryApp.model
{
    public class Registry
    {
        private MemberList _members;

        private Boat[] _boats;

        public void AddMember(string name, string personalNumber)
        {
            Member member = new Member();
            member.Name = name;
            member.PersonalNumber = personalNumber;

            // MemberList memberList = new MemberList();
            // memberList.AddMember(member);

            List<Member> members = new List<Member>();
            members.Add(member);

            PutXmlFile(members);
        }

        /// <summary>
        /// Using a method described here:
        /// https://www.codeproject.com/Articles/483055/XML-Serialization-and-Deserialization-Part
        /// </summary>
        private void PutXmlFile(List<Member> members)
        {
            string storageDirectory = GetStorageDirectory();

            XmlSerializer serializer = 
                new XmlSerializer(typeof(List<Member>));

            using (TextWriter writer = new StreamWriter(storageDirectory))
            {
                serializer.Serialize(writer, members);
            }
        }

        public void AddBoat(Boat boat)
        {
            // TODO: implement this
        }

        /*
        private MemberList GetMembers(string memberlist)
        {
            return "TODO: Implement this";
        }
        */

        private string GetStorageDirectory()
        {
            string projectDir = Directory.GetCurrentDirectory();
            return $"{projectDir}/storage/Members.xml";
        }
    }
}
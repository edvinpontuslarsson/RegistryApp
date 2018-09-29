using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegistryApp.model
{
    public class Registry
    {
        private Boat[] _boats;

        public void AddMember(string name, string personalNumber)
        {
            Member member = new Member();
            member.Name = name;
            member.PersonalNumber = personalNumber;

            // new MemberList class here
            MemberList memberList = new MemberList();
            memberList.AddMember(member);

            PutXmlFile(memberList);
            /* 
            List<Member> members;

            bool registryExists = File.Exists(GetStorageDirectory());

            if (registryExists)
            {
                members = GetMembers();
            } 
            else
            {
                members = new List<Member>();
            }

            members.Add(member);

            PutXmlFile(members); */
        }

        /// <summary>
        /// Inspired by a method described here:
        /// https://www.codeproject.com/Articles/483055/XML-Serialization-and-Deserialization-Part
        /// </summary>
        private void PutXmlFile(MemberList members)
        {
            string storageDirectory = GetStorageDirectory();

            XmlSerializer serializer = 
                new XmlSerializer(typeof(MemberList));

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
        public List<Member> GetMembers()
        {
            return "TODO: Implement this";
        }
  */
        private string GetStorageDirectory()
        {
            string projectDir = Directory.GetCurrentDirectory();
            string storageDirectory = 
                $"{projectDir}/storage/Registry.xml";
            return storageDirectory;
        }
    }
}
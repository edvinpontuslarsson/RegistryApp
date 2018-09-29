using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegistryApp.model
{
    public class RegistryModel
    {
        private Boat[] Boats;

        public void AddMember(string name, string personalNumber)
        {
            Member member = new Member();
            member.Name = name;
            member.PersonalNumber = personalNumber;

            MemberList memberList;

            bool registryExists = File.Exists(GetStorageDirectory());

            if (registryExists)
            {
                memberList = GetExistingMemberList();

                int memberAmount = memberList.Members.Count;
                member.ID = memberAmount + 1;
            } 
            else
            {
                memberList = new MemberList();
                member.ID = 1;
            }

            memberList.AddMember(member);

            PutXmlFile(memberList);
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

        /// <summary>
        /// Inspired by a method described here:
        /// https://www.codeproject.com/Articles/487571/XML-Serialization-and-Deserialization-Part-2
        /// </summary>
        public MemberList GetExistingMemberList()
        {
            XmlSerializer xmlDeserializer = new XmlSerializer(typeof(MemberList));
            TextReader reader = new StreamReader(GetStorageDirectory());

            object deserializer = xmlDeserializer.Deserialize(reader);
            MemberList memberList = (MemberList)deserializer;

            return memberList;
        }
  
        private string GetStorageDirectory()
        {
            string projectDir = Directory.GetCurrentDirectory();
            string storageDirectory = 
                $"{projectDir}/storage/Registry.xml";
            return storageDirectory;
        }
    }
}
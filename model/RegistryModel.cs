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

        public void AddBoat(int memberID, string type, string length)
        {
            MemberList memberList = GetExistingMemberList();
            
            if (memberID > memberList.Members.Count + 1) {
                throw new ArgumentException();
            }

            Boat boat = new Boat();
            boat.ID = 
                memberList.Members[memberID]
                .BoatAmount + 1;
            boat.Type = type;
            boat.Length =length;
            memberList.Members[memberID].AddBoat(boat);

            PutXmlFile(memberList);
        }

        public Member GetMember(MemberList memberList, int memberID)
        {
            bool registryExists = File.Exists(GetStorageDirectory());
            if (!registryExists) {
                throw new ArgumentException();
            }

            if (memberID > memberList.Members.Count + 1) {
                throw new ArgumentException();
            }

            return memberList.Members[memberID - 1];
        }

        /// <summary>
        /// Inspired by a method described here:
        /// https://www.codeproject.com/Articles/487571/XML-Serialization-and-Deserialization-Part-2
        /// </summary>
        public MemberList GetExistingMemberList()
        {
            bool registryExists = File.Exists(GetStorageDirectory());
            if (!registryExists) {
                throw new ArgumentException();
            }

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
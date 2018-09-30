using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegistryApp.model
{
    public class RegistryModel
    {
        private MemberList MemberList;

        private Member Member;

        private Boat Boat;

        public void AddMember(string name, string personalNumber)
        {
            Member = new Member();
            Member.Name = name;
            Member.PersonalNumber = personalNumber;

            bool registryExists = File.Exists(GetStorageDirectory());

            if (registryExists)
            {
                MemberList = GetExistingMemberList();

                int memberAmount = MemberList.Members.Count;
                Member.ID = memberAmount + 1;
            } 
            else
            {
                MemberList = new MemberList();
                Member.ID = 1;
            }

            MemberList.AddMember(Member);

            UpdateXmlFile();
        }

        /// <summary>
        /// Inspired by a method described here:
        /// https://www.codeproject.com/Articles/483055/XML-Serialization-and-Deserialization-Part
        /// </summary>
        private void UpdateXmlFile()
        {
            string storageDirectory = GetStorageDirectory();

            XmlSerializer serializer = 
                new XmlSerializer(typeof(MemberList));

            using (TextWriter writer = new StreamWriter(storageDirectory))
            {
                serializer.Serialize(writer, MemberList);
            }
        }

        public void EditMember(
            int memberID, string newName, string newPersonalNumber
        )
        {
            MemberList = GetExistingMemberList();
            
            if (memberID > MemberList.Members.Count + 1) {
                throw new ArgumentOutOfRangeException();
            }

            Member memberToEdit = MemberList.Members[memberID -1];

            memberToEdit.Name = newName;
            memberToEdit.PersonalNumber = newPersonalNumber;

            UpdateXmlFile();
        }

        public void AddBoat(int memberID, string type, string length)
        {
            MemberList = GetExistingMemberList();
            
            if (memberID > MemberList.Members.Count) {
                throw new ArgumentOutOfRangeException();
            }

            int memberIndex = memberID - 1;

            Boat = new Boat();
            Boat.ID = 
                MemberList.Members[memberIndex]
                .BoatAmount + 1;
            Boat.Type = type;
            Boat.Length =length;
            MemberList.Members[memberIndex].AddBoat(Boat);

            UpdateXmlFile();
        }

        public Member GetMember(int memberID)
        {
            bool registryExists = File.Exists(GetStorageDirectory());
            if (!registryExists) {
                throw new ArgumentOutOfRangeException();
            }

            if (memberID > MemberList.Members.Count + 1) {
                throw new ArgumentOutOfRangeException();
            }

            return MemberList.Members[memberID - 1];
        }

        /// <summary>
        /// Inspired by a method described here:
        /// https://www.codeproject.com/Articles/487571/XML-Serialization-and-Deserialization-Part-2
        /// </summary>
        public MemberList GetExistingMemberList()
        {
            bool registryExists = File.Exists(GetStorageDirectory());
            if (!registryExists) {
                throw new ArgumentOutOfRangeException();
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
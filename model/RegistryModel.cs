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
                MemberList = GetMemberList();

                int indexOfPreviousMember =
                    MemberList.Members.Count - 1;
                int idOfPreviousMember = 
                    MemberList.Members[indexOfPreviousMember].ID;

                Member.ID = idOfPreviousMember + 1;
            } 
            else
            {
                MemberList = new MemberList();
                Member.ID = 1;
            }

            MemberList.AddMember(Member);

            UpdateXmlFile();
        }

        public void AddBoat(int memberID, string type, string length)
        {
            Member currentMember = GetMember(memberID);

            Boat = new Boat();

            if (currentMember.Boats.Count > 0)
            {
                int indexOfPreviousBoat =
                    currentMember.Boats.Count - 1;
                int idOfPreviousBoat =
                    currentMember.Boats[indexOfPreviousBoat].ID;

                Boat.ID = idOfPreviousBoat + 1;
            }
            else
            {
                Boat.ID = 1;
            }

            Boat.Type = type;
            Boat.Length =length;

            currentMember.AddBoat(Boat);

            UpdateXmlFile();
        }

        /// <summary>
        /// Inspired by a method described here:
        /// https://www.codeproject.com/Articles/487571/XML-Serialization-and-Deserialization-Part-2
        /// </summary>
        public MemberList GetMemberList()
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

        public Member GetMember(int memberID)
        {
            MemberList = GetMemberList();

            int memberIndex = 0;
            bool memberExists = false;

            for (int i = 0; i < MemberList.Members.Count; i++)
            {
                if (MemberList.Members[i].ID == memberID)
                {
                    memberIndex = i;
                    memberExists = true;
                    break;
                }
            }

            if (!memberExists)
            {
                throw new ArgumentOutOfRangeException();
            }

            return MemberList.Members[memberIndex];
        }

        public Boat GetBoat(Member boatOwner, int boatID)
        {
            int boatIndex = 0;
            bool boatExists = false;

            for (int i = 0; i < boatOwner.Boats.Count; i++)
            {
                if (boatOwner.Boats[i].ID == boatID)
                {
                    boatIndex = i;
                    boatExists = true;
                    break;
                }
            }

            if (!boatExists)
            {
                throw new ArgumentOutOfRangeException();
            }

            return boatOwner.Boats[boatIndex];
        }

        public void EditMember(
            Member memberToEdit, string newName, string newPersonalNumber
        )
        {
            memberToEdit.Name = newName;
            memberToEdit.PersonalNumber = newPersonalNumber;

            UpdateXmlFile();
        }

        public void EditBoat(
            Boat boatToEdit, string newType, string newLength
        )
        {
            boatToEdit.Type = newType;
            boatToEdit.Length = newLength;

            UpdateXmlFile();
        }

        public void DeleteMember(int memberID)
        {
            Member memberToDelete = GetMember(memberID);
            MemberList.Members.Remove(memberToDelete);
            UpdateXmlFile();
        }

        public void DeleteBoat(int memberID, int boatID)
        {
            Member boatOwner = GetMember(memberID);
            Boat boatToDelete = GetBoat(boatOwner, boatID);
            boatOwner.Boats.Remove(boatToDelete);

            boatOwner.BoatAmount -= 1;

            UpdateXmlFile();
        }

        private string GetStorageDirectory()
        {
            string projectDir = Directory.GetCurrentDirectory();
            string storageDirectory = 
                $"{projectDir}/storage/Registry.xml";
            return storageDirectory;
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
    }
}
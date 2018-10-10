using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RegistryApp.model
{
    public class RegistryModel
    {
        private MemberList _memberList;

        public void StoreMember(string name, string personalNumber)
        {
            Member member; //= new Member();
            // member.Name = name;
            // member.PersonalNumber = personalNumber;

            bool registryExists = File.Exists(GetStoragePath());
            
            if (registryExists)
            {
                _memberList = GetMemberList();

                int indexOfPreviousMember =
                    _memberList.Members.Count - 1;
                int idOfPreviousMember = 
                    _memberList.Members[indexOfPreviousMember].ID;

                member.ID = idOfPreviousMember + 1;

                // instansiate member here
            } 
            else
            {
                _memberList = new MemberList();
                member.ID = 1;
            }

            _memberList.AddMember(member);

            UpdateXmlFile();
        }

        public void AddBoat(int memberID, string type, string length)
        {
            Member currentMember = GetMember(memberID);

            Boat boat = new Boat();

            if (currentMember.Boats.Count > 0)
            {
                int indexOfPreviousBoat =
                    currentMember.Boats.Count - 1;
                int idOfPreviousBoat =
                    currentMember.Boats[indexOfPreviousBoat].ID;

                boat.ID = idOfPreviousBoat + 1;
            }
            else
            {
                boat.ID = 1;
            }

            boat.Type = type;
            boat.Length =length;

            // handled in Member
            currentMember.BoatAmount += 1; 

            UpdateXmlFile();
        }

        public Member GetMember(int memberID)
        {
            _memberList = GetMemberList();

            int memberIndex = 0;

            bool memberExists =
                _memberList.Members
                .Exists(member => member.ID == memberID);

            if (!memberExists)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _memberList.Members[memberIndex];
        }

        public Boat GetBoat(Member boatOwner, int boatID)
        {
            int boatIndex = 0;

            bool boatExists = 
                boatOwner.Boats.Exists(boat => boat.ID == boatID);

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
            memberToEdit.PersonalNumber= newPersonalNumber;

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
            _memberList.Members.Remove(memberToDelete);
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

        private string GetStoragePath()
        {
            string projectDir = Directory.GetCurrentDirectory();
            string storagePath = 
                $"{projectDir}/storage/Registry.xml";
            return storagePath;
        }

        /// <summary>
        /// Inspired by a method described here:
        /// https://www.codeproject.com/Articles/487571/XML-Serialization-and-Deserialization-Part-2
        /// </summary>
        public MemberList GetMemberList()
        {
            bool registryExists = File.Exists(GetStoragePath());
            if (!registryExists) {
                throw new ArgumentOutOfRangeException();
            }

            XmlSerializer xmlDeserializer = new XmlSerializer(typeof(MemberList));
            TextReader reader = new StreamReader(GetStoragePath());

            object deserializer = xmlDeserializer.Deserialize(reader);
            MemberList memberList = (MemberList)deserializer;

            return memberList;
        }

        /// <summary>
        /// Inspired by a method described here:
        /// https://www.codeproject.com/Articles/483055/XML-Serialization-and-Deserialization-Part
        /// </summary>
        private void UpdateXmlFile()
        {
            string storageDirectory = GetStoragePath();

            XmlSerializer serializer = 
                new XmlSerializer(typeof(MemberList));

            using (TextWriter writer = new StreamWriter(storageDirectory))
            {
                serializer.Serialize(writer, _memberList);
            }
        }  
    }
}
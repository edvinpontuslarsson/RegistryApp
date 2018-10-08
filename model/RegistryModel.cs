using System;
using System.IO;
using System.Collections.Generic;

namespace RegistryApp.model
{
    public class RegistryModel
    {
        private DAO _dao;

        public RegistryModel()
        {
            _dao = new DAO();
        }

        public void StoreMember(string name, string personalNumber)
        {
            Member member = new Member();
            member.Name = name;
            member.PersonalNumber = personalNumber;

            // use the public bool method in DAO instead
            bool registryExists = File.Exists(GetStorageDirectory());

            if (registryExists)
            {
                // now broken because removed field, should be local var
                _memberList = GetMemberList();

                int indexOfPreviousMember =
                    _memberList.Members.Count - 1;
                int idOfPreviousMember = 
                    _memberList.Members[indexOfPreviousMember].ID;

                member.ID = idOfPreviousMember + 1;
            } 
            else
            {
                _memberList = new MemberList();
                member.ID = 1;
            }

            _memberList.Members.Add(member);

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

            currentMember.Boats.Add(boat);
            currentMember.BoatAmount += 1; 

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
            _memberList = GetMemberList();

            int memberIndex = 0;
            bool memberExists = false;

            for (int i = 0; i < _memberList.Members.Count; i++)
            {
                if (_memberList.Members[i].ID == memberID)
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

            return _memberList.Members[memberIndex];
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
    }
}
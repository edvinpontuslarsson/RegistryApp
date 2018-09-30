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
            Member memberToEdit = GetMember(memberID);

            memberToEdit.Name = newName;
            memberToEdit.PersonalNumber = newPersonalNumber;

            UpdateXmlFile();
        }

        public void DeleteMember(int memberID)
        {
            MemberList = GetExistingMemberList();
            int memberIndex = memberID - 1; // OK, have to redo
            MemberList.Members.RemoveAt(memberIndex);
            UpdateXmlFile();
        }

        public void DeleteBoat(int memberID)
        {
            // TODO: do this
        }

        public void EditBoat(
            Boat boatToEdit, string newType, string newLength
        )
        {
            boatToEdit.Type = newType;
            boatToEdit.Length = newLength;

            UpdateXmlFile();
        }

        public Boat GetBoat(int memberID, int boatID)
        {
            MemberList = GetExistingMemberList();

            
            
            // TODO: this is obviously wrong, fix
            

            return MemberList.Members[0].Boats[0];
        }
        

        public Member GetMember(int memberID)
        {
            MemberList = GetExistingMemberList();

            // just to initialize variable:
            Member rightMember = MemberList.Members[0];

            bool doesExist = false;

            foreach (Member member in MemberList.Members)
            {
                if (member.ID == memberID)
                {
                    rightMember = member;
                    doesExist = true;
                    break;
                }
            }

            if (!doesExist)
            {
                throw new ArgumentOutOfRangeException();
            }

            return rightMember;
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
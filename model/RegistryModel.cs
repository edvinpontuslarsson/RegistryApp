using System;

namespace RegistryApp.model
{
    public class RegistryModel
    {
        private StorageModel _storageModel;
        private MemberList _memberList;

        public RegistryModel()
        {
            _storageModel = new StorageModel();
        }

        public MemberList GetMemberList() => _storageModel.GetMemberList();

        public void AddMember(string name, string personalNumber)
        {
            Member member;
            int memberID;
            
            if (_storageModel.RegistryExists())
            {
                _memberList = GetMemberList();

                int indexOfPreviousMember =
                    _memberList.Members.Count - 1;
                int idOfPreviousMember = 
                    _memberList.Members[indexOfPreviousMember].ID;

                memberID = idOfPreviousMember + 1;
            } 
            else
            {
                _memberList = new MemberList();
                memberID = 1;
            }

            member = new Member(memberID, name, personalNumber);

            _memberList.AddMember(member);

            _storageModel.UpdateXmlFile(_memberList);
        }

        public void AddBoat(int memberID, string type, string length)
        {
            Member currentMember = GetMember(memberID);
            int boatID;

            if (currentMember.Boats.Count > 0)
            {
                int indexOfPreviousBoat =
                    currentMember.Boats.Count - 1;
                int idOfPreviousBoat =
                    currentMember.Boats[indexOfPreviousBoat].ID;

                boatID = idOfPreviousBoat + 1;
            }
            else
            {
                boatID = 1;
            }

            Boat boat = new Boat(boatID, type, length);
            currentMember.AddBoat(boat); 

            _storageModel.UpdateXmlFile(_memberList);
        }

        public Member GetMember(int memberID)
        {
            _memberList = GetMemberList();
            Member relevantMember = 
                _memberList.Members.Find(
                    member => member.ID == memberID
                );

            return relevantMember;
        }

        public Boat GetBoat(Member boatOwner, int boatID)
        {
            Boat relevantBoat = boatOwner.Boats.Find(
                boat => boat.ID == boatID
            );
            return relevantBoat;
        }

        public void EditMember(
            Member memberToEdit, string newName, string newPersonalNumber
        )
        {
            memberToEdit.EditInformation(newName, newPersonalNumber);
            _storageModel.UpdateXmlFile(_memberList);
        }

        public void EditBoat(
            Boat boatToEdit, string newType, string newLength
        )
        {
            boatToEdit.EditInformation(newType, newLength);
            _storageModel.UpdateXmlFile(_memberList);
        }

        public void DeleteMember(int memberID)
        {
            Member memberToDelete = GetMember(memberID);
            _memberList.DeleteMember(memberToDelete);
            _storageModel.UpdateXmlFile(_memberList);
        }

        public void DeleteBoat(int memberID, int boatID)
        {
            Member boatOwner = GetMember(memberID);
            Boat boatToDelete = GetBoat(boatOwner, boatID);
        
            boatOwner.DeleteBoat(boatToDelete);
            _storageModel.UpdateXmlFile(_memberList);
        }
    }
}
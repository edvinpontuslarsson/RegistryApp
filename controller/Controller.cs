using System;

namespace RegistryApp.controller
{
    public class Controller
    {
        private view.IndexUI _indexUI;

        private view.RegistryUI _registryUI;

        private model.RegistryModel _registryModel;

        public Controller(
            view.IndexUI indexUI,
            view.RegistryUI registryUI,
            model.RegistryModel registryModel
        )
        {
            _indexUI = indexUI;
            _registryUI = registryUI;
            _registryModel = registryModel;

            _indexUI.GreetUser();
        }

        public void ProcessUserInput(string[] userArguments)
        {
            if (_indexUI.UserWantsToListOptions(userArguments)) 
            {
                _indexUI.ListOptions();
            }
            else if (_indexUI.UserWantsToAddMember(userArguments))
            {
                HandleAddMember();
            }
            else if (_indexUI.UserWantsToAddBoat(userArguments))
            {
                HandleAddBoat(userArguments);
            }
            else if (_indexUI.UserWantsToListMembers(userArguments))
            {
                HandleListAllMembers(userArguments);
            }
            else if (_indexUI.UserWantsToListOneMember(userArguments))
            {
                HanleListOneMember(userArguments);
            }
            else if (_indexUI.UserWantsToEditMember(userArguments))
            {
                HandleEditMember(userArguments);
            }
            else if (_indexUI.UserWantsToEditBoat(userArguments))
            {
                HandleEditBoat(userArguments);
            }
            else if (_indexUI.UserWantsToDeleteMember(userArguments))
            {
                HandleDeleteMember(userArguments);
            }
            else if (_indexUI.UserWantsToDeleteBoat(userArguments))
            {
                HandleDeleteBoat(userArguments);
            }
            else
            {
                _indexUI.InstructUser(true);
            }
        }

        private void HandleAddMember()
        {
            string name = _registryUI.GetName();
            string personalNumber = 
                _registryUI.GetPersonalNumber();

            _registryModel.AddMember(name, personalNumber);
        }

        private void HandleAddBoat(string[] userArguments)
        {
            int memberID = _registryUI.GetMemberID(userArguments);
            string boatType = _registryUI.GetBoatType();
            string boatLength = _registryUI.GetBoatLength();
            
            _registryModel.AddBoat(memberID, boatType, boatLength);
        }

        private void HandleListAllMembers(string[] userArguments)
        {
            model.MemberList memberList = _registryModel.GetMemberList();
                
            _registryUI.ListAllMembers(
                memberList,
                _indexUI.UserWantsVerboseList(userArguments)
            );
        }

        private void HanleListOneMember(string[] userArguments)
        {
            int memberID = _registryUI.GetMemberID(userArguments);
            model.Member member = _registryModel.GetMember(memberID);
            _registryUI.ListOneMember(member);
        }

        private void HandleEditMember(string[] userArguments)
        {
            int memberID = _registryUI.GetMemberID(userArguments);
            model.Member memberToEdit = _registryModel.GetMember(memberID);            
            
            string newName = _registryUI.GetNewName(memberToEdit);
            string newPersonalNr = _registryUI.GetNewPersonalNumber(memberToEdit);
            _registryModel.EditMember(memberToEdit, newName, newPersonalNr);
        }

        private void HandleEditBoat(string[] userArguments)
        {
            int memberID = _registryUI.GetMemberID(userArguments);
            model.Member boatOwner = _registryModel.GetMember(memberID);
            
            int boatID = _registryUI.GetBoatID(userArguments);
            model.Boat boatToEdit = _registryModel.GetBoat(boatOwner, boatID);

            string newType = _registryUI.GetNewBoatType(boatToEdit);
            string newLength = _registryUI.GetNewBoatLength(boatToEdit);
            _registryModel.EditBoat(boatToEdit, newType, newLength);
        }

        private void HandleDeleteMember(string[] userArguments)
        {
            int memberID = _registryUI.GetMemberID(userArguments);
            _registryModel.DeleteMember(memberID);
        }

        private void HandleDeleteBoat(string[] userArguments)
        {
            int memberID = _registryUI.GetMemberID(userArguments);
            int boatID = _registryUI.GetBoatID(userArguments);
            _registryModel.DeleteBoat(memberID, boatID);
        }
    }
}
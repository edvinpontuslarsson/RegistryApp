using System;

namespace RegistryApp.controller
{
    public class Controller
    {
        private view.IndexUI _indexUI;

        private view.RegistryUI _registryUI;

        private view.SuccessMessage _successMessage;

        private model.RegistryModel _registryModel;

        public Controller(
            view.IndexUI indexUI,
            view.RegistryUI registryUI,
            view.SuccessMessage successMessage,
            model.RegistryModel registryModel
        )
        {
            _indexUI = indexUI;
            _registryUI = registryUI;
            _successMessage = successMessage;
            _registryModel = registryModel;

            _indexUI.GreetUser();
        }

        public void Interact()
        {
            try
            {
                _indexUI.AskForUserInput();
                string[] userArguments =
                    _indexUI.GetUserArguments();
                ProcessUserInput(userArguments);
            }
            catch (Exception exception)
            {
                _indexUI.HandleException(exception);
            }
        }

        private void ProcessUserInput(string[] userArguments)
        {
            if (_indexUI.UserWantsToListOptions(userArguments)) 
            {
                _indexUI.ListOptions();
            }
            else if (_indexUI.UserWantsToAddMember(userArguments))
            {
                string name = _registryUI.GetName();
                string personalNumber = 
                    _registryUI.GetPersonalNumber();

                _registryModel.StoreMember(name, personalNumber);

                _registryUI.DisplaySuccessMessage(
                    _successMessage.MemberAdded
                );
            }
            else if (_indexUI.UserWantsToAddBoat(userArguments))
            {
                int addBoatToMemberID = 
                    GetParsedIntOrException(userArguments[4]);                    
                _registryUI.AddBoat(addBoatToMemberID);
            }
            else if (_indexUI.UserWantsToListMembers(userArguments))
            {
                _registryUI.ListAllMembers(
                    _indexUI.UserWantsVerboseList(userArguments)
                );
            }
            else if (_indexUI.UserWantsToListOneMember(userArguments))
            {
                int infoMemberId = // GetMemberID()
                    GetParsedIntOrException(userArguments[2]);
                _registryUI.ListOneMember(infoMemberId);
            }
            else if (_indexUI.UserWantsToEditMember(userArguments))
            {
                int editMemberID =
                    GetParsedIntOrException(userArguments[2]);
                _registryUI.EditMember(editMemberID);
            }
            else if (_indexUI.UserWantsToEditBoat(userArguments))
            {
                int ownerOfEditBoatID =
                    GetParsedIntOrException(userArguments[5]);

                int boatToEditID =
                    GetParsedIntOrException(userArguments[2]);

                _registryUI.EditBoat(
                    ownerOfEditBoatID, boatToEditID
                );
            }
            else if (_indexUI.UserWantsToDeleteMember(userArguments))
            {
                int deleteMemberID =
                    GetParsedIntOrException(userArguments[2]);
                _registryUI.DeleteMember(deleteMemberID);
            }
            else if (_indexUI.UserWantsToDeleteBoat(userArguments))
            {
                int ownerOfDeleteBoatID =
                    GetParsedIntOrException(userArguments[5]);
                int deleteBoatID =
                    GetParsedIntOrException(userArguments[2]);
                _registryUI.DeleteBoat(
                    ownerOfDeleteBoatID, deleteBoatID
                );
            }
            else
            {
                _indexUI.InstructUser(true);
            }
        }
    }
}
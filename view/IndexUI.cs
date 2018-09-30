using System;

namespace RegistryApp.view
{
    public class IndexUI
    {
        private UserCommands UserCommands;

        private RegistryUI RegistryUI;

        public IndexUI()
        {
            RegistryUI = new RegistryUI();
            UserCommands = new UserCommands();
        }

        public void GreetUser() 
        {
            Console.WriteLine("Welcome!");
            InstructUser();
        }

        public void Interact()
        {
            AskForUserInput();

            string[] userArguments = GetUserArguments();
            ProcessUserInput(userArguments);
        }

        public void HandleException(Exception exception)
        {
            if (exception is FormatException)
            {
                InstructUser(true);
            }
            else if (exception is ArgumentOutOfRangeException)
            {
                Console.WriteLine("\nRequested resource does not exist \n");
            }
            else
            {
                Console.WriteLine(exception);
            }
        }

        private void InstructUser(bool error = false) 
        {
            if (error) {
                RectifyUser("\nUnknown command");
            }

            string instruction = "\nTo list commands, enter:\n  list commands";

            Console.WriteLine(instruction);
        }

        private void AskForUserInput()
        {
            Console.Write("\n  How can I be of service?: ");
        }

        private string[] GetUserArguments()
        {
            string userInput = Console.ReadLine();
            string lowUserInput = userInput.ToLower();

            string[] userArguments =
                lowUserInput.Split(" ");
            
            return userArguments;
        }

        private int GetParsedIntOrException(string input)
        {
            int integer;

            bool canBeInt =
                Int32.TryParse(input, out integer);
            if (!canBeInt)
            {
                throw new FormatException();
            }
            return integer;
        }

        private void ListCommands()
        {
            string[] commands = UserCommands.Commands;
            foreach (string command in commands)
            {
                Console.WriteLine(command);
            }
        }

        private void RectifyUser(string instruction)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(instruction);
            Console.ResetColor();
        }

        private void ProcessUserInput(string[] userArguments)
        {
            if (userArguments[0] == "list" &&
                userArguments[1] == "commands") 
            {
                ListCommands();
            }
            else if (userArguments[0] == "add" &&
                userArguments[1] == "member")
            {
                RegistryUI.AddMember();
            }
            else if (userArguments[0] == "add" &&
                userArguments[1] == "boat" &&
                userArguments[4] != null)
            {
                int addBoatToMemberID = 
                    GetParsedIntOrException(userArguments[4]);                    
                RegistryUI.AddBoat(addBoatToMemberID);
            }
            else if (userArguments[0] == "list" &&
                userArguments[1] == "all")
            {
                RegistryUI.ListAllMembers(
                    userArguments[3] == "verbose"
                );
            }
            else if (userArguments[0] == "list" &&
                userArguments[1] == "member")
            {
                int infoMemberId =
                    GetParsedIntOrException(userArguments[2]);
                RegistryUI.ListOneMember(infoMemberId);
            }
            else if (userArguments[0] == "edit" &&
                userArguments[1] == "member")
            {
                int editMemberID =
                    GetParsedIntOrException(userArguments[2]);
                RegistryUI.EditMember(editMemberID);
            }
            else if (userArguments[0] == "edit" &&
                userArguments[1] == "boat")
            {
                int ownerOfEditBoatID =
                    GetParsedIntOrException(userArguments[5]);

                int boatToEditID =
                    GetParsedIntOrException(userArguments[2]);

                RegistryUI.EditBoat(
                    ownerOfEditBoatID, boatToEditID
                );
            }
            else if (userArguments[0] == "delete" &&
                userArguments[1] == "member")
            {
                int deleteMemberID =
                    GetParsedIntOrException(userArguments[2]);
                RegistryUI.DeleteMember(deleteMemberID);
            }
            else if (userArguments[0] == "delete" &&
                userArguments[1] == "boat")
            {
                int ownerOfDeleteBoatID =
                    GetParsedIntOrException(userArguments[5]);
                int deleteBoatID =
                    GetParsedIntOrException(userArguments[2]);
                RegistryUI.DeleteBoat(
                    ownerOfDeleteBoatID, deleteBoatID
                );
            }
            else
            {
                InstructUser(true);
            }
        }
    }
}
using System;
using System.Linq;

namespace RegistryApp.view
{
    public class IndexUI
    {
        private string[] UserArguments;

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

            UserArguments = GetUserArguments();
            ProcessUserInput();
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

        private void RectifyUser(string instruction)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(instruction);
            Console.ResetColor();
        }

        private void ListCommands()
        {
            string[] commands = UserCommands.Commands;
            foreach (string command in commands)
            {
                Console.WriteLine(command);
            }
        }

        private void AskForUserInput()
        {
            Console.Write("\n  How can I be of service?: ");
        }

        private string[] GetUserArguments()
        {
            string userInput = Console.ReadLine();
            string lowUserInput = userInput.ToLower();

            string[] UserArguments =
                lowUserInput.Split(" ");
            
            return UserArguments;
        }

        private bool UserWantsTo(string verb, string noun)
        {
            bool foundVerb = UserArguments.Contains(verb);
            bool foundNoun = UserArguments.Contains(noun);
            return foundVerb && foundNoun;
        }

        private void ProcessUserInput()
        {
            if (UserWantsTo("list", "commands")) 
            {
                ListCommands();
            }
            else if (UserWantsTo("add", "member"))
            {
                RegistryUI.AddMember();
            }
            else if (UserWantsTo("add", "boat"))
            {
                int addBoatToMemberID = 
                    GetParsedIntOrException(UserArguments[4]);                    
                RegistryUI.AddBoat(addBoatToMemberID);
            }
            else if (UserWantsTo("list", "members"))
            {
                RegistryUI.ListAllMembers(
                    UserArguments[3] == "verbose"
                );
            }
            else if (UserWantsTo("list", "member"))
            {
                int infoMemberId =
                    GetParsedIntOrException(UserArguments[2]);
                RegistryUI.ListOneMember(infoMemberId);
            }
            else if (UserWantsTo("edit", "member"))
            {
                int editMemberID =
                    GetParsedIntOrException(UserArguments[2]);
                RegistryUI.EditMember(editMemberID);
            }
            else if (UserWantsTo("edit", "boat"))
            {
                int ownerOfEditBoatID =
                    GetParsedIntOrException(UserArguments[5]);

                int boatToEditID =
                    GetParsedIntOrException(UserArguments[2]);

                RegistryUI.EditBoat(
                    ownerOfEditBoatID, boatToEditID
                );
            }
            else if (UserWantsTo("delete", "member"))
            {
                int deleteMemberID =
                    GetParsedIntOrException(UserArguments[2]);
                RegistryUI.DeleteMember(deleteMemberID);
            }
            else if (UserWantsTo("delete", "boat"))
            {
                int ownerOfDeleteBoatID =
                    GetParsedIntOrException(UserArguments[5]);
                int deleteBoatID =
                    GetParsedIntOrException(UserArguments[2]);
                RegistryUI.DeleteBoat(
                    ownerOfDeleteBoatID, deleteBoatID
                );
            }
            else
            {
                InstructUser(true);
            }
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
    }
}
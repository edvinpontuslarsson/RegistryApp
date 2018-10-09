using System;

namespace RegistryApp.view
{
    public class IndexUI
    {
        private RegistryUI _registryUI;

        public IndexUI()
        {
            _registryUI = new RegistryUI();
        }

        public void GreetUser() 
        {
            Console.WriteLine("Welcome!");
            InstructUser();
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

        public void InstructUser(bool error = false) 
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

        public void AskForUserInput()
        {
            Console.Write("\n  How can I be of service?: ");
        }

        public string[] GetUserArguments()
        {
            string userInput = Console.ReadLine();
            string lowUserInput = userInput.ToLower();

            string[] userArguments =
                lowUserInput.Split(" ");
            
            return userArguments;
        }

        public void ListOptions()
        {
            UserCommandArray userCommands = new UserCommandArray();
            string[] commands =userCommands.Commands;
            foreach (string command in commands)
            {
                Console.WriteLine(command);
            }
        }

        public bool UserWantsToListOptions(string[] userArguments) =>
            userArguments[0] == "list" && userArguments[1] =="commands";

        public bool UserWantsToAddMember(string[] userArguments) =>
            userArguments[0] == "add" && userArguments[1] == "member";

        public bool UserWantsToAddBoat(string[] userArguments) =>
            userArguments[0] == "add" && userArguments[1] == "boat" &&
            userArguments[4] != null;
        
        public bool UserWantsToListMembers(string[] userArguments) =>
            userArguments[0] == "list" && userArguments[1] == "all";

        public bool UserWantsVerboseList(string[] userArguments) =>
            userArguments[3] == "verbose";
        
        public bool UserWantsToListOneMember(string[] userArguments) =>
            userArguments[0] == "list" && userArguments[1] == "member";

        public bool UserWantsToEditMember(string[] userArguments) =>
            userArguments[0] == "edit" && userArguments[1] == "member";

        public bool UserWantsToEditBoat(string[] userArguments) =>
            userArguments[0] == "edit" && userArguments[1] == "boat";


        public bool UserWantsToDeleteMember(string[] userArguments) =>
            userArguments[0] == "delete" && userArguments[1] == "member";

        public bool UserWantsToDeleteBoat(string[] userArguments) =>
            userArguments[0] == "delete" && userArguments[1] == "boat";
    }
}
using System;

namespace RegistryApp.view
{
    public class IndexUI
    {
        private RegistryUI RegistryUI { get; set; }

        public IndexUI()
        {
            RegistryUI = new RegistryUI();
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
                int memberID = 
                    GetParsedIntOrException(userArguments[4])
                    - 1;
                    
                RegistryUI.AddBoat(memberID);
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
                throw new ArgumentException();
            }
            return integer;
        }

        // TODO: have array with commands in separate view class
        // here just loop and Console.WriteLine every item
        private void ListCommands()
        {
            Console.WriteLine(
                "To list commands, enter:\n" +
                "  list commands\n"
            );

            Console.WriteLine(
                "To add member, enter:\n" +
                "  add member\n"
            );
             
            Console.WriteLine(
                "To add boat to a member, enter:\n" +
                "  add boat to member [int memberID]\n"
            );
            /*
            Console.WriteLine(
                "To edit a member, enter:\n" +
                "  edit member [int memberID]\n"
            );

            Console.WriteLine(
                "To edit boat of a member, enter:\n" +
                "  edit boat [int boatID] of " + 
                "member [int memberID]\n"
            );*/
        }

        private void RectifyUser(string instruction)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(instruction);
            Console.ResetColor();
        }
    }
}
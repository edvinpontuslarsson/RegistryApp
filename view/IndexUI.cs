using System;

namespace RegistryApp.view
{
    public class IndexUI
    {
        private model.RegistryModel RegistryModel { get; set; }

        public IndexUI()
        {
            RegistryModel = new model.RegistryModel();
        }

        public void GreetUser() 
        {
            Console.WriteLine("Welcome!");
        }

        public void Interact()
        {
            InstructUser();
            AskForUserInput();

            string userInput = GetUserInput();
            ProcessUserInput(userInput);
        }

        public void HandleException(Exception exception)
        {

        }

        private void InstructUser(bool error = false) 
        {
            string instruction = "";

            if (error) {
                instruction += "Unknown command \n";
            }

            instruction += "\nTo list commands, enter:\n  list commands\n";

            Console.WriteLine(instruction);
        }

        private void AskForUserInput()
        {
            Console.Write("  How can I be of service?: ");
        }

        private string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

        private void ProcessUserInput(string userInput)
        {}

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
                "  add member [string name] [string personalNumber]\n"
            );

            Console.WriteLine(
                "To add boat to a member, enter:\n" +
                "  add boat [string boatType] [int length] to member [int memberIndex]\n"
            );

            Console.WriteLine(
                "To edit name of a member, enter:\n" +
                "  edit member [int memberIndex]" + 
                "name to [string name]\n"
            );

            Console.WriteLine(
                "To edit boat type of a member, enter:\n" +
                "  edit member [int memberIndex]" + 
                "boat type of [int boatIndex] to [string boatType]\n"
            );
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
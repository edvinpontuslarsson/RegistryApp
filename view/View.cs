using System;

namespace RegistryApp.view
{
    public class View
    {
        public void GreetUser() 
        {
            Console.WriteLine("Welcome!");
        }

        public void InstructUser(bool error = false) 
        {
            string instruction = "";

            if (error) {
                instruction += "Unknown command \n";
            }

            instruction += "\nTo list commands, enter:\n  list commands\n";

            Console.WriteLine(instruction);
        }

        public void AskForUserInput()
        {
            Console.Write("  How can I be of service?: ");
        }

        public void ListCommands()
        {
            Console.WriteLine(
                "To list commands, enter:\n" +
                "  list commands\n"
            );

            Console.WriteLine(
                "To add member, enter:\n" +
                "  add member [string name] [string personalNumber]"
            );

            Console.WriteLine(
                "To add boat to a member, enter:\n" +
                "  add boat [string boatType] [int length] to member [int memberIndex]"
            );

            Console.WriteLine(
                "To edit name of a member, enter:\n" +
                "  edit member [int memberIndex]" + 
                "name to [string name]"
            );

            Console.WriteLine(
                "To edit boat type of a member, enter:\n" +
                "  edit member [int memberIndex]" + 
                "boat type of [int boatIndex] to [string boatType]"
            );
        }

        public void RectifyUser(string instruction)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(instruction);
            Console.ResetColor();
        }

        public void ConsoleResult(string result) 
        {
            Console.WriteLine(result);
        }
    }
}
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

            instruction += "To list commands enter: \n  list commands";

            Console.WriteLine(instruction);
        }

        public void AskForUserInput()
        {
            Console.Write(" How can I be of service?:");
        }

        public void RectifyUser(string instruction)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(instruction);
            Console.ResetColor();
        }

        public void ConsoleResult(string result) {
            Console.WriteLine(result);
        }
    }
}
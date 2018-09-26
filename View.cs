using System;

namespace RegistryApp
{
    public class View
    {
        public void GreetUser() 
        {
            string greeting = "Welcome! ";
            string instruction =
                "Please enter a positive integer ";
            string info = 
                "and we will double it for you! ";

            string label = "Integer: ";

            Console.WriteLine(
                $"{greeting}{instruction}{info}"
            );

            Console.Write(label);
        }

        public void InstructUser(string instruction)
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
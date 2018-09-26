using System;

namespace RegistryApp.view
{
    public class View
    {
        public void GreetUser() 
        {
            string greeting = "Welcome! ";
            string instruction =
                "Please enter two integers ";
            string info = 
                "and then get the sum of them! ";

            string label = "Integers: ";

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
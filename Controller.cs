using System;

namespace RegistryApp
{
    public class Controller
    {
        private Helper _helper;

        private View _view;

        public Controller()
        {
            _helper = new Helper();
            _view = new View();
        }

        public void StartApp()
        {
            while (true) // while app is running
            {
                try
                {
                    RunApp();
                }
                catch (Exception)
                {
                    _view.InstructUser("Please enter two integers.");
                }
            }
        }

        private void RunApp()
        {
            _view.GreetUser();

            string userInput = GetUserInput();
            string[] arguments = 
                _helper.SplitBy(userInput, " ");
            int[] intArguments = 
                _helper.GetIntsFromStrings(arguments);

            int a = intArguments[0];
            int b = intArguments[1];

            int result = _helper.GetSum(a, b);
            string resultAsString = 
                _helper.GetStringFromInt(result);

            _view.ConsoleResult(resultAsString);
        }

        private string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }
    }
}
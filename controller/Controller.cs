using System;

namespace RegistryApp.controller
{
    public class Controller
    {
        private model.Helper _helper;

        private view.View _view;

        public Controller()
        {
            _helper = new model.Helper();
            _view = new view.View();

            model.Registry registry = 
                new model.Registry();

            registry.AddMember("Donald Duck", "19070926-313", 0);
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

        private void RunApp() // split into smaller methods
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
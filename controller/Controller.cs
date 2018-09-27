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

        public void RunApp()
        {
            _view.GreetUser();

            while (true) // while app is running
            {
                bool error = false;
                
                try
                {                    
                    _view.InstructUser(error);
                    _view.AskForUserInput();

                    string userInput = GetUserInput();
                    ProcessUserInput(userInput);
                }
                catch (Exception)
                {
                    error = true;
                }
            }
        }

        private void ProcessUserInput(string userInput)
        {                        
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
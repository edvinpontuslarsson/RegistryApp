using System;

namespace RegistryApp.controller
{
    public class Controller
    {
        private model.Helper _helper;

        private model.Registry _registry;

        private view.View _view;

        public Controller()
        {
            _helper = new model.Helper();
            _view = new view.View();
            _registry = new model.Registry();

            
            _registry.AddMember("Donald Duck", "19070926-313");
        }

        public void RunApp()
        {
            _view.GreetUser();

            while (true) // while app is running
            {
                try
                {                    
                    _view.InstructUser();
                    _view.AskForUserInput();

                    string userInput = GetUserInput();
                    ProcessUserInput(userInput);
                }
                catch (Exception e)
                {
                    // _view.ConsoleException(e);
                }
            }
        }

        private string GetUserInput()
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

        private void ProcessUserInput(string userInput)
        {                        
            string[] arguments = 
                _helper.SplitBy(userInput, " ");

            // OK, enter name and personalNumber
            
            
        }
    }
}
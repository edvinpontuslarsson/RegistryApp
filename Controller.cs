using System;

namespace RegistryApp
{
    public class Controller
    {
        private int _userInput;
        
        private Model _model;

        private View _view;

        public void Initialize()
        {
            _model = new Model();
            _view = new View();

            RunApp();
        }

        public void RunApp()
        {
            while (true) // while app is running
            {
                ReadUserInput();

                int result = _model.Double(_userInput);

                string resultAsString = $"{result}";
                _view.ConsoleResult(resultAsString);
            }
        }

        private void ReadUserInput() // perhaps split
        {
            int userInput;

               try
               {
                    _view.GreetUser();
                    userInput = int.Parse(Console.ReadLine());
                    _userInput = userInput;                    
                }
                catch (Exception) // incorrect user input
                {
                    _view.InstructUser("Please enter an integer.");
                }
        }
    }
}
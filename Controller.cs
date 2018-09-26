using System;

namespace RegistryApp
{
    public class Controller
    {
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
                _view.GreetUser();

                try
                {
                    int userInput = GetUserInput();

                    int result = _model.Double(userInput);

                    string resultAsString = $"{result}";
                    _view.ConsoleResult(resultAsString);
                }
                catch (Exception)
                {
                    _view.InstructUser("Please enter an integer.");
                }
            }
        }

        private int GetUserInput() // should return, try null in catch
        {
            int userInput = int.Parse(Console.ReadLine());
            return userInput;                    
            
        }
    }
}
using System;

namespace RegistryApp
{
    class Program
    {
        static void Main()
        { 
            RunApp();
        }

        private static void RunApp()
        {
            view.IndexUI indexUI = new view.IndexUI();
            view.RegistryUI registryUI = new view.RegistryUI();
            model.RegistryModel registryModel = new model.RegistryModel();

            controller.Controller controller = new controller.Controller(
                    indexUI, registryUI, registryModel
                );

            indexUI.GreetUser();

            bool appRuns = true;

            while (appRuns)
            {
                try
                {
                    indexUI.AskForUserInput();
                    string[] userArguments = indexUI.GetUserArguments();
                    controller.ProcessUserInput(userArguments);
                    indexUI.DisplaySuccessMessage();
                }
                catch (Exception exception)
                {
                    indexUI.HandleException(exception);
                }
            }
        }
    }
}

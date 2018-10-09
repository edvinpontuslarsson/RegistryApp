using System;

namespace RegistryApp
{
    /// <summary>
    /// Starting point of the application
    /// </summary>
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
                    indexUI, registryUI,registryModel
                );

            bool appRuns = true;

            while (appRuns)
            {
                controller.Interact();
            }
        }
    }
}

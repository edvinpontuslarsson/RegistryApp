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
            indexUI.GreetUser();

            while (true) // while app is running
            {
                try
                {
                    indexUI.Interact();
                }
                catch (Exception exception)
                {
                    indexUI.HandleException(exception);
                }
            }
        }
    }
}

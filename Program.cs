using System;

namespace RegistryApp
{
    /// <summary>
    /// Starting point of the application
    /// </summary>
    class Program
    {
        private static view.IndexUI IndexUI { get; set; }

        static void Main()
        {            
            IndexUI = new view.IndexUI();
            RunApp();
        }

        private static void RunApp()
        {               
            IndexUI.GreetUser();

            while (true) // while app is running
            {
                try
                {
                    IndexUI.Interact();
                }
                catch (Exception exception)
                {
                    IndexUI.HandleException(exception);
                }
            }
        }
    }
}

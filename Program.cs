using System;

namespace RegistryApp
{
    /// <summary>
    /// Starting point of the application
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the application
        /// </summary>
        static void Main()
        {
            controller.Controller controller = 
                new controller.Controller();
            
            controller.RunApp();
        }
    }
}

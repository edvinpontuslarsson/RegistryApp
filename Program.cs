using System;

namespace RegistryApp
{
    /// <summary>
    /// Starting point of the application
    /// </summary>
    class Program
    {
        /// <summary>
        /// Runs the application
        /// </summary>
        static void Main() // perhaps remove args param here
        {
            controller.Controller controller = 
                new controller.Controller();
            
            controller.RunApp();
        }
    }
}

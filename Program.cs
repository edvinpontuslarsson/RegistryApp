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
        /// <param name="args">User input</param>
        static void Main(string[] args) // perhaps remove args param here
        {
            controller.Controller controller = 
                new controller.Controller();
            controller.StartApp();
        }
    }
}

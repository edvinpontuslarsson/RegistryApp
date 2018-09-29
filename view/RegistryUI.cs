using System;

namespace RegistryApp.view
{
    public class RegistryUI
    {
        private model.RegistryModel RegistryModel { get; set; }

        public RegistryUI()
        {
            RegistryModel = new model.RegistryModel();
        }

        public void AddMember()
        {
            Console.Write("  Name: ");
            string name = Console.ReadLine();

            Console.Write("  Personal number: ");
            string personalNumber = Console.ReadLine();

            RegistryModel.AddMember(name, personalNumber);
        }
    }
}
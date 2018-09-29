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
            Console.WriteLine("\n Member added succesfully!");
        }

        public void AddBoat(int memberID)
        {
            Console.Write("  Type: ");
            string type = Console.ReadLine();

            if (type != "Sailboat" || type != "Motorsailer" ||
                type != "kayak" || type != "Canoe")
            {
                type = "Other";
            }

            Console.Write("  Length: ");
            string length = Console.ReadLine();

            RegistryModel.AddBoat(memberID, type, length);
        }
    }
}
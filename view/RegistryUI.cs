using System;

namespace RegistryApp.view
{
    public class RegistryUI
    {
        private model.RegistryModel RegistryModel;

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
            string type = Console.ReadLine().ToLower();
            
            if (type != "sailboat" && type != "motorsailer" &&
                type != "kayak" && type != "canoe")
            {
                type = "other";
            }

            Console.Write("  Length: ");
            string length = Console.ReadLine();

            RegistryModel.AddBoat(memberID, type, length);
            Console.WriteLine("Boat added succesfully!");
        }

        public void EditMember(int memberID)
        {
            model.Member memberToEdit = 
                RegistryModel.GetMember(memberID);

            ConsoleGuidingInfo("Leave blank to leave unedited");
            
            Console.Write($"  Name ({memberToEdit.Name}): ");
            string nameInput = Console.ReadLine();
            string newName = nameInput != ""
                ? nameInput
                : memberToEdit.Name;

            Console.Write($"  Personal number ({memberToEdit.PersonalNumber}): ");
            string personalNrInput = Console.ReadLine();
            string newPersonalNr = personalNrInput != ""
                ? personalNrInput
                : memberToEdit.PersonalNumber;

            RegistryModel.EditMember(memberID, newName, newPersonalNr);
            Console.WriteLine("\n Member edited succesfully!");
        }

        private void ConsoleGuidingInfo(string info)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  {info}");
            Console.ResetColor();
        }

        public void ListAllMembers(bool verbose)
        {
            model.MemberList memberList = RegistryModel.GetExistingMemberList();

            foreach (model.Member member in memberList.Members)
            {
                string print = $"\nMember ID: {member.ID}\n" +
                $"Name: {member.Name}\n";

                if (verbose)
                {
                    print += $"Personal number: {member.PersonalNumber}\n";
                    
                    foreach (model.Boat boat in member.Boats)
                    {
                        print += $"\n{member.Name}'s Boat ID: {boat.ID}\n" +
                            $"Boat type: {boat.Type}\n" +
                            $"Boat length: {boat.Length}\n";
                    }
                }
                else
                {
                    print += $"Boat amount: {member.BoatAmount}\n";
                }

                Console.WriteLine(print);
            }
        }
    }
}
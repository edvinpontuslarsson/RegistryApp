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
            Console.WriteLine("\nMember added succesfully!");
        }

        public void AddBoat(int memberID)
        {
            Console.Write("  Type: ");
            string typeInput = Console.ReadLine().ToLower();
            
            string type = GetBoatType(typeInput);

            Console.Write("  Length: ");
            string length = Console.ReadLine();

            RegistryModel.AddBoat(memberID, type, length);
            Console.WriteLine("\nBoat added succesfully!");
        }

        public void EditBoat(int memberID, int boatId)
        {
            model.Member boatOwner = 
                RegistryModel.GetMember(memberID);
            model.Boat boatToEdit =
                RegistryModel.GetBoat(boatOwner, boatId);

            ConsoleGuidingInfo("Leave blank to leave unedited");

            Console.Write($"  Type ({boatToEdit.Type}): ");
            string typeInput = Console.ReadLine();
            string newTypeInput = typeInput != ""
                ? typeInput
                : boatToEdit.Type;
            string newType = GetBoatType(newTypeInput);

            Console.Write($"  Length ({boatToEdit.Length}): ");
            string lengthInput = Console.ReadLine();
            string newLength = lengthInput != ""
                ? lengthInput
                : boatToEdit.Length;
            
            RegistryModel.EditBoat(
                boatToEdit, newType, newLength
            );
            Console.WriteLine("\n Boat edited succesfully!");
        }

        public string GetBoatType(string typeInput)
        {
            if (typeInput != "sailboat" && typeInput != "motorsailer" &&
                typeInput != "kayak" && typeInput != "canoe")
            {
                typeInput = "other";
            }

            return typeInput;
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

            RegistryModel.EditMember(memberToEdit, newName, newPersonalNr);
            Console.WriteLine("\n Member edited succesfully!");
        }

        public void DeleteMember(int memberID)
        {
            RegistryModel.DeleteMember(memberID);
            Console.WriteLine("\n Member deleted succesfully!");
        }

        public void DeleteBoat(int memberID, int boatId)
        {
            RegistryModel.DeleteBoat(memberID, boatId);
            Console.WriteLine("\n Boat deleted succesfully!");
        }

        private void ConsoleGuidingInfo(string info)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  {info}");
            Console.ResetColor();
        }

        public void ListOneMember(int memberID)
        {
            model.Member member =
                RegistryModel.GetMember(memberID);
            
            string print = $"\nMember ID: {member.ID}\n" +
                $"Name: {member.Name}\n" +
                $"Personal number: {member.PersonalNumber}\n" +
                $"Boat amount: {member.BoatAmount}\n";

            foreach (model.Boat boat in member.Boats)
            {
                print += $"\nBoat ID: {boat.ID}\n" +
                    $"Boat type: {boat.Type}\n" +
                    $"Boat length: {boat.Length}\n";
            }

            Console.WriteLine(print);
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
                    print += $"Personal number: {member.PersonalNumber}\n" +
                        $"Boat amount: {member.BoatAmount}\n";
                    
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
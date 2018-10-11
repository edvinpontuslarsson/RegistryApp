using System;

namespace RegistryApp.view
{
    public class RegistryUI
    {
        public int GetMemberID(string[] userArguments) =>
            GetIDOf(userArguments, "member");
        
        public int GetBoatID(string[] userArguments) =>
            GetIDOf(userArguments, "boat");

        public string GetName()
        {
            Console.Write("  Name: ");
            string name = Console.ReadLine();
            return name;
        }

        public string GetPersonalNumber()
        {
            Console.Write("  Personal number: ");
            string personalNumber = Console.ReadLine();
            return personalNumber;
        }

        public string GetBoatType()
        {
            Console.Write("  Type: ");
            string boatType = Console.ReadLine().ToLower();
            return boatType;
        }

        public string GetBoatLength()
        {
            Console.Write("  Length: ");
            string length = Console.ReadLine();
            return length;
        }

        public string GetNewName(model.Member memberToEdit)
        {
            ConsoleGuidingInfo("Leave blank to leave unedited");
            
            Console.Write($"  Name ({memberToEdit.Name}): ");
            string nameInput = Console.ReadLine();
            string newName = nameInput != ""
                ? nameInput
                : memberToEdit.Name;                
            return newName;
        }

        public string GetNewPersonalNumber(model.Member memberToEdit)
        {
            Console.Write($"  Personal number ({memberToEdit.PersonalNumber}): ");
            string personalNrInput = Console.ReadLine();
            string newPersonalNr = personalNrInput != ""
                ? personalNrInput
                : memberToEdit.PersonalNumber;
            return newPersonalNr;
        }

        public string GetNewBoatType(model.Boat boatToEdit)
        {
            ConsoleGuidingInfo("Leave blank to leave unedited");

            Console.Write($"  Type ({boatToEdit.Type}): ");
            string typeInput = Console.ReadLine();
            string newType = typeInput != ""
                ? typeInput
                : boatToEdit.Type;

            return newType;
        }

        public string GetNewBoatLength(model.Boat boatToEdit)
        {
            Console.Write($"  Length ({boatToEdit.Length}): ");
            string lengthInput = Console.ReadLine();
            string newLength = lengthInput != ""
                ? lengthInput
                : boatToEdit.Length;
            return newLength;
        }

        public void ListAllMembers(model.MemberList memberList, bool verbose)
        {
            foreach (model.Member member in memberList.Members)
            {
                string print;

                if (verbose)
                {
                    print = GenerateVerbosePrint(member);
                }
                else
                {
                    print = $"\nMember ID: {member.ID}\n" +
                    $"Name: {member.Name}\n" +
                    $"Boat amount: {member.BoatAmount}\n";
                }

                Console.WriteLine(print);
            }
        }

        public void ListOneMember(model.Member member)
        {            
            string print = GenerateVerbosePrint(member);
            Console.WriteLine(print);
        }

        private string GenerateVerbosePrint(model.Member member)
        {
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
            return print;
        }

        private int GetIDOf(
            string[] userArguments, string target
        )
        {
            int targetIndex =
                Array.IndexOf(userArguments, target);
            int memberIDIndex = targetIndex + 1;
            int targetID = GetParsedIntOrException(
                userArguments[memberIDIndex]
            );
            return targetID;
        }

        private void ConsoleGuidingInfo(string info)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"  {info}");
            Console.ResetColor();
        }

        private int GetParsedIntOrException(string input)
        {
            int integer;

            bool canBeInt =
                Int32.TryParse(input, out integer);
            if (!canBeInt)
            {
                throw new FormatException();
            }
            return integer;
        }
    }
}
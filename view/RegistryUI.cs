using System;

namespace RegistryApp.view
{
    public class RegistryUI
    {
        private model.RegistryModel RegistryModel;

        private model.MemberList MemberList;

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

        public void ListAllMembers(bool verbose)
        {
            MemberList = RegistryModel.GetExistingMemberList();

            foreach (model.Member member in MemberList.Members)
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
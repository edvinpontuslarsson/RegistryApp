using System;

namespace RegistryApp.view
{
    public class UserCommands
    {
        public string[] Commands { get; private set; }

        public UserCommands()
        {
            Commands = new string[6];

            Commands[0] = "\nTo list commands, enter:\n" +
                "  list commands\n";
            
            Commands[1] = "To add member, enter:\n" +
                "  add member\n";

            Commands[2] = "To add boat to a member, enter:\n" +
                "  add boat to member [int memberID]\n";

            Commands[3] = "To display compact list of all members, enter:\n" + 
                "  list all members compact\n";

            Commands[4] = "To display verbose list of all members, enter:\n" + 
                "  list all members verbose\n";
            
            
            Commands[4] = "To edit a member, enter:\n" +
                "  edit member [int memberID]\n";
                
            Commands[5] = "To edit boat of a member, enter:\n" +
                "  edit boat [int boatID] of " + 
                "member [int memberID]\n";
        }
    }
}
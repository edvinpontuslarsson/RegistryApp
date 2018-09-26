using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RegistryApp.model
{
    public class Registry
    {
        private Member _member;

        private Boat[] _boats;

        public void AddMember(
            string name,
            string personalNr, 
            uint boatAmount = 0
        )
        {
            _member = 
                new Member(name, personalNr, boatAmount);
            StoreMember();
        }

        private void StoreMember()
        {

        }
    }
}
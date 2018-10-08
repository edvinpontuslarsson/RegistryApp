using System;
using System.Collections.Generic;

namespace RegistryApp.model
{
    public class MemberList
    {
        public List<Member> Members { get; set; }

        public MemberList()
        {
            Members = new List<Member>();
        }
    }
}
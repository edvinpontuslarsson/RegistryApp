using System;
using System.Collections.Generic;

namespace RegistryApp.model
{
    public class MemberList
    {
        public int MemberAmount { get; set; }

        public List<Member> Members { get; set; }

        public MemberList()
        {
            Members = new List<Member>();
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
            MemberAmount += 1;
        }
    }
}
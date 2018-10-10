using System;
using System.Collections.Generic;

namespace RegistryApp.model
{
    public class MemberList
    {
        private List<Member> _members;

        public List<Member> Members 
        {
             get => _members; 
             private set { _members = value; } 
        }

        public MemberList()
        {
            Members = new List<Member>();
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }
    }
}
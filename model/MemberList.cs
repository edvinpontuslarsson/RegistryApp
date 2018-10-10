using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RegistryApp.model
{
    [DataContract] // for XML-conversion
    public class MemberList
    {
        private List<Member> _members;

        [DataMember] // for XML-conversion
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
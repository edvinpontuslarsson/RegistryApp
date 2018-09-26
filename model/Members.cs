using System;

namespace RegistryApp.model
{
    public class Members
    {
        public Member[] _members;

        // perhaps no constructors in these
        public Members(Member[] members)
        {
            _members = members;
        }
    }
}
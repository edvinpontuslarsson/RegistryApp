using System;

namespace RegistryApp.view
{
    public class SuccessMessage
    {
        private string _memberAdded = "Member added succesfully!";
        private string _boatAdded = "Boat added succesfully!";
        private string _memberEdited = "Member edited succesfully!";
        private string _boatEdited = "Boat edited succesfully!";
        private string _memberDeleted = "Member deleted succesfully";
        private string _boatDeleted = "Boat deleted succesfully!";

        public string MemberAdded { get => _memberAdded; }
        public string BoatAdded { get => _boatAdded; }
        public string MemberEdited { get => _memberEdited; }
        public string BoatEdited { get => _boatEdited; }
        public string MemberDeleted { get => _memberDeleted; }
        public string BoatDeleted { get => _boatDeleted; }
    }
}
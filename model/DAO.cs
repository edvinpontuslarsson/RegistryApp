using System;
using System.IO;
using System.Xml.Serialization;

namespace RegistryApp.model
{
    /// <summary>
    /// Class for persistant storage,
    /// Data Access Object
    /// </summary>
    public class DAO
    {
        public bool RegistryExists() => 
            File.Exists(GetStorageDirectory());

        /// <summary>
        /// Inspired by a method described here:
        /// https://www.codeproject.com/Articles/483055/XML-Serialization-and-Deserialization-Part
        /// </summary>
        public void UpdateMemberListXmlFile(MemberList memberList)
        {
            string storageDirectory = GetStorageDirectory();

            XmlSerializer serializer = 
                new XmlSerializer(typeof(MemberList));

            using (TextWriter writer = new StreamWriter(storageDirectory))
            {
                serializer.Serialize(writer, memberList);
            }
        }
        
        private string GetStorageDirectory()
        {
            string projectDir = Directory.GetCurrentDirectory();
            string storageDirectory = 
                $"{projectDir}/storage/Registry.xml";
            return storageDirectory;
        }  
    }
}
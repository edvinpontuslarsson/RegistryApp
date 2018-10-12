using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace RegistryApp.model
{
    public class StorageModel
    {
        public bool RegistryExists() => File.Exists(GetStoragePath());

        public void UpdateXmlFile(MemberList memberList)
        {
            string storagePath = GetStoragePath();

            DataContractSerializer dataHandler =
                new DataContractSerializer(typeof(MemberList));

            // Inspired by documentation here:
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/how-to-serialize-using-datacontractserializer
            using(FileStream fileStream = 
                File.Open(storagePath, FileMode.Create))
            {
                dataHandler.WriteObject(fileStream, memberList);
            }          
        }

        public void DeleteXmlFile()
        {
            File.Delete(GetStoragePath());
        }

        /// <summary>
        /// Method inspired by a method described here:
        /// https://stackoverflow.com/questions/16943176/how-to-deserialize-xml-using-datacontractserializer
        /// </summary>
        public MemberList GetMemberList()
        {
            string storagePath = GetStoragePath();
            if (!RegistryExists()) {
                throw new ArgumentOutOfRangeException();
            }

            DataContractSerializer dataHandler =
                new DataContractSerializer(typeof(MemberList));

            FileStream fileStream = 
                new FileStream(storagePath, FileMode.Open);

            XmlDictionaryReader xmlReader =
                XmlDictionaryReader.CreateTextReader(
                    fileStream, new XmlDictionaryReaderQuotas()
                );

            MemberList memberList = 
                (MemberList)dataHandler.ReadObject(xmlReader);
            xmlReader.Close();
            fileStream.Close();

            return memberList;
        }

        private string GetStoragePath()
        {
            string projectDir = Directory.GetCurrentDirectory();
            string storagePath = 
                $"{projectDir}/Registry.xml";
            return storagePath;
        }  
    }
}
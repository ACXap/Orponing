using Orponing.Data;
using Orponing.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace Orponing
{
    public class SerializeXml : ISerializer
    {
        public Address Deserialize(string input)
        {
            using (XmlTextReader xmlr = new XmlTextReader(new StringReader(input)))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(AddresSingl));
                var obj = (AddresSingl)serializer.ReadObject(xmlr);
                Debug.WriteLine(obj);
            }

            return null;
        }

        public string DeserializeError(string input)
        {
            throw new NotImplementedException();
        }

        public List<Address> DeserializeGroopAddress(string input)
        {
            throw new NotImplementedException();
        }

        public Address DeserializeSinglAddress(string input)
        {
            throw new NotImplementedException();
        }

        public string SerializeGroopAddress(IEnumerable<string> address)
        {
            throw new NotImplementedException();
        }

        public string SerializeSinglAddress(string address)
        {
            return $"{START_XML_STRING}" +
                $"<AddressElementFullNameGroup><FullAddress>{address}</FullAddress></AddressElementFullNameGroup>" +
                $"{END_XML_STRING}";
        }

        private const string START_XML_STRING = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://www.informatica.com/dis/ws/ws_\"><soapenv:Header/><soapenv:Body><ws:AddressElementNameData><AddressElementFullNameList>";
        private const string END_XML_STRING = "</AddressElementFullNameList ></ws:AddressElementNameData></soapenv:Body></soapenv:Envelope>";
    }
}
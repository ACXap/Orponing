using Orponing.Data;
using Orponing.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;


namespace Orponing
{
    public class SerializeXml : ISerializer
    {
        #region PrivateField
        private const string START_XML_STRING = "<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:ws=\"http://www.informatica.com/dis/ws/ws_\"><soapenv:Header/><soapenv:Body><ws:AddressElementNameData><AddressElementFullNameList>";
        private const string END_XML_STRING = "</AddressElementFullNameList ></ws:AddressElementNameData></soapenv:Body></soapenv:Envelope>";

        private const string STRING_PREPARE_GROOP_ADDRESS = "AddressElementResponseList2";
        private const string STRING_PREPARE_SINGLE_ADDRESS = "AddressElementNameGroup2";
        #endregion PrivateField

        #region PrivateMethod
        private string PrepareAddress(string input, string stringPrepare)
        {
            var indexStart = input.IndexOf(stringPrepare);
            var indexStop = input.LastIndexOf(stringPrepare);
            return input.Substring(indexStart - 1, indexStop - indexStart + stringPrepare.Length + 2);
        }

        private T DeserializeAddress<T>(string input)
        {
            try
            {
                using (XmlTextReader xmlr = new XmlTextReader(new StringReader(input)))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(T));
                    var obj = (T)serializer.ReadObject(xmlr);
                    return obj;
                }
            }
            catch(Exception ex)
            {
                throw new FormatException($"Неверный формат данных: {ex.Message}");
            }           
        }
        #endregion PrivateMethod

        #region PublicMethod

        public List<Address> DeserializeGroopAddress(string input)
        {
            return DeserializeAddress<AddressList>(PrepareAddress(input, STRING_PREPARE_GROOP_ADDRESS));
        }

        public Address DeserializeSinglAddress(string input)
        {
            return DeserializeAddress<Address>(PrepareAddress(input, STRING_PREPARE_SINGLE_ADDRESS));
        }

        public string SerializeGroopAddress(IEnumerable<string> address)
        {
            var str = new StringBuilder();

            str.Append(START_XML_STRING);
            foreach(var item in address)
            {
                str.Append($"<AddressElementFullNameGroup><FullAddress>{item}</FullAddress></AddressElementFullNameGroup>");
            }
            str.Append(END_XML_STRING);

            return str.ToString();
        }

        public string SerializeSinglAddress(string address)
        {
            return $"{START_XML_STRING}" +
                $"<AddressElementFullNameGroup><FullAddress>{address}</FullAddress></AddressElementFullNameGroup>" +
                $"{END_XML_STRING}";
        }
        #endregion PublicMethod
    }
}
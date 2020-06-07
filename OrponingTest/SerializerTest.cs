using Orponing;
using Orponing.Model;
using System;
using System.Collections.Generic;

namespace OrponingTest
{
    public class SerializerTest : ISerializer
    {
        public List<Address> DeserializeGroopAddress(string input)
        {
            throw new NotImplementedException();
        }

        public Address DeserializeSinglAddress(string input)
        {
            return new Address() { GlobalID = "111111", LocationDescription= "Not Found" };
        }

        public string SerializeGroopAddress(IEnumerable<string> address)
        {
            throw new NotImplementedException();
        }

        public string SerializeSinglAddress(string address)
        {
            return address;
        }
    }
}
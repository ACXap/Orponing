using Orponing.Model;
using System.Collections.Generic;

namespace Orponing
{
    public interface ISerializer
    {
        Address DeserializeSinglAddress(string input);
        List<Address> DeserializeGroopAddress(string input);

        string SerializeSinglAddress(string address);
        string SerializeGroopAddress(IEnumerable<string> address);
    }
}
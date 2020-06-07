using Orponing.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Orponing.Data
{
    [CollectionDataContract(Name = "AddressElementResponseList2", Namespace = "")]
    internal class AddressList : List<Address> { }
}
using NUnit.Framework;
using Orponing;
using Orponing.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrponingTest.Test
{
    public class AddressTest
    {
        private IRepository _repository;
        private readonly ISerializer _serializer = new SerializeXml();
        private readonly string _path = TestContext.CurrentContext.TestDirectory;

        [Test]
        public void AddressHeaderFields_GoodAddress()
        {
            _repository = new FileRepository(Path.Combine(_path, "File", "inputSinglOk.txt"));

            var str = _repository.Request("Test");

            var address = _serializer.DeserializeSinglAddress(str);

            var h = address.HeaderFields(';');
            var v = address.ToString(';');

            var ht = "QualityCode;CheckStatus;UnparsedParts;ParsingLevelCode;SystemCode;GlobalID;KLADRLocalityId;FIASLocalityId;LocalityGlobalId;KLADRStreetId;FIASStreetId;StreetGlobalId;Street;StreetKind;House;HouseLitera;CornerHouse;BuildingBlock;BuildingBlockLitera;Building;BuildingLitera;Ownership;OwnershipLitera;FIASHouseId;HouseGlobalId;Latitude;Longitude;LocationDescription;";
            var vt = "UNDEF_05;VALIDATED;;FIAS_HOUSE;;111111;3900000100000;DF679694-D505-4DD3-B514-4BA48C8A97D8;5203149;39000001000103500;3F7B7D28-EBF9-4522-8DA3-5DE9D167F097;5775622;БЕРЕГОВАЯ (ПРИБРЕЖНЫЙ) ;УЛИЦА;2;;;;;;;;;30759E2D-42C5-46B9-8FC2-0FCC0C01E40F;70410863;54.651599;20.336232;;";

            Assert.AreEqual(ht, h);
            Assert.AreEqual(vt, v);
        }
    }
}
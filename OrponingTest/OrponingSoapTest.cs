using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Orponing;

namespace OrponingTest
{
    [TestFixture]
    public class OrponingSoapTest
    {
        private IOrponing _orponing;
        private IRepository _repository;
        private readonly ISerializer _serializer = new SerializeXml();
        private readonly string _path = TestContext.CurrentContext.TestDirectory;

        private readonly string _goodGlobalId = "111111";

        [Test]
        public void GetOrponByAddress_SinglGoodAddress()
        {
            _repository = new FileRepository(Path.Combine(_path, "File", "inputSinglOk.txt"));
            _orponing = new OrponingSoap(_repository, _serializer);

            var result = _orponing.GetOrponByAddress("Test");

            Assert.AreEqual(result.GlobalID, _goodGlobalId); 
        }
    }
}
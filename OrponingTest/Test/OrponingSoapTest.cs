using NUnit.Framework;
using Orponing;
using Orponing.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OrponingTest
{
    [TestFixture]
    public class OrponingSoapTest
    {
        private IOrponing _orponing;
        private IRepository _repository;
        private readonly ISerializer _serializer = new SerializeXml();
        private readonly string _path = TestContext.CurrentContext.TestDirectory;

        private readonly string _goodGlobalIdOne = "111111";
        private readonly string _goodGlobalIdTwo = "222222";

        [Test]
        public void GetOrponByAddress_SinglGoodAddress()
        {
            _repository = new FileRepository(Path.Combine(_path, "File", "inputSinglOk.txt"));
            _orponing = new OrponingSoap(_repository, _serializer);

            var result = _orponing.GetOrponByAddress("Test");

            Assert.AreEqual(result.GlobalID, _goodGlobalIdOne); 
        }

        [Test]
        public void GetOrponByAddress_GroopGoodAddress()
        {
            _repository = new FileRepository(Path.Combine(_path, "File", "inputGroopOk.txt"));
            _orponing = new OrponingSoap(_repository, _serializer);

            var result = _orponing.GetOrponByAddress(new List<string>() { "Test"});

            Assert.AreEqual(result.ElementAt(0).GlobalID, _goodGlobalIdOne);
            Assert.AreEqual(result.ElementAt(1).GlobalID, _goodGlobalIdTwo);
        }

        [Test]
        public void GetOrponByAddress_SinglGoodAddressHttpRepositoryTest()
        {
            _repository = new HttpRepository("https://postman-echo.com/post");
            _orponing = new OrponingSoap(_repository, new SerializerTest());

            var result = _orponing.GetOrponByAddress("Test");

            Assert.AreEqual(result.GlobalID, _goodGlobalIdOne);
            Assert.AreEqual(result.LocationDescription, "Not Found");
        }

        [Test]
        public void GetOrponByAddress_RepositoryErrorUrl()
        {
            _repository = new HttpRepository("google.ru");
            _orponing = new OrponingSoap(_repository, _serializer);

            Assert.Throws<RepositoryExeption>(() => _orponing.GetOrponByAddress("Test"));
        }

        [Test]
        public void GetOrponByAddress_RepositoryError()
        {
            _repository = new HttpRepository("https://google.ru");
            _orponing = new OrponingSoap(_repository, _serializer);

            Assert.Throws<RepositoryExeption>(() => _orponing.GetOrponByAddress("Test"));
        }
    }
}
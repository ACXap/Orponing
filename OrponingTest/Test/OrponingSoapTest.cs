using NUnit.Framework;
using Orponing;
using Orponing.Data;
using System.IO;

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

        [Test]
        public void GetOrponByAddress_SinglGoodAddressHttpRepositoryTest()
        {
            _repository = new HttpRepository("https://postman-echo.com/post");
            _orponing = new OrponingSoap(_repository, new SerializerTest());

            var result = _orponing.GetOrponByAddress("Test");

            Assert.AreEqual(result.GlobalID, _goodGlobalId);
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
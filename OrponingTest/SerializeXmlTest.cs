using NUnit.Framework;
using Orponing;
using System.IO;
using System.Reflection;

namespace OrponingTest
{
    [TestFixture]
    public class SerializeXmlTest
    {
        private IRepository _repository;
        private readonly ISerializer _serializer = new SerializeXml();
        private readonly string _path = TestContext.CurrentContext.TestDirectory;

        private readonly string _goodGlobalIdOne = "111111";
        private readonly string _goodGlobalIdTwo = "222222";

        [Test]
        public void DeserializeSinglAddress_GoodAddress()
        {
            _repository = new FileRepository(Path.Combine(_path, "File", "inputSinglOk.txt"));

            var str = _repository.Request("Test");

            var address = _serializer.DeserializeSinglAddress(str);

            Assert.AreEqual(address.GlobalID, _goodGlobalIdOne);
        }

        [Test]
        public void DeserializeGroopAddress_GoodAddress()
        {
            _repository = new FileRepository(Path.Combine(_path, "File", "inputGroopOk.txt"));

            var str = _repository.Request("Test");

            var address = _serializer.DeserializeGroopAddress(str);

            Assert.AreEqual(address[0].GlobalID, _goodGlobalIdOne);
            Assert.AreEqual(address[1].GlobalID, _goodGlobalIdTwo);
        }

        [Test]
        public void PrepareAddress_SinglGoodAddress()
        {
            _repository = new FileRepository(Path.Combine(_path, "File", "inputSinglOk.txt"));

            var str = _repository.Request("Test");

            var method = GetMethod("PrepareAddress");

            var s = RemoveChar(method.Invoke(_serializer, new object[] { str, "AddressElementNameGroup2" }).ToString());

            var r = RemoveChar(File.ReadAllText(Path.Combine(_path, "File", "inputSinglOkPrepare.txt")));

            Assert.AreEqual(s, r);
        }

        [Test]
        public void PrepareAddress_GroopGoodAddress()
        {
            _repository = new FileRepository(Path.Combine(_path, "File", "inputGroopOk.txt"));

            var str = _repository.Request("Test");

            var method = GetMethod("PrepareAddress");

            var s = RemoveChar(method.Invoke(_serializer, new object[] { str, "AddressElementResponseList2" }).ToString());

            var r = RemoveChar(File.ReadAllText(Path.Combine(_path, "File", "inputGroopOkPrepare.txt")));

            Assert.AreEqual(s, r);
        }

        private string RemoveChar(string input)
        {
            return input.Replace("\n", "").Replace("\r", "").Replace("\t", "");
        }

        private MethodInfo GetMethod(string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                Assert.Fail("methodName cannot be null or whitespace");

            var method = _serializer.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (method == null)
                Assert.Fail(string.Format("{0} method not found", methodName));

            return method;
        }
    }
}
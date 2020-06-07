using Orponing.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orponing
{
    public class OrponingSoap : IOrponing
    {
        public OrponingSoap(string serverUrl)
        {
            _repository = new HttpRepository(serverUrl);
        }

        public OrponingSoap(IRepository repository, ISerializer serializer)
        {
            _repository = repository;
            _serializer = serializer;
        }

        #region PrivateField
        private readonly IRepository _repository;
        private readonly ISerializer _serializer;
        #endregion PrivateField

        #region PublicProperties
        #endregion PublicProperties

        #region PrivateMethod
        #endregion PrivateMethod

        #region PublicMethod
        #endregion PublicMethod

        public Address GetOrponByAddress(string address)
        {
            var requestBody = _serializer.SerializeSinglAddress(address);
            var str = _repository.Request(requestBody);

            var orpon = _serializer.DeserializeSinglAddress(str);

            return orpon;
        }
    }
}
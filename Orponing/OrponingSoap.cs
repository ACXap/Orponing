using Orponing.Data;
using Orponing.Model;
using System;

namespace Orponing
{
    public class OrponingSoap : IOrponing
    {
        public OrponingSoap(string serverUrl)
        {
            _repository = new HttpRepository(serverUrl);
            _serializer = new SerializeXml();
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

        #region PublicMethod
        /// <summary>
        /// Метод получения адреса по текстовому представлению 
        /// </summary>
        /// <param name="address">Текстовое представление адреса</param>
        /// <returns>Адрес</returns>
        /// <exception cref="ArgumentException">Если строковое представление адреса пустое</exception>
        /// <exception cref="RepositoryExeption">Проблемы при обращении к орпонизатору</exception>
        /// <exception cref="FormatException">Проблемы при обработке данных от орпонизатора</exception>
        public Address GetOrponByAddress(string address)
        {
            if (string.IsNullOrEmpty(address)) throw new ArgumentException("Адрес не должен быть пустым", nameof(address));

            // Получаем xml-строку по адресу
            var requestBody = _serializer.SerializeSinglAddress(address);

            // Получаем ответ от орпонизатора
            var str = _repository.Request(requestBody);

            // Преобразуем ответ в объект Address
            var orpon = _serializer.DeserializeSinglAddress(str);
            
            return orpon;
        }

        public bool CheckService()
        {
            var address = GetOrponByAddress("Новосибирская обл., Новосибирск г., ул. Орджоникидзе, 18");

            return address.GlobalID == "111111";
        }
        #endregion PublicMethod
    }
}
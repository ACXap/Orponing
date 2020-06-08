using Orponing.Data;
using Orponing.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly string _goodIdTestOrponing = "29182486";
        private readonly string _testAddress = "Новосибирская обл., Новосибирск г., ул.Орджоникидзе, 18";
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

        /// <summary>
        /// Метод для получения коллекции объектов ОРПОН по списку адресов
        /// </summary>
        /// <param name="address">Коллекция адресов</param>
        /// <returns>Возвращает коллекцию объектов ОРПОН</returns>
        /// <exception cref="ArgumentException">Если коллекция адресов пустая</exception>
        /// <exception cref="RepositoryExeption">Проблемы при обращении к орпонизатору</exception>
        /// <exception cref="FormatException">Проблемы при обработке данных от орпонизатора</exception>
        public IEnumerable<Address> GetOrponByAddress(IEnumerable<string> address)
        {
            if (address==null || !address.Any()) throw new ArgumentException("Коллекция адресов не должна быть пустой", nameof(address));
            
            // Получаем xml-строку по списку адресов
            var requestBody = _serializer.SerializeGroopAddress(address);

            // Получаем ответ от орпонизатора
            var str = _repository.Request(requestBody);

            // Преобразуем ответ в коллекцию Address
            var collection = _serializer.DeserializeGroopAddress(str);

            return collection;
        }
       
        /// <summary>
        /// Метод для проверки работоспособности орпонизатора
        /// </summary>
        /// <returns>Возвращает истину, если сервис работоспособен</returns>
        public bool CheckService()
        {
            // Орпонизируем тестовый адрес
            var address = GetOrponByAddress(_testAddress);

            return address.GlobalID == _goodIdTestOrponing;
        }
        #endregion PublicMethod
    }
}
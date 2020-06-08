using Orponing.Model;
using System.Collections.Generic;

namespace Orponing
{
    /// <summary>
    /// Интерфейс описывающий работу орпонизатора
    /// </summary>
    public interface IOrponing
    {
        /// <summary>
        /// Метод для получения объекта ОРПОН по заданному адресу
        /// </summary>
        /// <param name="address">Адрес объекта</param>
        /// <returns>Возвращает объект ОРПОН</returns>
        Address GetOrponByAddress(string address);

        /// <summary>
        /// Метод для получения коллекции объектов ОРПОН по списку адресов
        /// </summary>
        /// <param name="address">Коллекция адресов</param>
        /// <returns>Возвращает коллекцию объектов ОРПОН</returns>
        IEnumerable<Address> GetOrponByAddress(IEnumerable<string> address);

        /// <summary>
        /// Метод для проверки работоспособности орпонизатора
        /// </summary>
        /// <returns>Возвращает истину, если сервис работоспособен</returns>
        bool CheckService();
    }
}
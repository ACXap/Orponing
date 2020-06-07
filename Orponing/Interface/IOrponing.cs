﻿using Orponing.Model;

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
    }
}
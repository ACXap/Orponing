namespace Orponing.Model
{
    /// <summary>
    /// Класс для описания свойств ответа орпонизатора
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Ошибка при орпонизации
        /// </summary>
        public string Error { get; set; }
        public string QualityCode { get; set; }
        public string CheckStatus { get; set; }
        public string UnparsedParts { get; set; }
        /// <summary>
        /// Уровень адреса по ФИАС
        /// </summary>
        public string ParsingLevelCode { get; set; }
        /// <summary>
        /// Идентификатор адреса при передаче групповых запросов
        /// </summary>
        public string SystemCode { get; set; }
        /// <summary>
        /// ГИД полученого адреса при орпонизации
        /// </summary>
        public string GlobalID { get; set; }
        public string KLADRLocalityId { get; set; }
        public string FIASLocalityId { get; set; }
        public string LocalityGlobalId { get; set; }
        public string KLADRStreetId { get; set; }
        public string FIASStreetId { get; set; }
        public string StreetGlobalId { get; set; }
        public string Street { get; set; }
        public string StreetKind { get; set; }
        public string House { get; set; }
        public string HouseLitera { get; set; }
        public string CornerHouse { get; set; }
        public string BuildingBlock { get; set; }
        public string BuildingBlockLitera { get; set; }
        public string Building { get; set; }
        public string BuildingLitera { get; set; }
        public string Ownership { get; set; }
        public string OwnershipLitera { get; set; }
        public string FIASHouseId { get; set; }
        public string HouseGlobalId { get; set; }
        /// <summary>
        /// Широта
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// Долгота
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// Описание местоположения адреса (если заполнено поле в базе Описание местоположения)
        /// </summary>
        public string LocationDescription { get; set; }
    }
}
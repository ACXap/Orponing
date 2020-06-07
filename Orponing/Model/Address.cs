using System.Runtime.Serialization;

namespace Orponing.Model
{
    /// <summary>
    /// Класс для описания свойств адреса
    /// </summary>
    [DataContract(Name = "AddressElementNameGroup2", Namespace = "")]
    public class Address
    {
        [DataMember(Name = "QualityCode", Order = 1)]
        public string QualityCode { get; set; }
        [DataMember(Name = "CheckStatus", Order = 2)]
        public string CheckStatus { get; set; }
        /// <summary>
        /// Нераспознанные части адреса
        /// </summary>
        [DataMember(Name = "UnparsedParts", Order = 3)]
        public string UnparsedParts { get; set; }
        /// <summary>
        /// Уровень по ФИАС
        /// </summary>
        [DataMember(Name = "ParsingLevelCode", Order = 4)]
        public string ParsingLevelCode { get; set; }
        /// <summary>
        /// Идентификатор адреса для групповых запросов
        /// </summary>
        [DataMember(Name = "SystemCode", Order = 5)]
        public string SystemCode { get; set; }
        /// <summary>
        /// Глобальный идентификатор адреса
        /// </summary>
        [DataMember(Name = "GlobalID", Order = 6)]
        public string GlobalID { get; set; }
        [DataMember(Name = "KLADRLocalityId", Order = 7)]
        public string KLADRLocalityId { get; set; }
        [DataMember(Name = "FIASLocalityId", Order = 8)]
        public string FIASLocalityId { get; set; }
        [DataMember(Name = "LocalityGlobalId", Order = 9)]
        public string LocalityGlobalId { get; set; }
        [DataMember(Name = "KLADRStreetId", Order = 10)]
        public string KLADRStreetId { get; set; }
        [DataMember(Name = "FIASStreetId", Order = 11)]
        public string FIASStreetId { get; set; }
        [DataMember(Name = "StreetGlobalId", Order = 12)]
        public string StreetGlobalId { get; set; }
        [DataMember(Name = "Street", Order = 13)]
        public string Street { get; set; }
        [DataMember(Name = "StreetKind", Order = 14)]
        public string StreetKind { get; set; }
        [DataMember(Name = "House", Order = 15)]
        public string House { get; set; }
        [DataMember(Name = "HouseLitera", Order = 16)]
        public string HouseLitera { get; set; }
        [DataMember(Name = "CornerHouse", Order = 17)]
        public string CornerHouse { get; set; }
        [DataMember(Name = "BuildingBlock", Order = 18)]
        public string BuildingBlock { get; set; }
        [DataMember(Name = "BuildingBlockLitera", Order = 19)]
        public string BuildingBlockLitera { get; set; }
        [DataMember(Name = "Building", Order = 20)]
        public string Building { get; set; }
        [DataMember(Name = "BuildingLitera", Order = 21)]
        public string BuildingLitera { get; set; }
        [DataMember(Name = "Ownership", Order = 22)]
        public string Ownership { get; set; }
        [DataMember(Name = "OwnershipLitera", Order = 23)]
        public string OwnershipLitera { get; set; }
        [DataMember(Name = "FIASHouseId", Order = 24)]
        public string FIASHouseId { get; set; }
        [DataMember(Name = "HouseGlobalId", Order = 25)]
        public string HouseGlobalId { get; set; }
        /// <summary>
        /// Широта
        /// </summary>
        [DataMember(Name = "Latitude", Order = 26)]
        public string Latitude { get; set; }
        /// <summary>
        /// Долгота
        /// </summary>
        [DataMember(Name = "Longitude", Order = 27)]
        public string Longitude { get; set; }
        /// <summary>
        /// Описание местоположения
        /// </summary>
        [DataMember(Name = "LocationDescription", Order = 28)]
        public string LocationDescription { get; set; }
    }
}
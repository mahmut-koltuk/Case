using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace Case.Core.Model
{
    public class Place
    {
        #region Properties

        [XmlElement("ID")]
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [XmlElement("SeyahatSehirID")]
        [JsonPropertyName("CityId")]
        public int CityId { get; set; }

        [XmlElement("Bolge")]
        [JsonPropertyName("Area")]
        public string Area { get; set; }

        [XmlElement("Ad")]
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [XmlElement("Aciklama")]
        [JsonPropertyName("Description")]
        public string Description { get; set; }

        [XmlElement("MerkezMi")]
        [JsonPropertyName("IsCenter")]
        public bool IsCenter { get; set; }

        [XmlElement("BagliOlduguNoktaID")]
        [JsonPropertyName("DependentCityId")]
        public int DependentCityId { get; set; }

        #endregion
    }
}

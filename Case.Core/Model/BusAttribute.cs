using System.Xml.Serialization;

namespace Case.Core.Model
{
    public class BusAttribute
    {
        #region Properties

        [XmlElement("O_Tip_Ozellik")]
        public int Index { get; set; }

        [XmlElement("O_Tip_Ozellik_Aciklama")]
        public string Description { get; set; }

        [XmlElement("O_Tip_Ozellik_Detay")]
        public string Details { get; set; }

        [XmlElement("O_Tip_Ozellik_Icon")]
        public string Icon { get; set; }

        #endregion
    }
}

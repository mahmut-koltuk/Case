using System.Xml.Serialization;

namespace Case.Core.Model
{
    public class Firm
    {
        #region Properties

        [XmlElement("Firma_No")]
        public int Id { get; set; }

        [XmlElement("Firmaadi")]
        public string Name { get; set; }

        [XmlElement("FirmaLogo")]
        public string Logo { get; set; }

        [XmlElement("BosSubeKodu")]
        public string EmptyBranchCode { get; set; }

        [XmlElement("BosKullaniciKodu")]
        public string EmptyUserCode { get; set; }

        [XmlElement("Bilet_Seri_No_Takip")]
        public string TicketSerialTracking { get; set; }

        [XmlElement("Bilet_Seri_No")]
        public string TicketSerial { get; set; }

        [XmlElement("WebAdresi")]
        public string WebAddress { get; set; }

        [XmlElement("Telefon")]
        public string Phone { get; set; }

        [XmlElement("Sat_Koltuk_Adet")]
        public int SaleSeatCount { get; set; }

        [XmlElement("Rez_Koltuk_Adet")]
        public int ReservationSeatCount { get; set; }

        [XmlElement("FirmaNoStr")]
        public string FirmIdString { get; set; }

        [XmlElement("FirmaOtobusteMaxAyniUyeKartliIslemSayisi")]
        public int MaximumMemberCardProcessCount { get; set; }

        [XmlElement("FirmaCokluCinsiyetIslemYapabilir")]
        public bool MultipleGenderProcessAvailable { get; set; }

        [XmlElement("SefereKadarIptalEdilebilmeSuresiDakika")]
        public int CancellationMinutes { get; set; }

        [XmlElement("BiletIptalAktifMi")]
        public bool IsCancellationActive { get; set; }

        [XmlElement("AcikParaKullanimAktifMi")]
        public bool IsOpenMoneyUsageActive { get; set; }

        #endregion
    }
}

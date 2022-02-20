using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Case.Core.Model
{
    public class Trip
    {
        #region Properties

        [XmlElement("ID")]
        public int Id { get; set; }

        [XmlElement("Vakit")]
        public string Time { get; set; }

        [XmlElement("FirmaNo")]
        public int FirmId { get; set; }

        [XmlElement("FirmaAdi")]
        public string FirmName { get; set; }

        [XmlElement("YerelSaat")]
        public DateTime LocalTime { get; set; }

        [XmlElement("YerelInternetSaat")]
        public DateTime LocalInternetTime { get; set; }

        [XmlElement("Tarih")]
        public DateTime TripDate { get; set; }

        [XmlElement("GunBitimi")]
        public string DayEnd { get; set; }

        [XmlElement("Saat")]
        public DateTime TripTime { get; set; }

        [XmlElement("HatNo")]
        public string LineNumber { get; set; }

        [XmlElement("IlkKalkisYeri")]
        public string FirstDeparture { get; set; }

        [XmlElement("SonVarisYeri")]
        public string LastArrival { get; set; }

        [XmlElement("KalkisYeri")]
        public string Departure { get; set; }

        [XmlElement("VarisYeri")]
        public string Arrival { get; set; }

        [XmlElement("IlkKalkisNoktaID")]
        public int FirstDeparturePlaceId { get; set; }

        [XmlElement("IlkKalkisNokta")]
        public string FirstDeparturePlaceName { get; set; }

        [XmlElement("KalkisNoktaID")]
        public int DeparturePlaceId { get; set; }

        [XmlElement("KalkisNokta")]
        public string DeparturePlaceName { get; set; }

        [XmlElement("VarisNoktaID")]
        public int ArrivalPlaceId { get; set; }

        [XmlElement("VarisNokta")]
        public string ArrivalPlaceName { get; set; }

        [XmlElement("SonVarisNoktaID")]
        public int LastArrivalPlaceId { get; set; }

        [XmlElement("SonVarisNokta")]
        public string LastArrivalPlaceName { get; set; }

        [XmlElement("OtobusTipi")]
        public string BusType { get; set; }

        [XmlElement("OtobusKoltukYerlesimTipi")]
        public string BusSeatPlacementType { get; set; }

        [XmlElement("OTipAciklamasi")]
        public string BusTypeDescription { get; set; }

        [XmlElement("OtobusTelefonu")]
        public string BusPhone { get; set; }

        [XmlElement("OtobusPlaka")]
        public string BusLicensePlate { get; set; }

        [XmlElement("SeyahatSuresi")]
        public DateTime TripDuration { get; set; }

        [XmlElement("SeyahatSuresiGosterimTipi")]
        public string TripDurationViewType { get; set; }

        [XmlElement("YaklasikSeyahatSuresi")]
        public string ApproximateTripDuration { get; set; }

        [XmlElement("BiletFiyati1")]
        public decimal TicketPrice { get; set; }

        [XmlElement("BiletFiyatiInternet")]
        public decimal InternetTicketPrice { get; set; }

        [XmlElement("Sinif_Farki")]
        public string ClassDifference { get; set; }

        [XmlElement("MaxRzvZamani")]
        public string MaximumReservationTime { get; set; }

        [XmlElement("SeferTipi")]
        public string TripType { get; set; }

        [XmlElement("SeferTipiAciklamasi")]
        public string TripTypeDescription { get; set; }

        [XmlElement("HatSeferNo")]
        public string LineTripNumber { get; set; }

        [XmlElement("O_Tip_Sinif")]
        public string BusAttributeClass { get; set; }

        [XmlElement("SeferTakipNo")]
        public string TripTrackingNumber { get; set; }

        [XmlElement("ToplamSatisAdedi")]
        public int TotalSaleCount { get; set; }

        [XmlElement("DolulukKuraliVar")]
        public bool FullnessRuleExists { get; set; }

        [XmlElement("OTipOzellik")]
        public string BusAttributeInfo { get; set; }

        [XmlElement("NormalBiletFiyati")]
        public decimal NormalTicketPrice { get; set; }

        [XmlElement("DoluSeferMi")]
        public bool IsFullTrip { get; set; }

        [XmlElement("Tesisler")]
        public string Facilities { get; set; }

        [XmlElement("SeferBosKoltukSayisi")]
        public int TripEmptySeatCount { get; set; }

        [XmlElement("KalkisTerminalAdi")]
        public string DepartureTerminal { get; set; }

        [XmlElement("KalkisTerminalAdiSaatleri")]
        public string DepartureTerminalTime { get; set; }

        [XmlElement("MaximumRezerveTarihiSaati")]
        public DateTime MaximumReservationDateTime { get; set; }

        [XmlElement("Guzergah")]
        public string Route { get; set; }

        [XmlElement("KKZorunluMu")]
        public bool IsCreditCardMandatory { get; set; }

        [XmlElement("BiletIptalAktifMi")]
        public bool IsCancellationActive { get; set; }

        [XmlElement("AcikParaKullanimAktifMi")]
        public bool IsOpenMoneyUsageActive { get; set; }

        [XmlElement("SefereKadarIptalEdilebilmeSuresiDakika")]
        public int CancellationMinutes { get; set; }

        [XmlElement("FirmaSeferAciklamasi")]
        public string FirmTripDescription { get; set; }

        [XmlElement("SatisYonlendirilecekMi")]
        public bool SaleWillBeRedirected { get; set; }

        public List<BusAttribute> BusAttributes { get; set; }

        #endregion

        #region Methods

        #region Constructors

        public Trip()
        {
            BusAttributes = new List<BusAttribute>();
        }

        #endregion

        #endregion
    }
}

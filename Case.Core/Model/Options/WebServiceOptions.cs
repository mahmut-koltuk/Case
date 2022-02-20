using System;
using System.Xml;
using System.Xml.Linq;

namespace Case.Core.Model.Options
{
    public class WebServiceOptions
    {
        #region Constants

        private const int DEFAULT_PLACES_REFRESH_PERIOD = 60;
        private const string ROOT_ELEMENT_NAME = "Kullanici";
        private const string USERNAME_ELEMENT_NAME = "Adi";
        private const string PASSWORD_ELEMENT_NAME = "Sifre";

        #endregion

        #region Properties

        public string Username { get; set; }
        public string Password { get; set; }
        public int PlacesRefreshPeriod { get; set; }
        public XmlElement AuthenticationElement => GetAuthenticationElement();

        #endregion

        #region Methods

        #region Constructors

        public WebServiceOptions()
        {
            Username = String.Empty;
            Password = String.Empty;
            PlacesRefreshPeriod = DEFAULT_PLACES_REFRESH_PERIOD;
        }

        #endregion


        private XmlElement GetAuthenticationElement()
        {
            XElement element = new XElement(ROOT_ELEMENT_NAME,
                new XElement(USERNAME_ELEMENT_NAME, Username),
                new XElement(PASSWORD_ELEMENT_NAME, Password));

            XmlDocument doc = new XmlDocument();

            doc.Load(element.CreateReader());
            return doc.DocumentElement;
        }

        #endregion
    }
}

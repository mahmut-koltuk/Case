using System.Xml;
using System.Xml.Linq;

namespace Case.Core.Model.Query
{
    public class PlaceQuery : QueryBase
    {
        #region Constants

        private const string ROOT_ELEMENT_NAME = "KaraNoktaGetirKomut";

        #endregion

        #region Methods

        #region QueryBase Implementation

        protected override XmlElement GetQueryElement()
        {
            XElement commandElement = new XElement(ROOT_ELEMENT_NAME);
            XmlDocument doc = new XmlDocument();

            doc.Load(commandElement.CreateReader());
            return doc.DocumentElement;
        }

        #endregion

        #endregion
    }
}

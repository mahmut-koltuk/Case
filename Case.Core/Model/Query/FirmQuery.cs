using System.Xml;
using System.Xml.Linq;

namespace Case.Core.Model.Query
{
    public class FirmQuery : QueryBase
    {
        #region Constants

        private const string ROOT_ELEMENT_NAME = "Firmalar";
        
        #endregion

        #region Methods

        #region QueryBase Implementation

        protected override XmlElement GetQueryElement()
        {
            XElement element = new XElement(ROOT_ELEMENT_NAME);
            XmlDocument doc = new XmlDocument();

            doc.Load(element.CreateReader());
            return doc.DocumentElement;
        }

        #endregion

        #endregion
    }
}

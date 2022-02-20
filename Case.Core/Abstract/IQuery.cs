using System.Xml;

namespace Case.Core.Abstract
{
    public interface IQuery
    {
        #region Properties

        public XmlElement QueryElement { get; }

        #endregion
    }
}

using Case.Core.Abstract;
using System.Xml;

namespace Case.Core.Model.Query
{
    public abstract class QueryBase : IQuery
    {
        #region Properties

        public XmlElement QueryElement => GetQueryElement();

        #endregion

        #region Methods

        protected abstract XmlElement GetQueryElement();

        #endregion
    }
}

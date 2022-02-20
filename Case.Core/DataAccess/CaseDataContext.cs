using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Case.Core.DataAccess
{
    internal class CaseDataContext : DbContext
    {
        #region Properties



        #endregion

        #region Methods

        #region Constructors

        public CaseDataContext()
        {
        }

        public CaseDataContext(DbContextOptions<CaseDataContext> options) 
            : base(options)
        {
        }

        #endregion

        #endregion
    }
}

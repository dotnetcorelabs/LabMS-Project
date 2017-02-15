using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Context.Interfaces
{
    public interface IDatabaseProvider
    {
        DbConnection CreateDbConnection();
    }
}

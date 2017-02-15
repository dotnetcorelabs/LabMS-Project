﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreLabs.LabMS.Context.Interfaces
{
    public interface IDataContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}

using System;
using System.Data;

namespace DotNetCoreLabs.LabMS.Context.Interfaces
{
    public interface IDataContext : IDisposable
    {
        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }

        void Commit();

        void Rollback();
    }
}

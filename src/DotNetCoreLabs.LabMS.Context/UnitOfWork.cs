using DotNetCoreLabs.LabMS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using DotNetCoreLabs.LabMS.Context.Interfaces;

namespace DotNetCoreLabs.LabMS.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDataContext _context;
        public IDbTransaction Transaction { get; private set; }

        public UnitOfWork(IDataContext context)
        {
            _context = context;
        }

        public IDbTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Snapshot)
        {
            if (Transaction == null)
            {
                Transaction = _context.Connection.BeginTransaction(isolationLevel);
            }

            return Transaction;
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Transaction = null;
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
            }
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}

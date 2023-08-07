﻿using RestFulAPI_Legasuite.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestFulAPI_Legasuite.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IDatabaseContextFactory _factory;
        private IDatabaseContext _context;
        public OdbcTransaction Transaction { get; private set; }

        public UnitOfWork(IDatabaseContextFactory factory)
        {
            _factory = factory;
        }

        public void Commit()
        {
            if (Transaction == null)
            {
                throw new NullReferenceException("Tried to commit but the transaction is not opened");
            }

            try
            {
                Transaction.Commit();
            }
            catch (Exception)
            {
                Transaction.Rollback();
            }

            Transaction.Dispose();
            Transaction = null;
        }

        public IDatabaseContext DataContext
        {
            get
            {
                if (_context == null)
                {
                    _context = _factory.Context();
                }
                return _context;
            }
        }

        public OdbcTransaction BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new NullReferenceException("Previous transaction is not completed.");
            }
            Transaction = _context.Connection.BeginTransaction();
            return Transaction;
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            _context?.Dispose();
        }
    }
}

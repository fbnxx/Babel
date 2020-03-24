using Babel.Data.Context;
using Babel.Data.Interfaces;
using Babel.Data.Repository;
using Babel.Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Babel.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private BabelDbContext babelDbContext;

        private Repository<Book> bookRepository;

        public UnitOfWork(BabelDbContext babelDbContext)
        {
            this.babelDbContext = babelDbContext;
        }

        public Repository<Book> BookRepository
        {
            get 
            {
                if (bookRepository == null)
                {
                    bookRepository = new Repository<Book>(babelDbContext);
                }
                return bookRepository;
            }
        }

        public async Task SaveAsync()
        {
            await babelDbContext.SaveChangesAsync();
        }
    }
}

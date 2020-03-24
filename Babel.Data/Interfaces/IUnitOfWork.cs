using Babel.Data.Repository;
using Babel.Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Babel.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveAsync();

        Repository<Book> BookRepository { get; }
    }
}

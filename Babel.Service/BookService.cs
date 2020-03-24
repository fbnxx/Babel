using Babel.Service.Entities;
using Babel.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Babel.Service
{
    public class BookService : IBookService
    {
        public async Task Create(BookDto newBook)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<BookDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<BookDto> GetFirst()
        {
            throw new NotImplementedException();
        }

        public async Task<BookDto> GetLast()
        {
            throw new NotImplementedException();
        }
    }


}

using Babel.Service.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Babel.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAll();
        Task<BookDto> GetById(int id);
        Task<BookDto> GetFirst();
        Task<BookDto> GetLast();
        Task Create(BookDto newBook);
        Task Update(BookDto newBook);
        Task Delete(int id);
    }
}

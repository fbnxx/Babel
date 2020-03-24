using Babel.Data.Interfaces;
using Babel.Domain.Business;
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
        private readonly IUnitOfWork unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task Create(BookDto newBook)
        {
            var book = new Book()
            {
                NoVolumen = newBook.NoVolumen,
                Descripcion = newBook.Descripcion
            };

            await unitOfWork.BookRepository.CreateAsync(book);
            await unitOfWork.SaveAsync();
        }

        public async Task Update(BookDto newBook)
        {
            var book = new Book()
            {
                Id = newBook.Id,
                NoVolumen = newBook.NoVolumen,
                Descripcion = newBook.Descripcion
            };

            await unitOfWork.BookRepository.UpdateAsync(book);
            await unitOfWork.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await unitOfWork.BookRepository.DeleteAsync(id);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<BookDto>> GetAll()
        {
            var list = await unitOfWork.BookRepository.GetAsync(null);
            var books = new List<BookDto>();
            foreach (var bookDb in list)
            {
                books.Add(
                     new BookDto()
                     {
                         Id = bookDb.Id,
                         Descripcion = bookDb.Descripcion,
                         NoVolumen = bookDb.NoVolumen
                     }
                    );
            }

            return books;
        }

        public async Task<BookDto> GetById(int id)
        {
            var bookDb = await unitOfWork.BookRepository.GetByIdAsync(id);
            var book = new BookDto()
            {
                Id = bookDb.Id,
                Descripcion = bookDb.Descripcion,
                NoVolumen = bookDb.NoVolumen
            };

            return book;
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

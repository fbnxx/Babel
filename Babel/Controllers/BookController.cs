using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Babel.Service.Entities;
using Babel.Service.Interfaces;
using Babel.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Babel.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost]
        public async Task<IEnumerable<BookDto>> Create([FromBody]CreateBookRequest newBook)
        {
            var book = new BookDto()
            {
                NoVolumen = newBook.NoVolumen,
                Descripcion = newBook.Descripcion
            };

            await bookService.Create(book);

            var result = new List<BookDto>();
            result.Add(book);

            return result;
        }

        [HttpPut]
        public async Task<IEnumerable<BookDto>> Update([FromBody]CreateBookRequest updateBook)
        {
            var book = new BookDto()
            {
                Id = updateBook.Id,
                NoVolumen = updateBook.NoVolumen,
                Descripcion = updateBook.Descripcion
            };

            await bookService.Update(book);

            var result = new List<BookDto>();
            result.Add(book);

            return result;
        }

        [HttpDelete]
        public async Task<IEnumerable<BookDto>> Delete(int id)
        {
            await bookService.Delete(id);

            var result = new List<BookDto>();
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            return await bookService.GetAll();
        }

        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetById(int id)
        {
            var book = await bookService.GetById(id);
            var result = new List<BookDto>();
            result.Add(book);

            return result;
        }
    }
}
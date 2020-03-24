using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Babel.Service.Entities;
using Babel.Web.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Babel.Web.Controllers
{
    public class BookController : Controller
    {
        private List<BookDto> books;

        public BookController()
        {
            books = new List<BookDto>();

            books.Add(new BookDto() { Id = 1, NoVolumen = "Volumen 1", Descripcion = "Libro A" });
            books.Add(new BookDto() { Id = 2, NoVolumen = "Volumen 2", Descripcion = "Libro B" });
            books.Add(new BookDto() { Id = 3, NoVolumen = "Volumen 3", Descripcion = "Libro C" });
        }

        [HttpPost]
        public IEnumerable<BookDto> Create([FromBody]CreateBookRequest newBook)
        {
            var book = new BookDto()
            {
                NoVolumen = newBook.NoVolumen,
                Descripcion = newBook.Descripcion
            };

            books.Add(book);

            return books;
        }

        [HttpPut]
        public IEnumerable<BookDto> Update([FromBody]CreateBookRequest updatedBook)
        {
            books.Find(e => e.Id == updatedBook.Id).NoVolumen = updatedBook.NoVolumen;
            books.Find(e => e.Id == updatedBook.Id).Descripcion = updatedBook.Descripcion;

            return books;
        }

        [HttpDelete]
        public IEnumerable<BookDto> Delete(int id)
        {
            //  happy path, not handling errors
            var book = books.Find(e => e.Id == id);
            books.Remove(book);
            
            return books;
        }

        [HttpGet]
        public IEnumerable<BookDto> GetAll()
        {

            return books;
        }

        [HttpGet]
        public IEnumerable<BookDto> GetById(int id)
        {
            //  happy path, not handling errors
            var book = books.Find(e => e.Id == id);
            var result = new List<BookDto>();
            result.Add(book);

            return result;
        }
    }
}
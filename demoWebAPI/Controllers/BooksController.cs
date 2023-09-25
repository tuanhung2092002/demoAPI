using demoWebAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoWebAPI.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private List<Book> _books = new List<Book>
    {
        new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
        new Book { Id = 2, Title = "Book 2", Author = "Author 2" },
        new Book { Id = 3, Title = "Book 3", Author = "Author 3" },
        new Book { Id = 4, Title = "Book 4", Author = "Author 4" },
        new Book { Id = 5, Title = "Book 5", Author = "Author 5" },
    };

        // GET /api/books
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_books);
        }
        

        // GET /api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST /api/books
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        // PUT /api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;

            return NoContent();
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _books.FirstOrDefault(b => b.Id == id);
            if (existingBook == null)
            {
                return NotFound();
            }

            _books.Remove(existingBook);
            return NoContent();
        }
    }
}
    

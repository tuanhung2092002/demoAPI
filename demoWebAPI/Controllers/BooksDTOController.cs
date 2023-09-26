using AutoMapper;
using demoWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksDTOController : ControllerBase
    {
        private List<Book> _books = new List<Book>
        {
        new Book { Id = 1, Title = "Book 1", Author = "Author 1" },
        new Book { Id = 2, Title = "Book 2", Author = "Author 2" },
        new Book { Id = 3, Title = "Book 3", Author = "Author 3" },
        new Book { Id = 4, Title = "Book 4", Author = "Author 4" },
        new Book { Id = 5, Title = "Book 5", Author = "Author 5" },
        };

        private readonly IMapper _mapper;
        public BooksDTOController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<List<Book>> GetAllBook()
        {
            return Ok(_books.Select(b => _mapper.Map<BookDTO>(b)));
        }
        [HttpPost]
        public ActionResult<List<Book>> CreateBook(BookDTO newbook) 
        {
            var book = _mapper.Map<Book>(newbook);
            _books.Add(book);

            return Ok(_books.Select(b => _mapper.Map<BookDTO>(b)));
        }
    }
}

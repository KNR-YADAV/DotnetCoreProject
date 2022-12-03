using BookStore.Api.Models;
using BookStore.Api.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookrepositry;

        public BookController(IBookRepository bookrepositry)
        {
            _bookrepositry = bookrepositry;
        }
        [HttpGet("")]
        public async Task<IActionResult> getAllBooks()
        {
            var books = await _bookrepositry.GetAllBooksAsync();
            return Ok(books);   
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> geBookById( int id)
        {
            var book = await _bookrepositry.GetBookByIdAsync(id);
            return Ok(book);
        }
        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookmodel)
        {
            var Id = await _bookrepositry.AddBookAsync(bookmodel);
            return CreatedAtAction(nameof(geBookById), new { id = Id, controller = "book" }, Id);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] BookModel bookmodel)
        {
             await _bookrepositry.UpdateBookAsync(id,bookmodel);
            return Ok();
        }
        [HttpPatch("{Id}")]
        public async Task<IActionResult> UpdateBookPatch([FromRoute] int id, [FromBody] JsonPatchDocument bookmodel)
        {
            await _bookrepositry.UpdateBookPatchAsync(id, bookmodel);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletBook([FromRoute] int id)
        {
            await _bookrepositry.DeletBookAsync(id);
            return Ok("book deleted" );  
        }
    }
}

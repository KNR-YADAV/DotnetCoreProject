using AutoMapper;
using BookStore.Api.Data;
using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace BookStore.Api.Repository
{
    public class BooksRepository:IBookRepository
    {
        private readonly BooksDbContext _context;
        private readonly IMapper _mapper;

        public BooksRepository(BooksDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task <List<BookModel>> GetAllBooksAsync()
        {
            //var records = await _context.books.Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description

            //}).ToListAsync();
            var books = await _context.books.ToListAsync();
            return _mapper.Map<List<BookModel>>(books); 
        }
        public async Task<BookModel> GetBookByIdAsync(int bookid)
        {
            //var records = await _context.books.Where(x => x.Id == bookid).Select(x => new BookModel()
            //{
            //    Id = x.Id,
            //    Title = x.Title,
            //    Description = x.Description

            //}).FirstOrDefaultAsync();

            //return records;
            var book = await _context.books.FindAsync(bookid);
            return _mapper.Map<BookModel>(book);
        }
        public async Task<int> AddBookAsync(BookModel bookmodel)
        {
            var book = new Books()
            {
                Title = bookmodel.Title,
                Description = bookmodel.Description
            };
            _context.books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
        public async Task UpdateBookAsync(int id, BookModel bookmodel)
        {
            var book =  await _context.books.FindAsync(id);
            if(book != null) 
            {
                book.Title = bookmodel.Title;
                book.Description = bookmodel.Description;
                await _context.SaveChangesAsync();
            }
        }
        public async Task UpdateBookPatchAsync(int id, JsonPatchDocument bookmodel)
        {
            var book = await _context.books.FindAsync(id);
            if (book != null)
            {
                bookmodel.ApplyTo(book);
                 await _context.SaveChangesAsync();

            }
        }
        public async Task DeletBookAsync(int bookId)
        {
            var book = new Books()
            {
                Id = bookId
            };
            _context.books.Remove(book);
            await _context.SaveChangesAsync();
            
        }

    }
}

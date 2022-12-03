using BookStore.Api.Data;
using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace BookStore.Api.Repository
{
    public interface IBookRepository
    {
      Task<List<BookModel>> GetAllBooksAsync();
      Task<BookModel> GetBookByIdAsync(int bookid);
        Task<int> AddBookAsync(BookModel bookmodel);
        Task UpdateBookAsync(int id, BookModel bookmodel);
         Task UpdateBookPatchAsync(int id, JsonPatchDocument bookmodel);
        Task DeletBookAsync(int bookId);



    }
}

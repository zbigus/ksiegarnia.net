using System.Collections.Generic;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IBooksRepository
    {
        BookModel GetBook(int id);
        
        List<SimpleBookModel> GetBooks();
        
        List<SimpleBookModel> GetBooksByCategory(int categoryId);
        
        List<SimpleBookModel> GetTopNewBooks();

        List<SimpleBookModel> GetTopSaleBooks();

        List<SimpleBookModel> SearchBooks(string searchPhrase); 
    
        bool AddBook(BookModel book);
        
        bool UpdateBook(BookModel book);
        
        bool DeleteBook(int id);

        bool BookExists(int id);
    }
}
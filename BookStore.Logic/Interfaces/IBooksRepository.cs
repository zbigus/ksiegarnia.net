using System.Collections.Generic;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface IBooksRepository
    {
        /// <summary>
        /// Pobiera książkę z bazy po id
        /// </summary>
        /// <param name="id">Id książki</param>
        /// <returns>Model książki</returns>
        BookModel GetBook(int id);
        
        /// <summary>
        /// Pobiera wszystkie książki z bazy
        /// </summary>
        /// <returns>Lista modeli książek(uproszczona)</returns>
        List<SimpleBookModel> GetBooks();
        
        /// <summary>
        /// Pobiera wszystkie książki z bazy dla podanej kategorii
        /// </summary>
        /// <param name="categoryId">Id kategorii</param>
        /// <returns>Lista modeli książek(uproszczona)</returns>
        List<SimpleBookModel> GetBooksByCategory(int categoryId);
        
        /// <summary>
        /// Pobiera najnowsze książki z bazy
        /// </summary>
        /// <returns>Lista modeli książek(uproszczona)</returns>
        List<SimpleBookModel> GetTopNewBooks();

        /// <summary>
        /// Pobiera najlepiej sprzedające się książki
        /// </summary>
        /// <returns>Lista modeli książek(uproszczona)</returns>
        List<SimpleBookModel> GetTopSaleBooks();

        /// <summary>
        /// Wyszukuje książki po zadanej frazie
        /// </summary>
        /// <param name="searchPhrase">Fraza szukania</param>
        /// <returns>Lista modeli książek(uproszczona)</returns>
        List<SimpleBookModel> SearchBooks(string searchPhrase); 
    
        /// <summary>
        /// Dodaje książkę do bazy. Sprawdza czy książka o podanym id znajduje się już w bazie
        /// </summary>
        /// <param name="book">Model książki</param>
        /// <returns>Potwierdzenie operacji</returns>
        bool AddBook(BookModel book);
        
        /// <summary>
        /// Aktualizuje książkę o podanym id. Sprawdza, czy książka znajduje się w bazie.
        /// Usuwa kategorie i załączniki, które nie znajdują się w modelu i dodaje te, które się w nim znajdują
        /// </summary>
        /// <param name="book">Model książki</param>
        /// <returns>Potwierdzenie operacji</returns>
        bool UpdateBook(BookModel book);
        
        /// <summary>
        /// Usuwa książkę o podanym id. Sprawdza, czy książka znajduje się w bazie.
        /// </summary>
        /// <param name="id">Id książki</param>
        /// <returns>Potwierdzenie operacji</returns>
        bool DeleteBook(int id);

        /// <summary>
        /// Sprawdza czy książka o podanym id znajduje się w bazie
        /// </summary>
        /// <param name="id">Id książki</param>
        /// <returns>Potwierdzenie operacji</returns>
        bool BookExists(int id);
    }
}
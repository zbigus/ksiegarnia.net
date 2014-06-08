using System.Collections.Generic;
using BookStore.Logic.Models;

namespace BookStore.Logic.Interfaces
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Pobieranie kategorii z bazy
        /// </summary>
        /// <param name="id">Id </param>
        /// <returns>Model kategorii</returns>
        CategoryModel GetCategory(int id);

        /// <summary>
        /// Pobiera wszystkie kategorie z bazy
        /// </summary>
        /// <returns>Lista modeli kategorrii</returns>
        List<CategoryModel> GetCategories();

        /// <summary>
        /// Dodaje kategorię jeżeli nie istnieje
        /// </summary>
        /// <param name="name">Nazwa kategorii</param>
        /// <returns>Potwierdzenie dodania</returns>
        bool AddCategory(string name);

        /// <summary>
        /// Dodanie kategorii dla książki jeżeli kategoria istnieje i nie ma już takiego powiązania
        /// </summary>
        /// <param name="categoryId">Id kategorii</param>
        /// <param name="bookId">Id książki</param>
        /// <returns>Potwierdzenie operacji</returns>
        bool AddBookCategory(int categoryId, int bookId);

        /// <summary>
        /// Dodanie kolekcji kategorii dla książki jeżeli kategoria istnieje i nie ma już takiego powiązania
        /// </summary>
        /// <param name="bookId">Id książki</param>
        /// <param name="categories">Kolekcja id kategorii</param>
        void AddBookCategories(int bookId, IEnumerable<int> categories);

        /// <summary>
        /// Usuwa kategorie, które nie znajdują się w kolekcji i dodaje te które się w niej znajdują.
        /// Dodaje tylko istniejące kategorie i nie dubluje istniejących
        /// </summary>
        /// <param name="bookId">Id książki</param>
        /// <param name="categories">Id kategorii do dodania</param>
        void AddDeleteBookCatedories(int bookId, IEnumerable<int> categories);

        /// <summary>
        /// Usuwa kategorię z bazy. Sprawdza czy kategoria istnieje
        /// </summary>
        /// <param name="id">Id kategorii</param>
        /// <returns>Potwierdzenie operacji usuwania</returns>
        bool DeleteCategory(int id);

        /// <summary>
        /// Usuwa połączenie pomiędzy kategorią a książką.
        /// </summary>
        /// <param name="categoryId">Id kategorii</param>
        /// <param name="bookId">Id książki</param>
        /// <returns>Potwierdzenie operacji</returns>
        bool DeleteBookCategory(int categoryId, int bookId);

        /// <summary>
        /// Usuwa połączenie pomiędzy kolekcją kategorii a książką.
        /// </summary>
        /// <param name="bookId">Id książki</param>
        /// <param name="categories">Kolekcja kategorii</param>
        void DeleteBookCategories(int bookId, IEnumerable<int> categories);

        /// <summary>
        /// Usuwanie wszystkich powiązań pomiędzy książką a kategoriami
        /// </summary>
        /// <param name="bookId">Id książki</param>
        void ClearBookCategories(int bookId);

        /// <summary>
        /// Aktualizacja kategorii. Sprawdza czy kategoria istnieje
        /// </summary>
        /// <param name="category">Model kategorii</param>
        /// <returns>Potwierdzenie aktualizacji</returns>
        bool UpdateCategory(CategoryModel category);

        /// <summary>
        /// Sprawdzenie czy kategoria istnieje
        /// </summary>
        /// <param name="id">Id kategorii</param>
        /// <returns>Rezultat sprawdzenia</returns>
        bool CategoryExists(int id);

        /// <summary>
        /// Sprawdzenie czy kategoria istnieje
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool CategoryExists(string name);
    }
}
using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public BookModel GetBook(int id)
        {
            var book = GetBookImpl(id);
            if (book == null)
                return null;
            var result = BookModel.Create(book);
            result.Attachments = GetAttachments(id);
            return result;
        }

        public List<SimpleBookModel> GetBooks()
        {
            var books = _db.Books
                .AsEnumerable()
                .Select(SimpleBookModel.Create)
                .ToList();
            AddFirstAttToBook(books);
            return books;
        }

        public List<SimpleBookModel> GetBooksByCategory(int categoryId)
        {
            var bookIds = _db.BookCategories
                .Where(bc => bc.CategoryId == categoryId)
                .Select(bc => bc.BookId).ToArray();
            return GetBooksImpl(bookIds);
        }

        private List<SimpleBookModel> GetBooksImpl(IEnumerable<int> bookIds)
        {
            var result = new List<SimpleBookModel>();
            foreach (var bookId in bookIds)
            {
                var book = GetBookImpl(bookId);
                if (book != null)
                {
                    var bookModel = SimpleBookModel.Create(book);
                    AddFirstAttToBookImpl(bookModel);
                    result.Add(bookModel);
                }
            }
            return result;
        }

        public List<SimpleBookModel> GetTopNewBooks()
        {
            var books = _db.Books
                .OrderByDescending(book => book.InsertDate)
                .Take(10)
                .AsEnumerable()
                .Select(SimpleBookModel.Create)
                .ToList();
            AddFirstAttToBook(books);
            return books;
        }

        private void AddFirstAttToBook(List<SimpleBookModel> books)
        {
            books.ForEach(AddFirstAttToBookImpl);
        }

        private void AddFirstAttToBookImpl(SimpleBookModel model)
        {
            var att = _db.Attachments.OrderBy(attachment => attachment.Id)
                .FirstOrDefault(attachment => attachment.BookId == model.Id);
            if (att != null)
                model.Attachment = AttachmentModel.Create(att);
        }

        public List<SimpleBookModel> GetTopSaleBooks()
        {
            var bookIds = _db.Orders
                .GroupBy(order => order.BookId)
                .Select(orders => new {Id = orders.Key, Count = orders.Count()})
                .OrderByDescending(arg => arg.Count)
                .Take(5)
                .Select(arg => arg.Id);
            return GetBooksImpl(bookIds);
        }

        public List<SimpleBookModel> SearchBooks(string searchPhrase)
        {
            var books = _db.Books.Where(book =>
                book.Title.Contains(searchPhrase) || book.Author.Contains(searchPhrase) ||
                book.Description.Contains(searchPhrase))
                .AsEnumerable()
                .Select(SimpleBookModel.Create)
                .ToList();
            AddFirstAttToBook(books);
            return books;
        }

        public bool AddBook(BookModel book)
        {
            //przerywamy jeżeli książka z takim id już istniej
            if (BookExists(book.Id))
                return false;
            var newBook = new Book
            {
                Author = book.Author,
                Description = book.Description,
                Isbn = book.Isbn,
                Price = book.Price,
                Publisher = book.Publisher,
                Title = book.Title,
                Year = book.Year
            };
            _db.Books.Add(newBook);
            //zapisujemy żeby wyciągnąć id
            _db.SaveChanges();
            //zapisujemy powiązane kategorie
            if (book.Categories != null)
                AddBookCategories(newBook.Id, book.Categories.Select(arg => arg.Id));
            if (book.Attachments != null)
            {
                //ustawiamy załącznikom id nowej książki
                book.Attachments.ForEach(arg => arg.BookId = newBook.Id);
                //dodajemy załączniki
                AddAttachments(book.Attachments);    
            }
            return true;
        }

        public bool UpdateBook(BookModel book)
        {
            var dalBook = GetBookImpl(book.Id);
            if (dalBook == null)
                return false;
            dalBook.Author = book.Author;
            dalBook.Description = book.Description;
            dalBook.Isbn = book.Isbn;
            dalBook.Price = book.Price;
            dalBook.Publisher = book.Publisher;
            dalBook.Title = book.Title;
            dalBook.Year = book.Year;
            _db.SaveChanges();

            if (book.Categories != null)
                AddDeleteBookCatedories(book.Id, book.Categories.Select(cat => cat.Id));
            if (book.Attachments != null)
                AddDeleteAttachments(book.Attachments);
            
            return true;
        }

        public bool DeleteBook(int id)
        {
            var book = GetBookImpl(id);
            if (book == null)
                return false;
            _db.Books.Remove(book);
            _db.SaveChanges();
            return true;
        }

        public bool BookExists(int id)
        {
            return GetBookImpl(id) != null;
        }

        private Book GetBookImpl(int id)
        {
            return _db.Books.Find(id);
        }
    }
}
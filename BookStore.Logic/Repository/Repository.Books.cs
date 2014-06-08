using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public List<BookModel> GetAllBooks()
        {
            return _db.Books.AsEnumerable().Select(BookModel.Create).ToList();
        }

        public List<SimpleBookModel> GetInitialBooks()
        {
            return _db.Books.AsEnumerable().Select(SimpleBookModel.Create).ToList();
        }

        public BookModel GetBookById(int id)
        {
            var result = GetBooksImpl(id);
            return result == null ? null : BookModel.Create(result);
        }

        public bool AddBook(BookModel b, out int id)
        {
            if (_db.Books.Find(b.Id) != null)
            {
                id = 0;
                return false;
            }
            var book = new Book
            {
                Id = b.Id,
                Author = b.Author,
                Title = b.Title,
                Isbn = b.Isbn,
                Publisher = b.Publisher,
                Year = b.Year,
                Price = b.Price,
                Description = b.Description
            };
            _db.Books.Add(book);
            _db.SaveChanges();

            id = book.Id;
            foreach (var item in b.Categories)
            {
                _db.BookCategories.Add(new BookCategory {BookId = id, CategoryId = item.Id});
                _db.SaveChanges();
            }

            return true;
        }


        public BookModel GetBook(int id)
        {
            Book book = _db.Books.Find(id);
            if (book == null)
                return null;
            var result = new BookModel(book);
            result.SetAttachments(_db.Attachments.Where(att => att.BookId == id).ToList());
            return result;
        }

        public List<SimpleBookModel> GetBooks()
        {
            return _db.Books.Select(book => new SimpleBookModel(book)).ToList();
        }

        public List<SimpleBookModel> GetBooksByCategory(int categoryId)
        {
            List<int> bookIds =
                _db.BookCategories.Where(bc => bc.CategoryId == categoryId).Select(bc => bc.BookId).ToList();
            return
                (from bookId in bookIds
                    select _db.Books.Find(bookId)
                    into book
                    where book != null
                    select new SimpleBookModel(book)).ToList();
        }

        public BookModel AddBook(BookModel book)
        {
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
            //zapisujemy powiązane kategorie
            foreach (var categories in book.Categories)
            {
                _db.BookCategories.Add(new BookCategory {BookId = newBook.Id, CategoryId = categories.Id});
            }
            //dodajemy załączniki
            foreach (var attachment in book.Attachments)
            {
                _db.Attachments.Add(new Attachment
                {
                    BookId = newBook.Id,
                    Name = attachment.Name,
                    Content = attachment.Content
                });
            }
            _db.SaveChanges();
            return GetBook(newBook.Id);
        }

        public bool UpdateBook(BookModel book)
        {
            var dalBook = _db.Books.Find(book.Id);
            if (dalBook == null)
                return false;
            dalBook.Author = book.Author;
            dalBook.Description = book.Description;
            dalBook.Isbn = book.Isbn;
            dalBook.Price = book.Price;
            dalBook.Publisher = book.Publisher;
            dalBook.Title = book.Title;
            dalBook.Year = book.Year;
            AddDeleteBookCatedories(book.Id, book.Categories.Select(cat => cat.Id));

            //TODO: zoptymalizować dodawanie i usuwanie załączników i kategorii
            var currentAttachents = _db.Attachments.Where(att => att.BookId == book.Id);
            _db.Attachments.RemoveRange(currentAttachents);
            foreach (var attachment in book.Attachments)
            {
                _db.Attachments.Add(new Attachment
                {
                    BookId = book.Id,
                    Content = attachment.Content,
                    Name = attachment.Name
                });
            }
            _db.SaveChanges();
            return true;
        }

        public bool DeleteBook(int id)
        {
            Book book = _db.Books.Find(id);
            if (book == null)
            {
                return false;
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return true;
        }

        private Book GetBooksImpl(int id)
        {
            return _db.Books.Find(id);
        }
    }
}
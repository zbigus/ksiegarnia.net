using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Interfaces;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public BookModel GetBook(int id)
        {
            Book book = GetBookImpl(id);
            if (book == null)
                return null;
            var result = new BookModel(book);
            result.SetAttachments(_db.Attachments.Where(att => att.BookId == id).ToList());
            return result;
        }

        public List<SimpleBookModel> GetBooks()
        {
            var books = _db.Books.AsEnumerable()
                .Select(SimpleBookModel.Create)
                .ToList();
            books.ForEach(model =>
            {
                var att = _db.Attachments.OrderBy(attachment => attachment.Id)
                    .FirstOrDefault(attachment => attachment.BookId == model.Id);
                if (att != null)
                    model.Attachment = AttachmentModel.Create(att);
            });
            return books;
        }

        public List<SimpleBookModel> GetBooksByCategory(int categoryId)
        {
            var bookIds = _db.BookCategories
                .Where(bc => bc.CategoryId == categoryId)
                .Select(bc => bc.BookId).ToArray();
            var result = new List<SimpleBookModel>();
            foreach (var bookId in bookIds)
            {
                var book = GetBookImpl(bookId);
                if (book != null)
                {
                    var bookModel = SimpleBookModel.Create(book);
                    var att = _db.Attachments.OrderBy(attachment => attachment.Id)
                    .FirstOrDefault(attachment => attachment.BookId == book.Id);
                    if (att != null)
                        bookModel.Attachment = AttachmentModel.Create(att);
                    result.Add(bookModel);
                }
            }
            return result;
        }

        public List<SimpleBookModel> GetTopNewBooks()
        {
            throw new System.NotImplementedException();
        }

        public List<SimpleBookModel> GetTopSaleBooks()
        {
            throw new System.NotImplementedException();
        }

        public List<SimpleBookModel> SearchBooks(string searchPhrase)
        {
            throw new System.NotImplementedException();
        }

        bool IBooksRepository.AddBook(BookModel book)
        {
            throw new System.NotImplementedException();
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
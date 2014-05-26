using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Entities.Models;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository
    {
        public IEnumerable<SimpleBookModel> GetBooks()
        {
            return _db.Books.ToList().Select(SimpleBookModel.Create).ToList();
        }

        public IEnumerable<SimpleBookModel> GetBooks(int categoryId)
        {
            var result = new List<SimpleBookModel>();
            var bookCategories = _db.BookCategories.Where(bc => bc.CategoryId == categoryId);
            foreach (var bookCategory in bookCategories)
            {
                var book = _db.Books.Find(bookCategory.BookId);
                if (book != null)
                    result.Add(SimpleBookModel.Create(book));
            }
            return result;
        }

        public BookModel GetBook(int id)
        {
            var b = _db.Books.Find(id);
            if (b == null)
                return null;
            var book = BookModel.Create(b);
            //pobranie kategorii
            var categoriesIds = _db.BookCategories.Where(arg => arg.BookId == id).Select(arg => arg.CategoryId).ToList();
            foreach (var categoriesId in categoriesIds)
            {
                var category = _db.Categories.Find(categoriesId);
                if (category != null)
                    book.Categories.Add(CategoryModel.Create(category));
            }
            //pobieranie załączników
            book.Attachments = GetAttachments(id).ToList();
            return book;
        }

        public bool DeleteBook(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
                return false;
            _db.Books.Remove(book);
            _db.SaveChanges();
            return true;
        }

        public bool AddBook(BookModel book)
        {
            //dodajemy książkę
            if (_db.Books.Find(book.Id) != null)
                return false;
            var bookEntity = new Book
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Isbn = book.Isbn,
                Publisher = book.Publisher,
                Year = book.Year,
                Price = book.Price,
                Description = book.Description,
            };

            _db.Books.Add(bookEntity);
            _db.SaveChanges();

            var id = bookEntity.Id;
            //dodajemy kategorię
            foreach (var categoryModel in book.Categories)
            {
                var category = _db.Categories.Find(categoryModel.Id);
                if (category != null)
                {
                    _db.BookCategories.Add(new BookCategory {BookId = id, CategoryId = categoryModel.Id});
                }
            }
            _db.SaveChanges();
            //dodajemy załączniki
            foreach (var attachmentModel in book.Attachments)
            {
                AddAttachment(attachmentModel);
            }
            return true;
        }
    }
}

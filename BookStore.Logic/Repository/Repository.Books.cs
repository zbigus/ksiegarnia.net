﻿using BookStore.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using BookStore.Logic.Models;

namespace BookStore.Logic.Repository
{
    public partial class Repository 
    {
        public IQueryable<Book> GetAllBooks()
        {
            return _db.Books.AsQueryable();
        }
        public Book GetBookById(int id)
        {
            return _db.Books.FirstOrDefault(s => s.Id == id);
        }
        public bool AddBook(BookModel b, List<string> category,out int id)
        {
            if (_db.Books.Find(b.Id) != null)
            {
                id = 0;
                return false;
            }
            var book = new Book
            {
                Id=b.Id,
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
            foreach (var item in category)
            {
                var query = from d in _db.Categories where d.Name == item select d.Id;
                var index = query.ToArray()[0];
                _db.BookCategories.Add(new BookCategory {BookId = book.Id, CategoryId = index});
                _db.SaveChanges();
            }

            return true;
        }



        public BookModel GetBook(int id)
        {
            var book = _db.Books.Find(id);
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
            var bookIds = _db.BookCategories.Where(bc => bc.CategoryId == categoryId).Select(bc => bc.BookId).ToList();
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
            //TODO: zoptymalizować dodawanie i usuwanie załączników i kategorii
            var categoriesIds = book.Categories.Select(cat => cat.Id).Distinct();
            var currenCategories = _db.BookCategories.Where(bc => bc.BookId == book.Id);
            _db.BookCategories.RemoveRange(currenCategories);
            foreach (var categoryId in categoriesIds)
            {
                _db.BookCategories.Add(new BookCategory {BookId = book.Id, CategoryId = categoryId});
            }
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
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return false;
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return true;
        }
    }
}

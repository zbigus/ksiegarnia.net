using System.Runtime.Serialization;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    [DataContract]
    public class SimpleBookModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public int Price { get; set; }

        public SimpleBookModel(Book book)
        {
            Id = book.Id;
            Author = book.Author;
            Title = book.Title;
            Price = book.Price;
        }

        public static SimpleBookModel Create(Book book)
        {
            return new SimpleBookModel(book);
        }
    }
}
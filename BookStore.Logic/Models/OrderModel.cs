using System.Runtime.Serialization;
using BookStore.Entities.Models;

namespace BookStore.Logic.Models
{
    [DataContract]
    public class OrderModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int BookId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string ShopComment { get; set; }
        [DataMember]
        public OrderStatus Status { get; set; }

        public OrderModel(Order order)
        {
            Id = order.Id;
            BookId = order.BookId;
            UserId = order.UserId;
            ShopComment = order.ShopComment;
            Status = order.Status;
        }

        public static OrderModel Create(Order order)
        {
            return new OrderModel(order);
        }
    }
}
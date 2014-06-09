using System;
using BookStore.Entities.Helpers;
using BookStore.Entities.Models;
using BookStore.Logic.Extensions;

namespace BookStore.Logic.Models
{
    public class OrderDetailModel : OrderModel
    {
        public string ShopComment { get; set; }
        /// <summary>
        /// Atrybut dostępny do edycji tylko dla admina
        /// </summary>
        public string ShopCommentEdit { get; set; }
        public string BookDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ModificationDate { get; set; }
        /// <summary>
        /// Atrybut dostępny tylko dla admina
        /// </summary>
        public string UserName { get; set; }

        public static OrderDetailModel Create(Order order)
        {
            return new OrderDetailModel
            {
                Id = order.Id,
                BookDescription = order.Book.Description,
                BookTitle = order.Book.Description,
                ModificationDate = order.ModificationDate,
                OrderDate = order.InsertDate,
                ShopComment = order.ShopComment,
                ShopCommentEdit = "",
                Status = order.Status,
                StatusName = order.Status.GetAttribute<ResxAttribute>().Name,
                UserName = order.User.UserName
            };
        }
    }
}

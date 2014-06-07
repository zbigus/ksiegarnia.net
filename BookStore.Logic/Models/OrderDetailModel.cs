using System;

namespace BookStore.Logic.Models
{
    class OrderDetailModel : OrderModel
    {
        public string ShopComment { get; set; }
        public string BookDescription { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        //To ma być dostepne tylko dla Admina
        public string UserName { get; set; }
    }
}

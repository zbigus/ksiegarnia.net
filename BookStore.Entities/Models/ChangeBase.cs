using System;

namespace BookStore.Entities.Models
{
    public class ChangeBase
    {
        public DateTime? InsertDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
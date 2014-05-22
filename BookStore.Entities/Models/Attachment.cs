using System;
using System.Collections.Generic;

namespace BookStore.Entities.Models
{
    public class Attachment
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public byte[] Content { get; set; }

        public virtual Book Book { get; set; }
    }
}

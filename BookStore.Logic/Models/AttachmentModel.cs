using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Models
{
        public class AttachmentModel
        {
            public int ID { get; set; }
            public int BookID { get; set; }
            public byte[] Content { get; set; }
        }
}

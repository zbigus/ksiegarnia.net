using BookStore.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.RepositoryInterfaces
{
    public partial interface IRepository
    {
        Attachment GetAttachmentById(int id);
        bool AddAttachment(Attachment a);
        bool DeleteAttachment(int id);
    }
}

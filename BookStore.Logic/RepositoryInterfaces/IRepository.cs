using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.RepositoryInterfaces
{
    public interface IRepository: IBooksRepository, IAttachmentsRepository, IUsersRepository, IOrdersRepository, ICategoryRepository
    {
    }
}

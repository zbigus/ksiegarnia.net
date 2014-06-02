namespace BookStore.Logic.Interfaces
{
    public interface IRepository : IBooksRepository, IAttachmentsRepository, IUsersRepository, IOrdersRepository,
        ICategoryRepository
    {
    }
}

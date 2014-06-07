namespace BookStore.Logic.Interfaces
{
    public interface IRepository : IBooksRepository, IAttachmentsRepository, IOrdersRepository,
        ICategoryRepository
    {
    }
}
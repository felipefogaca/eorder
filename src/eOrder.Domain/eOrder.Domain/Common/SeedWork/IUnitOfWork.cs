namespace eOrder.Domain.Common.SeedWork
{
    public interface IUnitOfWork
    {
        Task Commit(CancellationToken cancellationToken);
        Task RollBack(CancellationToken cancellationToken);

    }
}

namespace eOrder.Domain.Common.SeedWork
{
    public abstract class Entity
    {
        protected Entity() => Id = 0;

        public long Id { get; protected set; }
    }
}

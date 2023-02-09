using MediatR;

namespace eOrder.Domain.Orders.UseCases.EnterOrder
{
    public interface IEnterOrder : IRequestHandler<EnterOrderInput>
    {
    }
}

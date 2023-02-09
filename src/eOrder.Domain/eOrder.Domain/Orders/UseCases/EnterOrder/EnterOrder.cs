using eOrder.Domain.Common.Exceptions;
using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Compounds.Repositories;
using eOrder.Domain.Customers.Repositories;
using eOrder.Domain.Orders.Entities;
using eOrder.Domain.Orders.Factories;
using eOrder.Domain.Orders.Repositories;
using eOrder.Domain.Orders.ValueObjects;
using eOrder.Domain.Rules.Events.OrderInProcess;
using eOrder.Domain.Rules.Repositories;
using MediatR;

namespace eOrder.Domain.Orders.UseCases.EnterOrder
{
    public class EnterOrder : IEnterOrder
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly ICompoundsRepository _compoundsRepository;
        private readonly IRulesRepository _rulesRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public EnterOrder(ICustomersRepository customersRepository, ICompoundsRepository compoundsRepository, IRulesRepository rulesRepository, IOrdersRepository ordersRepository, IMediator mediator, IUnitOfWork unitOfWork)
        {
            _customersRepository = customersRepository;
            _compoundsRepository = compoundsRepository;
            _rulesRepository = rulesRepository;
            _ordersRepository = ordersRepository;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EnterOrderInput request, CancellationToken cancellationToken)
        {
            var customer = await _customersRepository.FindByDocument(request.CustomerDocument, cancellationToken);

            if (customer == null)
                throw new NotFoundException("Customer not found");

            var compound = await _compoundsRepository.FindByCode(request.CompoundCode, cancellationToken);
            if (compound == null)
                throw new NotFoundException("Compound not found");


            var rules = await _rulesRepository.FindAllActivitiesWithNoParameters(cancellationToken);

            foreach (var rule in rules)
            {
                var parametersExists = compound.ParameterExists(rule.Id);
                if (!parametersExists)
                    throw new Common.Exceptions.ApplicationException($"Parameter for rule {rule.Name} not exists");
            }


            var order = await _ordersRepository.Find(customer.Id, compound.Id, request.RequestNumber, request.ShippingDate);



            var release = new Release(request.ReleaseNumber, request.Quantity);

            if (order == null)
            {
                order = OrderFactory.CreateNewOrder(
                    request.RequestNumber,
                    request.Quantity,
                    request.OrderType,
                    request.ShippingDate,
                    request.ReleaseNumber,
                    customer,
                    compound);

            }
            else
            {
                order.Update(release, request.OrderType);
            }

            await _ordersRepository.Update(order, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);


            if(order.OrderSituation == Order.Situation.Processing)
            {
                var @event = new OrderInProcessEvent(order, customer, compound, rules);

                await _mediator.Publish(@event, cancellationToken);

            }


            return Unit.Value;
        }
    }
}

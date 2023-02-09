using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Compounds.Repositories;
using eOrder.Domain.Compounds.UseCases.CreateCompound;
using eOrder.Domain.Customers.Repositories;
using eOrder.Domain.Customers.UseCases.CreateCustomer;
using eOrder.Domain.Customers.UseCases.FindCustomer;
using eOrder.Domain.Customers.UseCases.ListCustomers;
using eOrder.Domain.Customers.UseCases.UpdateCustomer;
using eOrder.Domain.DayOffs.Repositories;
using eOrder.Domain.Orders.Repositories;
using eOrder.Domain.Rules.Repositories;
using eOrder.Infra;
using eOrder.Infra.Repositories;
using MediatR;

namespace eOrder.Api.Configurations
{
    public static class UseCasesConfiguration
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {

            services.AddMediatR(typeof(CreateCustomer));
            

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomersRepository, CustomersRepository>();
            services.AddTransient<ICompoundsRepository, CompoundsRepository>();
            services.AddTransient<IRulesRepository, RulesRepository>();
            services.AddTransient<IDayOffsRepository, DayOffsRepository>();
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();


            return services;
        }
    }
}

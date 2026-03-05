using ECommerce.OrderApplication.Features.Addresses.Queries;
using ECommerce.OrderApplication.Features.Addresses.Results;
using ECommerce.OrderApplication.Interfaces;
using ECommerce.OrderDomain.Entities;
using Mapster;
using MediatR;

namespace ECommerce.OrderApplication.Features.Addresses.Handlers
{
    internal class GetAdressesQueryHandler (IRepository<Address> _repository): IRequestHandler<GetAddressesQuery, List<GetAdressesQueryResult>>
    {
        public async Task<List<GetAdressesQueryResult>> Handle(GetAddressesQuery request, CancellationToken cancellationToken)
        {
            var adresses = await _repository.GetAllAsync();
            return adresses.Adapt<List<GetAdressesQueryResult>>();
        }
    }
}

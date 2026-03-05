using ECommerce.OrderApplication.Features.Addresses.Results;
using MediatR;

namespace ECommerce.OrderApplication.Features.Addresses.Queries
{
    public class GetAddressesQuery :IRequest<List<GetAdressesQueryResult>>
    {
    }
}

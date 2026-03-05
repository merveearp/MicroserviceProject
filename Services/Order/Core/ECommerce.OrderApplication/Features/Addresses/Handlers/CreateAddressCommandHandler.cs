using ECommerce.OrderApplication.Features.Addresses.Commands;
using ECommerce.OrderApplication.Interfaces;
using ECommerce.OrderDomain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.OrderApplication.Features.Addresses.Handlers
{
    public class CreateAddressCommandHandler(IRepository<Address> _repository) : IRequestHandler<CreateAddressCommand>
    {
        public async Task Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = request.Adapt<Address>();
            await _repository.CreateAsync(address);

        }
    }
}

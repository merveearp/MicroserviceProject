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
    public class UpdateAddressCommandHandler(IRepository<Address> _repository) : IRequestHandler<UpdateAddressCommand>
    {
        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetByIdAsync(request.Id);
            if (address == null)
            {
                throw new Exception("Adres Bulunamadı");
            }
            request.Adapt(address);
            await _repository.UpdateAsync(address); 
        }

        
    }
}

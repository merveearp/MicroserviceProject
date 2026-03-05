using MediatR;

namespace ECommerce.OrderApplication.Features.Addresses.Commands;

public record CreateAddressCommand(
                                 string UserId,
                                 string FirstName,
                                 string LastName,
                                 string City,
                                 string Disrict,
                                 string AddressLine) : IRequest;


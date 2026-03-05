namespace ECommerce.OrderApplication.Features.Addresses.Results;

public record GetAdressesQueryResult(int Id,
                                     string UserId,
                                     string FirstName,
                                     string LastName,
                                     string City,
                                     string Disrict,
                                     string AddressLine);
    



using ItemShop.Order.Applcation.Features.CQRS.Results.AddressResults;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Queries.AdressQueries
{
     public class GetAddressQuery : IRequest<List<GetAddressQueryResult>>
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}
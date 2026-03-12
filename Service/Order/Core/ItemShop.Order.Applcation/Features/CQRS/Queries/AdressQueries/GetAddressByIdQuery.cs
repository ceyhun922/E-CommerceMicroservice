using ItemShop.Order.Applcation.Features.CQRS.Results.AddressResults;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Queries.AdressQueries
{
    public class GetAddressByIdQuery : IRequest<GetAddressByIdQueryResult>
    {
        public int Id { get; set; }

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
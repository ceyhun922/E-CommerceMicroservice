using ItemShop.Order.Applcation.Features.CQRS.Queries.AdressQueries;
using ItemShop.Order.Applcation.Features.CQRS.Results.AddressResults;
using ItemShop.Order.Applcation.Interfaces;
using ItemShop.Order.Domain.Entities;
using MediatR;

namespace ItemShop.Order.Applcation.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, GetAddressByIdQueryResult>
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null)
                return null;

            return new GetAddressByIdQueryResult
            {
                AddressId = value.AddressId,
                City = value.City,
                Detail = value.Detail,
                District = value.District,
                UserId = value.UserId
            };
        }
    }
}
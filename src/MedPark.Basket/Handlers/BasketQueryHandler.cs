using AutoMapper;
using MedPark.Basket.Domain;
using MedPark.Basket.Dto;
using MedPark.Basket.Queries;
using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Handlers
{
    public class BasketQueryHandler : IQueryHandler<BasketQuery, BasketDto>
    {
        private IMedParkRepository<CustomerBasket> _basketRepo { get; }
        private IMedParkRepository<BasketItem> _basketItemRepo { get; }
        private IMapper _mapper { get; }

        public BasketQueryHandler(IMedParkRepository<CustomerBasket> basketRepo, IMedParkRepository<BasketItem> basketItemRepo, IMapper mapper)
        {
            _basketRepo = basketRepo;
            _basketItemRepo = basketItemRepo;
            _mapper = mapper;
        }

        public async Task<BasketDto> HandleAsync(BasketQuery query)
        {
            CustomerBasket cBasket = await _basketRepo.GetAsync(x => x.CustomerId == query.CustomerId);

            if (cBasket is null)
                throw new MedParkException("basket_does_not_exist", $"A basket for customer {query.CustomerId} does not exist.");

            IEnumerable<BasketItem> items = await _basketItemRepo.BrowseAsync(x => x.BasketId == cBasket.Id);

            BasketDto basketDto = _mapper.Map<BasketDto>(cBasket);
            basketDto.BasketId = cBasket.Id;
            basketDto.Items = items;

            basketDto.BasketTotal = basketDto.Items.Sum(x => x.Price);

            return basketDto;
        }
    }
}

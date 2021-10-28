using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using System.Threading;

using Ordering.Application.Contracts.Persistance;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Command.CheckoutOrder
{
    public class CheckOutOrderCommandHandler : IRequestHandler<CheckOutOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CheckOutOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, ILogger logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(CheckOutOrderCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<Order>(request);
           
            var newOrder = await _orderRepository.AddAsync(orderEntity);
          
            _logger.LogInformation($"Order {newOrder.Id} is successfully created  ");

            return newOrder.Id;
        }
    }
}

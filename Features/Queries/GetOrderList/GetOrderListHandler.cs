using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Ordering.Application.Contracts.Persistance;
using AutoMapper;
namespace Ordering.Application.Features.Queries.GetOrderList
{
    class GetOrderListHandler : IRequestHandler<GetOrderListQuery, List<OrderVm>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderListHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<OrderVm>> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
        {
         
            var orderList = await _orderRepository.GetOrdersByUserName(request.UserName);
            var result = _mapper.Map<List<OrderVm>>(orderList);
            return result;
            // write down a mapper which maps order --> ordervm
        }
    }
}

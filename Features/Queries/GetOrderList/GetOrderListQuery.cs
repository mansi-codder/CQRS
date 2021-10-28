using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Queries.GetOrderList
{
    class GetOrderListQuery : IRequest<List<OrderVm>>
    {
        public string UserName { get; set; }

        public GetOrderListQuery(string userName)
        {
            //UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            UserName = userName;
        }


    }
}

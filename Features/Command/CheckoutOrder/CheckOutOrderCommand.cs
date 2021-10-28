using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Ordering.Application.Features.Command.CheckoutOrder
{
  public  class CheckOutOrderCommand :IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }

        //payment
        public string CardNumber { get; set; }
        public int Payment { get; set; }
    }
}

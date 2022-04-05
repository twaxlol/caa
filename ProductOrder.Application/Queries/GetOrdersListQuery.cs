using MediatR;
using ProductOrder.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder.Application.Queries
{
    public class GetOrdersListQuery : IRequest<List<OrderResponse>>
    {
    }
}

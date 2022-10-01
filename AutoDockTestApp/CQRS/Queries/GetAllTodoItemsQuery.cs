using AutoDockTestApp.Context;
using AutoDockTestApp.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDockTestApp.CQRS.Queries
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItem>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItem>>
        {
            private readonly IApplicationContext _context;
            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<TodoItem>> Handle(GetAllTodoItemsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Tasks.ToListAsync();
                return productList.AsReadOnly();
            }
        }
    }
}

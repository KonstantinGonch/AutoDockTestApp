using AutoDockTestApp.Common;
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
    public class GetAllTodoItemsQuery : IRequest<PagedResponseModel<TodoItem>>
    {
        public int? PageNumber { get; set; }
        private const int pageSize = 10;
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, PagedResponseModel<TodoItem>>
        {
            private readonly IApplicationContext _context;
            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<PagedResponseModel<TodoItem>> Handle(GetAllTodoItemsQuery query, CancellationToken cancellationToken)
            {
                var tasks = query.PageNumber.HasValue ?
                    await _context.Tasks.Skip((query.PageNumber.Value - 1) * pageSize).Take(pageSize).ToListAsync() :
                    await _context.Tasks.ToListAsync();
                return new PagedResponseModel<TodoItem>
                {
                    PageNumber = query.PageNumber ?? 0,
                    TotalPages = query.PageNumber.HasValue ? (int)Math.Ceiling(_context.Tasks.Count() / (double)pageSize) : 0,
                    Data = tasks
                };
            }
        }
    }
}

using AutoDockTestApp.Context;
using AutoDockTestApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDockTestApp.CQRS.Queries
{
    public class GetTodoItemByIdQuery : IRequest<TodoItem>
    {
        public int Id { get; set; }
        public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItem>
        {
            private readonly IApplicationContext _context;
            public GetTodoItemByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<TodoItem> Handle(GetTodoItemByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _context.Tasks.FirstOrDefault(a => a.Id == query.Id);
                return product;
            }
        }
    }
}

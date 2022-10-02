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
    public class GetTodoItemFileAttachmentQuery : IRequest<IEnumerable<TodoItemFileAttachment>>
    {
        public long TodoItemId { get; set; }

        public class GetTodoItemFileAttachmentQueryHandler : IRequestHandler<GetTodoItemFileAttachmentQuery, IEnumerable<TodoItemFileAttachment>>
        {
            private readonly IApplicationContext _context;
            public GetTodoItemFileAttachmentQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<TodoItemFileAttachment>> Handle(GetTodoItemFileAttachmentQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.FileAttachments.Where(e => e.TodoItemId == query.TodoItemId).ToListAsync();
                return productList.AsReadOnly();
            }
        }
    }
}

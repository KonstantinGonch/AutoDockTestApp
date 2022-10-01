using AutoDockTestApp.Context;
using AutoDockTestApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDockTestApp.CQRS.Commands
{
    public class CreateTodoItemCommand : IRequest<long>
    {
        public TodoItem TodoItem { get; set; }
        public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, long>
        {
            private readonly IApplicationContext _context;
            public CreateTodoItemCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(CreateTodoItemCommand command, CancellationToken cancellationToken)
            {
                var item = command.TodoItem;
                _context.Tasks.Add(item);
                await _context.SaveChanges();
                return item.Id;
            }
        }
    }
}

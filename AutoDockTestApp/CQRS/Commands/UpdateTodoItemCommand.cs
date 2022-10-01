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
    public class UpdateTodoItemCommand : IRequest<long>
    {
        public TodoItem TodoItem { get; set; }
        public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand, long>
        {
            private readonly IApplicationContext _context;
            public UpdateTodoItemCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(UpdateTodoItemCommand command, CancellationToken cancellationToken)
            {
                var item = _context.Tasks.Where(a => a.Id == command.TodoItem.Id).FirstOrDefault();
                if (item == null)
                {
                    return default;
                }
                else
                {
                    item.Title = command.TodoItem.Title;
                    item.Status = command.TodoItem.Status;
                    item.CreationDate = command.TodoItem.CreationDate;
                    await _context.SaveChanges();
                    return item.Id;
                }
            }
        }
    }
}

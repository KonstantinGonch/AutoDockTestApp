using AutoDockTestApp.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDockTestApp.CQRS.Commands
{
    public class DeleteTodoItemByIdCommand : IRequest<long>
    {
        public int Id { get; set; }
        public class DeleteTodoItemByIdCommandHandler : IRequestHandler<DeleteTodoItemByIdCommand, long>
        {
            private readonly IApplicationContext _context;
            public DeleteTodoItemByIdCommandHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<long> Handle(DeleteTodoItemByIdCommand command, CancellationToken cancellationToken)
            {
                var item = _context.Tasks.FirstOrDefault(a => a.Id == command.Id);
                if (item == null) return default;
                _context.Tasks.Remove(item);
                await _context.SaveChanges();
                return item.Id;
            }
        }
    }
}

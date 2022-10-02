using AutoDockTestApp.Context;
using AutoDockTestApp.Util;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDockTestApp.CQRS.Commands
{
    public class DeleteTodoItemFileAttachmentCommand : IRequest<long>
    {
        public long AttachmentId { get; set; }
        public class DeleteTodoItemFileAttachmentCommandHandler : IRequestHandler<DeleteTodoItemFileAttachmentCommand, long>
        {
            private readonly IApplicationContext _context;
            private readonly IAttachmentManager _attachmentManager;
            public DeleteTodoItemFileAttachmentCommandHandler(IApplicationContext context, IAttachmentManager attachmentManager)
            {
                _context = context;
                _attachmentManager = attachmentManager;
            }
            public async Task<long> Handle(DeleteTodoItemFileAttachmentCommand command, CancellationToken cancellationToken)
            {
                var attachment = await _context.FileAttachments.FindAsync(command.AttachmentId);
                if (attachment != null)
                {
                    await _attachmentManager.DeleteAttachmentAsync(attachment.FileName);
                    _context.FileAttachments.Remove(attachment);
                    await _context.SaveChanges();
                    return attachment.Id;
                }
                return default;
            }
        }
    }
}

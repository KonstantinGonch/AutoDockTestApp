using AutoDockTestApp.Context;
using AutoDockTestApp.Models;
using AutoDockTestApp.Util;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDockTestApp.CQRS.Commands
{
    public class AttachFileToTodoItemCommand : IRequest<long>
    {
        public long TaskId { get; set; }
        public IFormFile FileData { get; set; }
        public string DisplayName { get; set; }
        public class AttachFileToTodoItemCommandHandler : IRequestHandler<AttachFileToTodoItemCommand, long>
        {
            private readonly IApplicationContext _context;
            private readonly IAttachmentManager _attachmentManager;
            public AttachFileToTodoItemCommandHandler(IApplicationContext context, IAttachmentManager attachmentManager)
            {
                _context = context;
                _attachmentManager = attachmentManager;
            }
            public async Task<long> Handle(AttachFileToTodoItemCommand command, CancellationToken cancellationToken)
            {
                var fileName = await _attachmentManager.SaveAttachmentAsync(command.FileData);
                var fileAttachment = new TodoItemFileAttachment
                {
                    FileName = fileName,
                    TodoItemId = command.TaskId,
                    DisplayName = command.DisplayName
                };
                await _context.FileAttachments.AddAsync(fileAttachment);
                await _context.SaveChanges();
                return fileAttachment.Id;
            }
        }
    }
}

using AutoDockTestApp.CQRS.Commands;
using AutoDockTestApp.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Controllers
{
    /// <summary>
    /// Действия с файлами, прикрепляемыми к задаче
    /// </summary>
    [ApiController]
    [Route("api/attachments")]
    public class TodoItemFileAttachmentController : ControllerBase
    {
        private IMediator _mediator;
        public TodoItemFileAttachmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Получить описание всех прикрепленных к задаче файлов
        /// </summary>
        [HttpGet]
        [Route("list/{todoItemId}")]
        public async Task<IActionResult> GetTodoItemAttachments(long todoItemId)
        {
            return Ok(await _mediator.Send(new GetTodoItemFileAttachmentQuery { TodoItemId = todoItemId }));
        }

        /// <summary>
        /// Прикрепить файл к задаче
        /// </summary>
        [HttpPost]
        [Route("attach")]
        public async Task<IActionResult> AttachFileToTodoItem(long todoItemId, string displayName, IFormFile fileData)
        {
            return Ok(await _mediator.Send(new AttachFileToTodoItemCommand { TaskId = todoItemId, FileData = fileData , DisplayName = displayName}));
        }

        /// <summary>
        /// Удалить файл
        /// </summary>
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteAttachment(long attachmentId)
        {
            return Ok(await _mediator.Send(new DeleteTodoItemFileAttachmentCommand { AttachmentId = attachmentId}));
        }
    }
}

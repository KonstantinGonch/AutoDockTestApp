using AutoDockTestApp.Common;
using AutoDockTestApp.CQRS.Commands;
using AutoDockTestApp.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Controllers
{
    /// <summary>
    /// Действия с задачами
    /// </summary>
    [Route("api/todoItem")]
    [ApiController]
    public class TodoItemController : BaseApiController
    {
        private IMediator _mediator;
        public TodoItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Добавление задачи в список
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create(CreateTodoItemCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(CreateSuccessResponse(id));
        }

        /// <summary>
        /// Весь список задач
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list/{pageNumber}")]
        public async Task<IActionResult> GetAll(int? pageNumber)
        {
            var items = await _mediator.Send(new GetAllTodoItemsQuery { PageNumber = pageNumber });
            return Ok(CreateSuccessResponse(items));
        }

        /// <summary>
        /// Описание задачи
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetTodoItemByIdQuery { Id = id });
            return Ok(CreateSuccessResponse(result));
        }

        /// <summary>
        /// Удалить задачу
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteTodoItemByIdCommand { Id = id });
            return Ok(CreateSuccessResponse(result));
        }

        /// <summary>
        /// Обновить данные о задаче
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, UpdateTodoItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(CreateSuccessResponse(result));
        }
    }
}

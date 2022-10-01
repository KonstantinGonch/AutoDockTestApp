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
    public class TodoItemController : ControllerBase
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
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [Route("list")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllTodoItemsQuery()));
        }

        [Route("get")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetTodoItemByIdQuery { Id = id }));
        }

        [Route("delete")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteTodoItemByIdCommand { Id = id }));
        }

        [Route("update")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTodoItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}

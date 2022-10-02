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
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Create(CreateTodoItemCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        /// <summary>
        /// Весь список задач
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllTodoItemsQuery()));
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
            return Ok(await _mediator.Send(new GetTodoItemByIdQuery { Id = id }));
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
            return Ok(await _mediator.Send(new DeleteTodoItemByIdCommand { Id = id }));
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
            return Ok(await _mediator.Send(command));
        }
    }
}
